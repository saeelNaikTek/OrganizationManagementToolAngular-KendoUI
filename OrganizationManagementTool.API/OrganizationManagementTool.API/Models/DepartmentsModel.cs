using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManagementTool.API.Models
{
    public class DepartmentsModel
    {
        [Key]
        public int Id { get; set; }

        public string DeptName { get; set; }
    }
}
