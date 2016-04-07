using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using forum.Models;

namespace forum.Services.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext db = serviceProvider.GetService<ApplicationDbContext>();

            
        }
    }
}
