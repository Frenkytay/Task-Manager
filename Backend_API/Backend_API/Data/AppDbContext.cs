﻿using Backend_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet <User> Users { get; set; }
        public DbSet <Category> Categories { get; set; }
    }
}
