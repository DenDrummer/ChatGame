using Domain.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public ushort Id { get; set; }
        [Required]
        [RegularExpression("^[a-z_]{4,12}$", ErrorMessageResourceName = "InvalidUserName", ErrorMessageResourceType = typeof(Resources))]
        public string UserName { get; set; }
    }
}
