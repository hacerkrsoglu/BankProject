﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        UserDetailDto GetDetailById(int id);
        List<UserDetailDto> GetUserDetails();
        
        int Insert(User user);
        User GetUserByMail(string mail);
        bool IsCustomerNoExists(string customerNo);
        
        User GetUserById(int userId); // Kullanıcıyı ID'ye göre getiren metod

    }
}
