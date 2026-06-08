using AutoMapper;
using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly IGenericRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public SocialMediaManager(IGenericRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(SocialMediaCreateDto socialMediaCreateDto)
        {
            var entity = _mapper.Map<SocialMedia>(socialMediaCreateDto);
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _repository.Delete(id);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<List<SocialMediaListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<SocialMediaListDto>>(entities);
        }

        public async Task<SocialMediaListDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SocialMediaListDto>(entity);
        }

        public async Task<bool> UpdateAsync(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            var entity = _mapper.Map<SocialMedia>(socialMediaUpdateDto);
            _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }
    }
}
