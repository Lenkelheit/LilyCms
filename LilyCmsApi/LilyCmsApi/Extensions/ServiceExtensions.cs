﻿using LilyCms.BLL.Interfaces;
using LilyCms.BLL.Services;
using LilyCms.DataAccess.Daos;
using LilyCms.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilyCmsApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ISiteDao, SiteDao>();
            services.AddScoped<ISiteService, SiteService>();
        }
    }
}
