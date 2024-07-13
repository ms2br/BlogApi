using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.PostReactionDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IPostReactionService
        : IGenericService<PostReaction,PRCreateDto>
    {
        Task UpdateAsync(int? postId,PRUpdateDto dto);
    }
}
