using Blog.Business.Dtos.TopicDtos;
using Blog.Business.ExternalServices.Implements;
using Blog.Business.ExternalServices.Interfaces;
using Blog.Business.Proliles;
using Blog.Business.Repositories.Implements;
using Blog.Business.Repositories.Interfaces;
using Blog.Business.Services.Implements;
using Blog.Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business
{
    public static class ServiceRegistration
    {
        //public static IServiceCollection AddRepositories(this IServiceCollection services) 
        //{
        //    services.AddScoped<ITopicRepositories, TopicRepositories>();
        //    return services;
        //}
        //public static IServiceCollection AddServices(this IServiceCollection services)
        //{
        //    services.AddScoped<ITopicService, TopicService>();
        //    return services;
        //}
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ITopicRepositories, TopicRepositories>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<TopicCreateDTOValidation>());
            services.AddAutoMapper(typeof(TopicMappingProfile).Assembly);
            services.AddScoped<IEmailService, EmailService>();
            //services.AddAutoMapper(typeof(TopicMappingProfile).Assembly);
            return services;
        }
    }
}
