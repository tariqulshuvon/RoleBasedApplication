using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Command.Student;


public record CreateStudentInfoCommand(VMStudentInfo studentInfo) : IRequest<CommandResult<VMStudentInfo>>;

public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    private readonly IMapper _mapper;

    public CreateStudentInfoCommandHandler(IStudentInfoRepository countryRepository, IMapper mapper)
    {
        _studentInfoRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudentInfo>> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
    {

        var result = _mapper.Map<StudentInfo>(request.studentInfo);
        var studentInfo = await _studentInfoRepository.InsertAsync(result);
        return studentInfo switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMStudentInfo>(studentInfo, CommandResultTypeEnum.Success)
        };

    }
}

