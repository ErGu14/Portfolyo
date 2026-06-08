using AutoMapper;
using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class SiteSettingsManager : ISiteSettingsService
    {
        private readonly IGenericRepository<SiteSettings> _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public SiteSettingsManager(IGenericRepository<SiteSettings> repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddAsync(SiteSettingsUpdateDto siteSettingsCreateDto)
        {
            var entity = _mapper.Map<SiteSettings>(siteSettingsCreateDto);
            
            if (siteSettingsCreateDto.CvFile != null)
            {
                entity.CvPath = await _fileService.UploadFileAsync(siteSettingsCreateDto.CvFile, "cv");
            }
            else
            {
                entity.CvPath = string.Empty;
            }

            if (siteSettingsCreateDto.ProfilFotoFile != null)
            {
                entity.ProfilFoto = await _fileService.UploadFileAsync(siteSettingsCreateDto.ProfilFotoFile, "images");
            }
            else
            {
                entity.ProfilFoto = string.Empty;
            }

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            if (!string.IsNullOrEmpty(entity.CvPath))
            {
                _fileService.DeleteFile(entity.CvPath);
            }
            if (!string.IsNullOrEmpty(entity.ProfilFoto))
            {
                _fileService.DeleteFile(entity.ProfilFoto);
            }

            _repository.Delete(id);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<List<SiteSettingsDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<SiteSettingsDto>>(entities);
        }

        public async Task<SiteSettingsDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SiteSettingsDto>(entity);
        }

        public async Task<bool> UpdateAsync(SiteSettingsUpdateDto siteSettingsUpdateDto)
        {
            var entity = _mapper.Map<SiteSettings>(siteSettingsUpdateDto);
            
            if (siteSettingsUpdateDto.CvFile != null)
            {
                entity.CvPath = await _fileService.UploadFileAsync(siteSettingsUpdateDto.CvFile, "cv");
            }
            else
            {
                entity.CvPath = siteSettingsUpdateDto.CvPath ?? string.Empty;
            }

            if (siteSettingsUpdateDto.ProfilFotoFile != null)
            {
                entity.ProfilFoto = await _fileService.UploadFileAsync(siteSettingsUpdateDto.ProfilFotoFile, "images");
            }
            else
            {
                entity.ProfilFoto = siteSettingsUpdateDto.ProfilFoto ?? string.Empty;
            }

            _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }
    }
}
