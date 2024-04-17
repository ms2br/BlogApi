using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface ITopicService : IGenericService<Topic, TopicCreateDto>
    {

        Task UpdateAsync(int? id, TopicUpdateDto dto);
    }
}
