using AutoMapper;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Command.Login;


public record CreateLoginCommand(VMLoginDb loginDb) : IRequest<CommandResult<VMLoginDb>>;

public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, CommandResult<VMLoginDb>>
{
    private readonly ILoginDbRepository _loginDbRepo;
    private readonly IMapper _mapper;

    public CreateLoginCommandHandler(ILoginDbRepository loginDbRepo, IMapper mapper)
    {
        _loginDbRepo = loginDbRepo;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMLoginDb>> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
    {

        var result = _mapper.Map<LoginDB>(request.loginDb);
        var login = await _loginDbRepo.InsertAsync(result);
        return login switch
        {
            null => new CommandResult<VMLoginDb>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMLoginDb>(login, CommandResultTypeEnum.Success)
        };

    }

}

