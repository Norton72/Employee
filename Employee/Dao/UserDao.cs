using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Employee.Dao.Query;
using Employee.Interfeices;
using Employee.Models;

namespace Employee.Dao
{
    public class UserDao : IUserDao
    {
        private readonly string _connection;

        public UserDao(string connection)
        {
            _connection = connection;
        }

        private IEnumerable<T> Query<T>(string query)
        {
            using IDbConnection db = new SqlConnection(_connection);
            return db.Query<T>(query);
        }
        
        private IEnumerable<T> Query<T>(string query, object param)
        {
            using IDbConnection db = new SqlConnection(_connection);
            return db.Query<T>(query, param);
        }
        
        private void Execute(string query, object param)
        {
            using IDbConnection db = new SqlConnection(_connection);
            db.Execute(query, param);
        }

        public List<UserModel> Get()
        {
            return Query<UserModel>(Resource.Get).ToList();
        }

        public int Save(UserModel user)
        {
            return Query<int>(Resource.Save, user).FirstOrDefault();
        }
        
        public void Update(UserModel user)
        {
            Execute(Resource.Update, user);
        }

        public void Delete(int id)
        {
            Execute(Resource.Delete, new {id});
        }
        
        public UserModel GetById(int id)
        {
            return Query<UserModel>(Resource.GetById, new {id}).FirstOrDefault();
        }
        
        public List<UserModel> GetByCompanyId(int id)
        {
            return Query<UserModel>(Resource.GetByCompanyId, new {id}).ToList();
        }
    }
}