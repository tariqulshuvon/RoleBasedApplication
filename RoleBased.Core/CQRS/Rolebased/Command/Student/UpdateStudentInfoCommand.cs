using AutoMapper;
using FluentValidation;
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

namespace RoleBased.Core.CQRS.Rolebased.Command.Student;

public record UpdateStudentInfoCommand(string RegNo, VMStudentInfo student) : IRequest<CommandResult<VMStudentInfo>>;
public class UpdateStudentInfoCommandHandler : IRequestHandler<UpdateStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _studentInfoResult;
    private readonly IMapper _mapper;
    public UpdateStudentInfoCommandHandler(IStudentInfoRepository studentInfoRepository, IMapper mapper)
    {
        _studentInfoResult = studentInfoRepository;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudentInfo>> Handle(UpdateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<StudentInfo>(request.student);
        var result = await _studentInfoResult.UpdateAsync(request.RegNo, data);
        return result switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMStudentInfo>(result, CommandResultTypeEnum.Success)
        };
    }
}
