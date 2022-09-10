using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioLoldesign.API.Data.Context
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options)
        {
        }

        public DbSet<Plans> Plans { get; set; }
        public DbSet<Rates> Rates { get; set; }
    }
}