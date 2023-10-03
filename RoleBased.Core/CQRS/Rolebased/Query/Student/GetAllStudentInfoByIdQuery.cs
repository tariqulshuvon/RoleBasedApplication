using FluentValidation;
using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Query.Student;


public record GetAllStudentInfoByIdQuery : IRequest<QueryResult<VMStudentInfo>>
{
    [JsonConstructor]
    public GetAllStudentInfoByIdQuery(string regNo)
    {
        RegNo = regNo;
    }
    public string RegNo { get; set; }
    public class GetAllStudentInfoByIdQueryHandler : IRequestHandler<GetAllStudentInfoByIdQuery, QueryResult<VMStudentInfo>>
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        public GetAllStudentInfoByIdQueryHandler(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }
        public async Task<QueryResult<VMStudentInfo>> Handle(GetAllStudentInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentInfoRepository.GetByIdAsync(request.RegNo);
            return student switch
            {
                null => new QueryResult<VMStudentInfo>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMStudentInfo>(student, QueryResultTypeEnum.Success)
            };
        }
    }
}
