using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Service.Model;

public class VMStudentInfo : IVM
{
    public string RegNo { get; set; }
    public string StudentName { get; set; }
    public string DOB { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
