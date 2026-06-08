using AutoMapper;
using Data.Abstract;
using Entity;
using Entity.DTOs;
using Service.Abstract;

namespace Service.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IGenericRepository<Message> _repository;
        private readonly IMapper _mapper;

        public MessageManager(IGenericRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(MessageCreateDto messageCreateDto)
        {
            var entity = _mapper.Map<Message>(messageCreateDto);
            entity.GondermeTarihi = DateTime.Now;
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

        public async Task<List<MessageListDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<MessageListDto>>(entities);
        }

        public async Task<MessageListDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MessageListDto>(entity);
        }
    }
}
