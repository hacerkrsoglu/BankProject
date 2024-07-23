using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //
        IDataResult<User> GetById(int userid);//tek başına bir kullanıcı döndürür. 
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<UserDetailDto> GetUserDetailsById(int id);

        IDataResult<List<User>> GetAll();
        IDataResult<int> Login(string email, string password);
        IResult Register(UserToRegister userToRegister);
        IResult Add(UserToAdd user);
        IDataResult< User >UpdateUser(UserToUpdate userToUpdate);
    }
}
