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

namespace RoleBased.Core.CQRS.Rolebased.Query.Login;


public record GetAllLoginByIdQuery : IRequest<QueryResult<VMLoginDb>>
{
    [JsonConstructor]
    public GetAllLoginByIdQuery(string regNo)
    {
        RegNo = regNo;
    }
    public string RegNo { get; set; }
    public class GetAllLoginByIdQueryHandler : IRequestHandler<GetAllLoginByIdQuery, QueryResult<VMLoginDb>>
    {
        private readonly ILoginDbRepository _loginDbRepository;
        public GetAllLoginByIdQueryHandler(ILoginDbRepository loginDbRepository)
        {
            _loginDbRepository = loginDbRepository;
        }
        public async Task<QueryResult<VMLoginDb>> Handle(GetAllLoginByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _loginDbRepository.GetByIdAsync(request.RegNo);
            return result switch
            {
                null => new QueryResult<VMLoginDb>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMLoginDb>(result, QueryResultTypeEnum.Success)
            };
        }
    }
}
