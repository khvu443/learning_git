using Domain.Entities;
using Domain.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            ConfigureUsersTable(builder);
        }

        private void ConfigureUsersTable(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(role => role.RoleId);
            builder.Property(role => role.RoleName)
                .HasMaxLength(50);


            //For testing
            builder.HasData(new Roles {RoleId = 1,RoleName  = "Manager" });
            builder.HasData(new Roles { RoleId = 2, RoleName = "Leader" });
            builder.HasData(new Roles { RoleId = 3, RoleName = "Employee" });

        }
    }
}
