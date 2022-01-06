namespace Hogwarts.Infrastructure.Data
{
    using Hogwarts.Core.EF;
    using Hogwarts.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Reflection;

    public class HogwartsContext : AuditableContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<House> Houses { get; set; }

        public HogwartsContext(DbContextOptions<HogwartsContext> options, Assembly[] assemblies)
            : base(options, assemblies)
        {

        }
        public HogwartsContext(DbContextOptions<HogwartsContext> options)
           : base(options, new Assembly[] { typeof(HogwartsContext).GetTypeInfo().Assembly })
        {
        }

    }
}
