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
            //Mapper.Initialize(cfg => {
            //    cfg.AddProfile(new NewsProfile());
            //});
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<News, NewsAddViewModel>()
            //        .ForMember(d => d.News, s => s.MapFrom(x => x.Content));
            //    cfg.CreateMap<NewsAddViewModel, News>()
            //        .ForMember(d => d.Content, s => s.MapFrom(x => x.News));
            //});

            Mapper.Initialize(cfg => {
                cfg.CreateMap<News, NewsAddViewModel>()
                    .ForMember(d => d.News, s => s.MapFrom(x => x.Content));
                cfg.CreateMap<NewsAddViewModel, News>()
                    .ForMember(d => d.Content, s => s.MapFrom(x => x.News));
            });
        }
        
    }

    //public class NewsProfile : Profile
    //{
    //    protected override void Configure()
    //    {
    //        Mapper.CreateMap<News,NewsAddViewModel>();
    //        Mapper.CreateMap<NewsAddViewModel, News>();
    //    }
    //}
}