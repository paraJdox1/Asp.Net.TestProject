﻿using Microsoft.EntityFrameworkCore;
using ModalCRUD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // This is an empty constructor, but the parameter is needed for dependency injection
        }

        public DbSet<Employee> Employee { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
    }
}
