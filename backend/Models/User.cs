using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class User
    {
        public Guid Id {get;init;}
        public String UserName {get; init;}
        public String Password {get;init;}
    }
}