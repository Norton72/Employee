using System.Collections.Generic;
using Employee.Models;

namespace Employee.Interfeices
{
    public interface IUserDao
    {
        List<UserModel> Get();
        int Save(UserModel user);
        void Update(UserModel user);
        void Delete(int id);
        UserModel GetById(int id);
        List<UserModel> GetByCompanyId(int id);
    }
}