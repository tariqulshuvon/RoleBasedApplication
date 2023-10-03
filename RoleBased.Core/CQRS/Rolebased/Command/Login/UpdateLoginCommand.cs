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


public record UpdateLoginCommand(string RegNo, VMLoginDb login) : IRequest<CommandResult<VMLoginDb>>;
public class UpdateLoginCommandHandler : IRequestHandler<UpdateLoginCommand, CommandResult<VMLoginDb>>
{
    private readonly ILoginDbRepository _loginDbRepository;
    private readonly IMapper _mapper;
    public UpdateLoginCommandHandler(ILoginDbRepository loginDbRepository, IMapper mapper)
    {
        _loginDbRepository = loginDbRepository;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMLoginDb>> Handle(UpdateLoginCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<LoginDB>(request.login);
        var result = await _loginDbRepository.UpdateAsync(request.RegNo, data);
        return result switch
        {
            null => new CommandResult<VMLoginDb>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMLoginDb>(result, CommandResultTypeEnum.Success)
        };
    }
}
