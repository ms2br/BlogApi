using AutoMapper;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Profiles
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<FileEntity, FileDetailDto>();
        }
    }
}
