//using Dapper;
using Microsoft.EntityFrameworkCore;
using OrganizationManagementTool.API.Interfaces;
using OrganizationManagementTool.API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationManagementTool.API.Repositories
{
    public class OrganizationManagementRepository : IOrganizationManagementRepository
    {
        private readonly OrganizationManagementContext _Db;
        public OrganizationManagementRepository(OrganizationManagementContext Db)
        {
            _Db = Db;
        }

        public async Task<List<FacultyModel>> GetAllFacultyList()
        {
            var temp = _Db.FacultyTbl.Include(d => d.Department).ToList();
            return temp;
        }

        public Task<List<FacultyModel>> GetAllFacultyList(string temp)
        {
            var factlist1 = _Db.FacultyTbl.Include(d => d.Department).AsNoTracking();
            var factlist = from FT in _Db.FacultyTbl
                           join DT in _Db.DepartmentTbl
                           on FT.DeptId equals DT.Id
                           into Dep
                           from DT in Dep.DefaultIfEmpty()

                           select new FacultyModel
                           {
                               Id = FT.Id,
                               Name = FT.Name,
                               Mobile = FT.Mobile,
                               Email = FT.Email,
                               Age = FT.Age,
                               Gender = FT.Gender,
                               DeptId = FT.DeptId,
                               DeptName = DT == null ? "" : DT.DeptName
                           };

            if (!String.IsNullOrEmpty(temp))
            {
                factlist = factlist.Where(x => x.Name.Contains(temp) || x.Mobile.Contains(temp) || x.Email.Contains(temp) || x.Age.ToString().Contains(temp) || x.Gender.Contains(temp) || x.DeptName.Contains(temp));
            }
            return factlist.ToListAsync();
        }

        

        public async Task<FacultyModel> GetFacultyDtls(int id)
        {
            try
            {
                FacultyModel fact1 = _Db.FacultyTbl.Where(a => a.Id == id).SingleOrDefault();
                var temp = _Db.FacultyTbl.Find(id);

                return new FacultyModel
                    {
                        Id = temp.Id,
                        Name = temp.Name,
                        Mobile = temp.Mobile,
                        Email = temp.Email,
                        Age = temp.Age,
                        Gender = temp.Gender,
                        DeptId = temp.DeptId,
                        DeptName = temp == null ? "" : temp.DeptName
                    };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<DepartmentsModel>> GetAllDepartments()
        {
            List<DepartmentsModel> deptList = new List<DepartmentsModel>();
            deptList = _Db.DepartmentTbl.ToList();
            deptList.Insert(0, new DepartmentsModel { Id = 0, DeptName = "Please Select" });
            return deptList;
        }

        public async Task<ResultDto> AddEditFaculty(FacultyModel objFact)
        {
            try
            {
                if (objFact.Id == 0)
                {
                    _Db.FacultyTbl.Add(objFact);
                    _Db.SaveChanges();
                }
                else
                {
                    _Db.Entry(objFact).State = EntityState.Modified;
                    _Db.SaveChanges();
                }
                return new ResultDto()
                {
                    Result = true,
                    ResultMessage = "Success",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultDto> DeleteFaculty(int id)
        {
            try
            {
                //FacultyModel fact1 = _Db.FacultyTbl.Where(a => a.Id == id).SingleOrDefault();
                var fact = _Db.FacultyTbl.Find(id);
                if (fact != null)
                {
                    _Db.FacultyTbl.Remove(fact);
                    _Db.SaveChanges();
                }
                return new ResultDto()
                {
                    Result = true,
                    ResultMessage = "Successful",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
