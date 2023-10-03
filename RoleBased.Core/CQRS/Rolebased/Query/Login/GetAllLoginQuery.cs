using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.Rolebased.Query.Login;


public record GetAllLoginQuery() : IRequest<QueryResult<IEnumerable<VMLoginDb>>>;

public class GetAllLoginQueryHandeler : IRequestHandler<GetAllLoginQuery, QueryResult<IEnumerable<VMLoginDb>>>
{
    private readonly ILoginDbRepository _loginDbRepository;
    public GetAllLoginQueryHandeler(ILoginDbRepository loginDbRepository)
    {
        _loginDbRepository = loginDbRepository;
    }
    public async Task<QueryResult<IEnumerable<VMLoginDb>>> Handle(GetAllLoginQuery request, CancellationToken cancellationToken)
    {
        var login = await _loginDbRepository.GetAllAsync();
        return login switch
        {
            null => new QueryResult<IEnumerable<VMLoginDb>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMLoginDb>>(login, QueryResultTypeEnum.Success)
        };
    }
}

