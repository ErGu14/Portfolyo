using AutoMapper;
using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class CertificateManager : ICertificateService
    {
        private readonly IGenericRepository<Certificate> _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CertificateManager(IGenericRepository<Certificate> repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<bool> AddAsync(CertificateCreateDto certificateCreateDto)
        {
            var entity = _mapper.Map<Certificate>(certificateCreateDto);
            
            if (certificateCreateDto.Dosya != null)
            {
                entity.Path = await _fileService.UploadFileAsync(certificateCreateDto.Dosya, "certificates");
            }
            else
            {
                entity.Path = string.Empty;
            }
            
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            if (!string.IsNullOrEmpty(entity.Path))
            {
                _fileService.DeleteFile(entity.Path);
            }

            _repository.Delete(id);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<List<CertificateListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<CertificateListDto>>(entities);
        }

        public async Task<CertificateListDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CertificateListDto>(entity);
        }

        public async Task<bool> UpdateAsync(CertificateUpdateDto certificateUpdateDto)
        {
            var entity = _mapper.Map<Certificate>(certificateUpdateDto);
            
            if (certificateUpdateDto.Dosya != null)
            {
                entity.Path = await _fileService.UploadFileAsync(certificateUpdateDto.Dosya, "certificates");
            }
            else
            {
                entity.Path = certificateUpdateDto.Path ?? string.Empty;
            }

            _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }
    }
}
