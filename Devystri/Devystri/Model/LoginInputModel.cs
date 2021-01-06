using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Devystri.Model
{
    public class LoginInputModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email{ get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Passwod { get; set; }
    }
}
