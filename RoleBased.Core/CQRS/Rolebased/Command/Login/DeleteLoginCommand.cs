using AutoMapper;
using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Command.Login;


public record DeleteLoginCommand(string RegNo) : IRequest<CommandResult<VMLoginDb>>;

public class DeleteLoginCommandHandler : IRequestHandler<DeleteLoginCommand, CommandResult<VMLoginDb>>
{
    private readonly ILoginDbRepository _loginRepository;
    public DeleteLoginCommandHandler(ILoginDbRepository loginDbRepository)
    {
        _loginRepository = loginDbRepository;
    }
    public async Task<CommandResult<VMLoginDb>> Handle(DeleteLoginCommand request, CancellationToken cancellationToken)
    {

        var result = await _loginRepository.DeleteAsync(request.RegNo);
        return result switch
        {
            null => new CommandResult<VMLoginDb>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMLoginDb>(result, CommandResultTypeEnum.Success)
        };
    }
}

