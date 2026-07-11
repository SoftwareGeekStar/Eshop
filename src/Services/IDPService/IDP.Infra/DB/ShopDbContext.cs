using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace IDP.Infra.DB
{
    public class ShopDbContext :DbContext
    {
        protected readonly IConfiguration _configuration;

        public ShopDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("CommandDBConnection"));
        }

        public DbSet<User> Tbl_Users { get; set; }
    }
}
