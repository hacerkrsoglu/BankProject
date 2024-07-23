using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.User
{
    public class UserDetailDto : IDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }



    }
}
