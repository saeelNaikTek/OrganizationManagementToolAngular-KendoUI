using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizationManagementTool.API.Interfaces;
using OrganizationManagementTool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IOrganizationManagementRepository _Db;

        public FacultyController(IOrganizationManagementRepository Db)
        {
            _Db = Db;
        }

        [HttpGet]
        [Route("GetAllFaculty")]
        public async Task<IActionResult> GetAllFaculty()
        {
            return Ok(await _Db.GetAllFacultyList());
        }

        [HttpGet]
        [Route("GetFaculty/{temp}")]
        public async Task<IActionResult> GetFaculty(string temp)
        {
            return Ok(await _Db.GetAllFacultyList(temp));
        }

        [HttpGet]
        [Route("GetFacultyDtls/{id}")]
        public async Task<IActionResult> GetFacultyDtls(int id)
        {
            return Ok(await _Db.GetFacultyDtls(id));
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _Db.GetAllDepartments());
        }

        [HttpPost]
        [Route("AddEditFaculty")]
        public async Task<IActionResult> AddEditFaculty(FacultyModel objFact)
        {
            return Ok(_Db.AddEditFaculty(objFact));
        }

        [HttpGet]
        [Route("DeleteFaculty/{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            return Ok(_Db.DeleteFaculty(id));
        }
    }
}
