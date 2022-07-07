using Microsoft.EntityFrameworkCore;
using OrganizationManagementTool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManagementTool.API.Models
{
    public class OrganizationManagementContext : DbContext
    {
        public OrganizationManagementContext(DbContextOptions<OrganizationManagementContext> options):base(options)
        {

        }
        public DbSet<FacultyModel> FacultyTbl { get; set; }
        public DbSet<DepartmentsModel> DepartmentTbl { get; set; }
    }
}
