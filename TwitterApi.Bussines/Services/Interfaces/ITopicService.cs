using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Dtos.TopicDtos.Common;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface ITopicService : IGenericService<Topic, TopicBaseDto>
    {

        Task UpdateAsync(int? id, TopicUpdateDto dto);
    }
}
