using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FogachoWebHeladeria.Models;

namespace FogachoWebHeladeria
{
    public class Data : DbContext
    {
        public Data (DbContextOptions<Data> options)
            : base(options)
        {
        }

        public DbSet<FogachoWebHeladeria.Models.AF_Helado> AF_Helado { get; set; } = default!;
    }
}
