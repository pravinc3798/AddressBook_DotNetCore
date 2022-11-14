using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace RepositoryLayer.Context
{
    public class AddressBookContext : DbContext
    {
        //Added Microsoft.Entityframeworkcore 3.1.0
        //Added Microsoft.Entityframeworkcore.Relation 3.1.0
        //Added Microsoft.Entityframeworkcore.SqlServer 3.1.0
        //Added Microsoft.Entityframeworkcore.Tools 3.1.0
        //Added Microsoft.EntityFrameworkCore.Design 3.1.0
        //services.AddDbContext<AddressBookContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:AddressBookDB"])); - Startup.configureservices
        //Add-Migration 
        //Update-Database

        public AddressBookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AddressBookEntity> AddressBookTable { get; set; }
    }
}
