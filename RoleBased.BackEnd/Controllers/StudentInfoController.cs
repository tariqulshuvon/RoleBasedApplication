using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBased.BackEnd.Controllers.Base;
using RoleBased.Core.CQRS.Rolebased.Command.Student;
using RoleBased.Core.CQRS.Rolebased.Query.Student;
using RoleBased.Service.Model;

namespace RoleBased.BackEnd.Controllers;


public class StudentInfoController : APIControllerBase
{

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("RegNo:string")]
    public async Task<ActionResult<VMStudentInfo>> GetStudentInfoById(string RegNo)
    {
        return await HandleQueryAsync(new GetAllStudentInfoByIdQuery(RegNo));
    }
    [HttpGet]
    public async Task<ActionResult<VMStudentInfo>> GetAllStudentInfo()
    {
        return await HandleQueryAsync(new GetAllStudentInfoQuery());
    }
    [HttpPost]

    public async Task<ActionResult<VMStudentInfo>> CreateStudent(VMStudentInfo student)
    {
        return await HandleCommandAsync(new CreateStudentInfoCommand(student));
    }


    [HttpPut("RegNo:string")]
    public async Task<ActionResult<VMStudentInfo>> UpdateCountry(string RegNo, VMStudentInfo student)
    {
        return await HandleCommandAsync(new UpdateStudentInfoCommand(RegNo, student));
    }


    [HttpDelete("RegNo:string")]
    public async Task<ActionResult<VMStudentInfo>> DeleteCountry(string RegNo)
    {
        return await HandleCommandAsync(new DeleteStudentInfoCommand(RegNo));
    }

}
