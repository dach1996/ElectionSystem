﻿using Dach.ElectionSystem.Models.Persitence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.DBContext
{
    public class WebApiDbContext : DbContext
    {
        private readonly ILogger<WebApiDbContext> logger;

        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Group> Group { get; set; }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options,ILogger<WebApiDbContext> logger) : base(options)
        {
            this.logger = logger;
                
           
        }



    
    }
}
