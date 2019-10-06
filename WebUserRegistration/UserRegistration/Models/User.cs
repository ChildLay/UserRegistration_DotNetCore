using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class User
    {
   
        public int Id { get; set; }
       
        public string Name { get; set; }

    
        public string Email { get; set; }

   
        public string Gender { get; set; }


       
        public string RegisteredDate { get; set; }

      
        public string EventDate { get; set; }

    
        public string AdditionalRequest { get; set; }

    }
}
