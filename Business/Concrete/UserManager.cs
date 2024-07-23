using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public string FirstName { get; private set; }

        public IResult Add(UserToAdd userToAdd)
        {
            //business codes
            //kurallar buraya yazılır.
            //random sayı



            //var random = new Random();//random sayı üretmek için kullandım
            //string customerNo = random.Next(100000, 999999).ToString();
            ////veritabanında bu sayının olup olmadığını kontrol etmem lazım.
            //var isUnique = !_userDal.IsCustomerNoExists(customerNo);
            //if (isUnique == true)
            //{
            //    return new  Result(false,"Bu müşteri numarası var");

            //}

            var customerNo = Guid.NewGuid().ToString();

            User user = new()
            {
                FirstName = userToAdd.FirstName,
                LastName = userToAdd.LastName,
                Email = userToAdd.Email,
                GenderId = userToAdd.GenderId,
                DateOfBirth = userToAdd.DateOfBirth,
                Password = userToAdd.Password,
                IdentityNumber = userToAdd.IdentityNumber,
                CustomerNo = customerNo

            };

            _userDal.Add(user);


            return new SuccessResult(Messages.UserAdded);//bunu yapabilemem için constructor yapmam lazım
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>> (_userDal.GetAll(),"Kullanılar listelendi");
        }

        public IDataResult<User> GetById(int userid)
        {
            var user = _userDal.Get(u => u.Id == userid);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>("Kullanıcı bulunamadı");
        }
    

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            var userDetails = _userDal.GetUserDetails();
            return new SuccessDataResult<List<UserDetailDto>>(userDetails,  "Detaylar gösterildi");
        }

        public IDataResult<UserDetailDto> GetUserDetailsById(int id)
        {
            var userDetails = _userDal.GetDetailById(id);
            return new SuccessDataResult<UserDetailDto>(userDetails, "Id ye göre listelendi");

        }

        public IDataResult<int> Login(string email, string password)
        {
            var userToCheck = _userDal.GetUserByMail(email);

            if (userToCheck == null)
            {
                return new DataResult<int>(0,false, "Kullanıcı bulunamadı");
            }

            if (userToCheck.Password != password)
            {
                return new DataResult<int>(0,false, "Hatalı şifre." );

            }
            return new DataResult<int>(userToCheck.Id,true, "Login başarılı.");
        }




        public IResult Register(UserToRegister userToRegister)
        {
            try
            {
                // Email adresi ile kullanıcı kontrolü
                var userToCheck = _userDal.GetUserByMail(userToRegister.Email);
                if (userToCheck != null)
                {
                    return new ErrorResult("Kullanıcı zaten mevcut.");
                }

                // Yeni müşteri numarası oluşturma
                var customerNo = Guid.NewGuid().ToString();

                // Yeni kullanıcı ekleme
                var newUser = new User
                {
                    Email = userToRegister.Email,
                    Password = userToRegister.Password,
                    FirstName = userToRegister.FirstName,
                    LastName = userToRegister.LastName,
                    GenderId = userToRegister.GenderId,
                    IdentityNumber = userToRegister.IdentityNumber,
                    DateOfBirth = userToRegister.DateOfBirth,
                    CustomerNo = customerNo,
                };

                var insertResult = _userDal.Insert(newUser);

                if (insertResult <= 0)
                {
                    return new ErrorResult("Ekleme işlemi başarısız.");
                }

                return new SuccessResult("Kullanıcı kayıt başarılı.");
            }
            catch (Exception ex)
            {
                // Hata durumunda detaylı bilgi döndürme
                return new ErrorResult($"Kayıt sırasında bir hata oluştu: {ex.Message}");
            }
        }

        public IDataResult<User> UpdateUser(UserToUpdate userToUpdate)
        {
            var userUpdate = _userDal.GetUserById(userToUpdate.Id);//bu iddeki kullanıcıyı getirir


            if (userToUpdate == null)//kontrol eder bu kullanıcı var mı ? 
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }


            // Yeni e-posta adresinin başka bir kullanıcı tarafından kullanılıp kullanılmadığının kontrolü

            //if(userUpdate.Email != null && userUpdate.Id == userToUpdate.Id) 
            //{
            //    return new ErrorDataResult<User>("Kullanıcı zaten mevcut.");

            //}
            //üstteki gibi denedim en başta bu kullacının  e-posta adresinin değişip değişmediğini kontrol eder.

            //Passwordun eskisiyle aynı olup olmdığının kontrolü
            if (userToUpdate.Password == userUpdate.Password)
            {
                return new ErrorDataResult<User>("Önceki şifrenle aynı olamaz");
                
            }


            userUpdate.FirstName = userToUpdate.FirstName;
            userUpdate.LastName = userToUpdate.LastName;
            userUpdate.Password = userToUpdate.Password;

            userUpdate.Email = userToUpdate.Email;


            // Kullanıcıyı güncelle
            _userDal.Update(userUpdate);

            return new SuccessDataResult<User>(userUpdate, "Kullanıcı başarılı şekilde güncellendi");

        }


    }
}
