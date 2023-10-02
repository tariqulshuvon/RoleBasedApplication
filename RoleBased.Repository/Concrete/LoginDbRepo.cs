using AutoMapper;
using RoleBased.Infrastructure.Persistence;
using RoleBased.Model;
using RoleBased.Repository.Concrete.Base;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Repository.Concrete;

public class LoginDbRepo : RepositoryBase<LoginDB, VMLoginDb, string>, ILoginDbRepository
{
    public LoginDbRepo(RoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
