using Dev.Ikea.DAL.Common.Enums;
using Dev.Ikea.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Presistence.Data.Configurations.Employees
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(E => E.Address)
                .HasColumnType("varchar(max)");

            builder.Property(E => E.Salary)
                .HasColumnType("decimal(8,2)");

            builder.Property(E => E.Gender)
                .HasConversion(

                    (E) => E.ToString(),
                
                    (E) => (Gender) Enum.Parse(typeof(Gender) , E)
                );

            builder.Property(E => E.EmployeeType)
                .HasConversion(
                
                    (E) => E.ToString(),

                    (E) => (EmployeeType) Enum.Parse(typeof(EmployeeType), E)
                );

            builder.Property(E => E.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
