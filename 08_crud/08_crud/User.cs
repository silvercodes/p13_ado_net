using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_crud
{
    internal class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id} {Email} {Password} {Age}";
        }
    }
}
