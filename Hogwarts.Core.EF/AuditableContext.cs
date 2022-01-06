namespace Hogwarts.Core.EF
{
    using Hogwarts.Core.Model;
    using Hogwarts.Core.Validator;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Reflection;

    public class AuditableContext : DbContext
    {
        Assembly[] assemblies;

        public AuditableContext(DbContextOptions options, Assembly[] assemblies)
            : base(options)
        {
            this.assemblies = assemblies;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                AuditEntities();

                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ValidationException(null, ex.Message);
            }
        }

        protected void AuditEntities()
        {
            // Get the authenticated user name 
            string email = string.Empty;


            // Get current date & time
            DateTime now = DateTime.Now;

            // For every changed entity marked as IAditable set the values for the audit properties
            foreach (EntityEntry<IAuditableEntity> entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                // If the entity was added.
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedBy").CurrentValue = email;
                    entry.Property("CreatedAt").CurrentValue = now;
                }
                else if (entry.State == EntityState.Modified) // If the entity was updated
                {
                    entry.Property("UpdatedBy").CurrentValue = email;
                    entry.Property("UpdatedAt").CurrentValue = now;
                }
            }
        }

        protected void ValidateEntities()
        {
            foreach (EntityEntry<IValidatable> entry in ChangeTracker.Entries<IValidatable>())
            {
                entry.Entity.AssertValidation();
            }
        }
    }
}
