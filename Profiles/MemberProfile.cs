using AutoMapper;
using RestfulDemo.Dto;
using RestfulDemo.Models;
using System;

namespace RestfulDemo.Profiles
{
    public class MemberProfile : Profile
    {      
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>()
                .ForMember(
                      dest => dest.EditTime,
                      //opt => opt.MapFrom(src => ((DateTime)src.EditTime).ToString("yyyy/MM/dd HH:mm"))
                      opt => opt.MapFrom(src => src.EditTime == null ? null : ((DateTime)src.EditTime).ToString("yyyy/MM/dd HH:mm"))
                )
                .ForMember(
                      dest => dest.CreateTime,
                      opt => opt.MapFrom(src => ((DateTime)src.CreateTime).ToString("yyyy/MM/dd HH:mm")));
            CreateMap<Member, MemberCreateDto>();
            CreateMap<MemberCreateDto,Member>();

        }
    }
}
