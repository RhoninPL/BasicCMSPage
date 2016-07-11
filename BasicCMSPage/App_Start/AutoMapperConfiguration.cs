using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain;
using Repositories.ViewModels;

namespace BasicCMSPage.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<News, NewsAddViewModel>()
                    .ForMember(d => d.News, s => s.MapFrom(x => x.Content));
                cfg.CreateMap<NewsAddViewModel, News>()
                    .ForMember(d => d.Content, s => s.MapFrom(x => x.News));
                cfg.CreateMap<NewsIndexViewModel, News>()
                    .ForMember(d => d.Content, s => s.MapFrom(x => x.News));
                cfg.CreateMap<News, NewsIndexViewModel>()
                    .ForMember(d => d.News, s => s.MapFrom(x => x.Content));
                cfg.CreateMap<NewsDetailsViewModel, News>()
                    .ForMember(d => d.Content, s => s.MapFrom(x => x.News));
                cfg.CreateMap<News, NewsDetailsViewModel>()
                    .ForMember(d => d.News, s => s.MapFrom(x => x.Content));
                cfg.CreateMap<NewsEditViewModel, News>()
                    .ForMember(d => d.Content, s => s.MapFrom(x => x.News));
                cfg.CreateMap<News, NewsEditViewModel>()
                    .ForMember(d => d.News, s => s.MapFrom(x => x.Content));
                cfg.CreateMap<NewsAdminListViewModel, News>();
                cfg.CreateMap<News, NewsAdminListViewModel>();
            });
        }

    }
}