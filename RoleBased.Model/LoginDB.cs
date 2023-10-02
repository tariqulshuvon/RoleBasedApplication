using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model;

public class LoginDB
{
    [MaxLength(10)]
    public string RegNo { get; set; }
    [MinLength(6)]
    [MaxLength(10)]
    public string Password { get; set; }    
    public string Role { get; set; }
}
