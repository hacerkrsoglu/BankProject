using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenderService
    {
        void Add(Gender gender);
        void Update(Gender gender);
        void Delete(Gender gender);
        Gender GetById(int id);
        List<Gender> GetAll();
    }
}
