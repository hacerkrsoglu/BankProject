using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PostgreSqlContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {
                var result = from u in context.Users
                             join g in context.Genders on u.GenderId equals g.Id
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 GenderName = g.GenderName,
                                 IdentityNumber = u.IdentityNumber,
                                 DateOfBirth = u.DateOfBirth,
                                 
                             };
                return result.ToList();
            }
        }

        public User GetUserById(int userId)
        {
            using (PostgreSqlContext context = new PostgreSqlContext()) // Veritabanı bağlantınızın context'i
            {
                return context.Users.FirstOrDefault(u => u.Id == userId);
            }
        }

        public User GetUserByMail(string mail)
        {
            using (PostgreSqlContext context = new())
            {
                return context.Users.FirstOrDefault(x => x.Email == mail);

            }
        }

        public int Insert(User user)
        {
            using (PostgreSqlContext context = new())
            {
                var addedUser = context.Users.Add(user);
                context.SaveChanges();
       
                return addedUser.Entity.Id;


            }
        }

 
        

        public UserDetailDto GetDetailById(int id)
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {

                var result = context.Users
                    .Include(x => x.Gender)
                    .SingleOrDefault(x => x.Id == id);

                return new()
                {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    DateOfBirth = result.DateOfBirth,
                    GenderName = result.Gender.GenderName,
                    IdentityNumber = result.IdentityNumber,
                };


            }


        }

        public bool IsCustomerNoExists(string customerNo)
        {
            using (PostgreSqlContext context = new PostgreSqlContext())
            {
                //any metodu belirtilen koşula göre en az bir öğe var mı diye bakar
                return context.Users.Any(u => u.CustomerNo == customerNo);
            }
        }
    }
}
