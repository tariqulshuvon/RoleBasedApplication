using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBased.BackEnd.Controllers.Base;
using RoleBased.Core.CQRS.Rolebased.Command.Login;
using RoleBased.Core.CQRS.Rolebased.Command.Student;
using RoleBased.Core.CQRS.Rolebased.Query.Login;
using RoleBased.Core.CQRS.Rolebased.Query.Student;
using RoleBased.Service.Model;

namespace RoleBased.BackEnd.Controllers;


public class LoginDbController : APIControllerBase
{

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("RegNo:string")]
    public async Task<ActionResult<VMLoginDb>> GetLoginDbById(string RegNo)
    {
        return await HandleQueryAsync(new GetAllLoginByIdQuery(RegNo));
    }
    [HttpGet]
    public async Task<ActionResult<VMLoginDb>> GetAllLoginDb()
    {
        return await HandleQueryAsync(new GetAllLoginQuery());
    }
    [HttpPost]

    public async Task<ActionResult<VMLoginDb>> CreateLoginDb(VMLoginDb login)
    {
        return await HandleCommandAsync(new CreateLoginCommand(login));
    }


    [HttpPut("RegNo:string")]
    public async Task<ActionResult<VMLoginDb>> UpdateLoginDb(string RegNo, VMLoginDb login)
    {
        return await HandleCommandAsync(new UpdateLoginCommand(RegNo, login));
    }


    [HttpDelete("RegNo:string")]
    public async Task<ActionResult<VMLoginDb>> DeleteLoginDb(string RegNo)
    {
        return await HandleCommandAsync(new DeleteLoginCommand(RegNo));
    }

}
