using AutoMapper;
using RoleBased.Model;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.Mapping;

public class MappingExtension : Profile
{
    public MappingExtension()
    {
        CreateMap<VMStudentInfo, StudentInfo>().ReverseMap();
        //.ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country != null ? x.Country.CountryName : " "))
        //.ForMember(x => x.StateName, x => x.MapFrom(x => x.State != null ? x.State.StateName : " "));
        CreateMap<VMLoginDb, LoginDB>().ReverseMap();
        //CreateMap<VMState, State>().ReverseMap()
        //    .ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country != null ? x.Country.CountryName : " "));
    }

}
