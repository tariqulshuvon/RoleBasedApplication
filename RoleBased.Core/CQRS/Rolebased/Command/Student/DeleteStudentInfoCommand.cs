using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Command.Student;


public record DeleteStudentInfoCommand(string RegNo) : IRequest<CommandResult<VMStudentInfo>>;

public class DeleteStudentInfoCommandHandler : IRequestHandler<DeleteStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    private readonly IMapper _mapper;
    public DeleteStudentInfoCommandHandler(IStudentInfoRepository studentInfoRepository, IMapper mapper)
    {
        _studentInfoRepository = studentInfoRepository;
        _mapper = mapper;
    }
    public async Task<CommandResult<VMStudentInfo>> Handle(DeleteStudentInfoCommand request, CancellationToken cancellationToken)
    {

        var result = await _studentInfoRepository.DeleteAsync(request.RegNo);
        return result switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMStudentInfo>(result, CommandResultTypeEnum.Success)
        };
    }
}

