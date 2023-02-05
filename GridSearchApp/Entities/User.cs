using GridSearchApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearchApp.Entities
{
    public class User
    {
        private string? _firstname;
        private string? _lastname;


        public string? Firstname
        { 
            get => _firstname?.CamelCase();
            set
            {
                _firstname = value;
            }
        }
        public string? Lastname 
        {
            get => _lastname?.CamelCase();
            set
            {
                _lastname = value;
            }
        }

        public string? Username { get; set; }
        public string? Gender { get; set; }
    }
}
