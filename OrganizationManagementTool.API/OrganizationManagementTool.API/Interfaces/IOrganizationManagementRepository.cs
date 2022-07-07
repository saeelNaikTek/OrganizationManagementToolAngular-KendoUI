using OrganizationManagementTool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationManagementTool.API.Interfaces
{
    public interface IOrganizationManagementRepository
    {
        public Task<List<FacultyModel>> GetAllFacultyList();
        public Task<List<FacultyModel>> GetAllFacultyList(string temp);
        public Task<FacultyModel> GetFacultyDtls(int id);
        public Task<List<DepartmentsModel>> GetAllDepartments();
        public Task<ResultDto> AddEditFaculty(FacultyModel objFact);
        public Task<ResultDto> DeleteFaculty(int id);
        
    }
}
