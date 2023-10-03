using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Query.Student;

public record GetAllStudentInfoQuery() : IRequest<QueryResult<IEnumerable<VMStudentInfo>>>;

public class GetAllEmployeeQueryHandeler : IRequestHandler<GetAllStudentInfoQuery, QueryResult<IEnumerable<VMStudentInfo>>>
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    public GetAllEmployeeQueryHandeler(IStudentInfoRepository studentInfoRepository)
    {
        _studentInfoRepository = studentInfoRepository;
    }
    public async Task<QueryResult<IEnumerable<VMStudentInfo>>> Handle(GetAllStudentInfoQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentInfoRepository.GetAllAsync();
        return student switch
        {
            null => new QueryResult<IEnumerable<VMStudentInfo>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMStudentInfo>>(student, QueryResultTypeEnum.Success)
        };
    }
}
