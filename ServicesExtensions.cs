using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTaskApplication.Context;

namespace ToDoTaskApplication
{
    public static class ServicesExtensions
    {
        public  static IConfiguration Configuration { get; set; }
        //public static void SqlConfiguration( this IServiceCollection services )
        //{
        //    var connection = Configuration["Data:ConnectionStrings:DefaultConnection"];
        //    services.AddDbContext<DbAppContext>(option => option.UseSqlServer(connection));
        //}
    }
}
