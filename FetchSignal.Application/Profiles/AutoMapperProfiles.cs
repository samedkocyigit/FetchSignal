using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FetchSignal.Domain.Dtos;
using FetchSignal.Domain.Models;

namespace FetchSignal.Application.Profiles
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RawData, RawDataDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SourceUrl, opt => opt.MapFrom(src => src.SourceUrl))
                .ForMember(dest => dest.FetchedTime, opt => opt.MapFrom(src => src.FetchedTime))
                .ForMember(dest => dest.ProcessedStartDate, opt => opt.MapFrom(src => src.ProcessedStartDate))
                .ForMember(dest => dest.ProcessedEndDate, opt => opt.MapFrom(src => src.ProcessedEndDate))
                .ForMember(dest => dest.FetchedData, opt => opt.MapFrom(src => src.FetchedData))
                .ForMember(dest => dest.UrlId, opt => opt.MapFrom(src => src.SourceUrl.Id))
                .ForMember(dest => dest.FetchedDataId, opt => opt.MapFrom(src => src.FetchedData.Id));

            CreateMap<SourceUrl,SourceUrlDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.Application, opt => opt.MapFrom(src => src.Application))
                .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(src => src.Application.Id));

            CreateMap<ListOfUrls, ListOfUrlsDto>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.Id , opt => opt.MapFrom(src=> src.Id))
                .ForMember(dest => dest.ApplicationName, opt => opt.MapFrom(src => src.ApplicationName))
                .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension));

        }
    }
}
