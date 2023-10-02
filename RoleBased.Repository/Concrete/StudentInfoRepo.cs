using AutoMapper;
using RoleBased.Infrastructure.Persistence;
using RoleBased.Model;
using RoleBased.Repository.Concrete.Base;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Repository.Concrete;

public class StudentInfoRepo : RepositoryBase<StudentInfo, VMStudentInfo, string>, IStudentInfoRepository
{
    public StudentInfoRepo(RoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
