using AutoMapper;
using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IGenericRepository<Project> _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ProjectManager(IGenericRepository<Project> repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddAsync(ProjectCreateDto projectCreateDto)
        {
            var entity = _mapper.Map<Project>(projectCreateDto);
            
            if (projectCreateDto.ResimFile != null)
            {
                entity.Resim = await _fileService.UploadFileAsync(projectCreateDto.ResimFile, "images/projects");
            }

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            if (!string.IsNullOrEmpty(entity.Resim))
            {
                _fileService.DeleteFile(entity.Resim);
            }

            _repository.Delete(id);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<List<ProjectListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ProjectListDto>>(entities);
        }

        public async Task<ProjectListDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProjectListDto>(entity);
        }

        public async Task<bool> UpdateAsync(ProjectUpdateDto projectUpdateDto)
        {
            var entity = _mapper.Map<Project>(projectUpdateDto);
            
            if (projectUpdateDto.ResimFile != null)
            {
                if (!string.IsNullOrEmpty(projectUpdateDto.Resim))
                    _fileService.DeleteFile(projectUpdateDto.Resim);

                entity.Resim = await _fileService.UploadFileAsync(projectUpdateDto.ResimFile, "images/projects");
            }
            else
            {
                entity.Resim = projectUpdateDto.Resim;
            }

            _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }
    }
}
