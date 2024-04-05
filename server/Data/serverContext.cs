using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlexibleJobs.Models;

namespace FlexibleJobs.Data
{
    public class FlexibleJobsContext : DbContext
    {
        public FlexibleJobsContext(DbContextOptions<FlexibleJobsContext> options)
            : base(options)
        {
        }

        public DbSet<FlexibleJobs.Models.User> User { get; set; } = default!;
    }
}
