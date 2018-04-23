﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domasno_2.Models;

namespace Domasno_2.Models
{
    public class Domasno_2Context : DbContext
    {
        public Domasno_2Context (DbContextOptions<Domasno_2Context> options)
            : base(options)
        {
        }

        public DbSet<Domasno_2.Models.Address> Address { get; set; }

        public DbSet<Domasno_2.Models.Customer> Customer { get; set; }
    }
}
