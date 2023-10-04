using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model;

public class LoginDB :IEntity
{
    [Key]
    public string RegNo { get; set; }
    public string Password { get; set; }    
    public string Role { get; set; }
}
