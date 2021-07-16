using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PracticeApp.DAL.Entities;
using PracticeApp.DAL.Interfaces;

namespace PracticeApp.DAL.Repositories
{
    public class UsersRepository : IRepository<User, int>
    {
        IDbConnection db;
        public UsersRepository(IDbConnection context)
        {
            db = context;
        }

        public void Create(User entity)
        {
            db.Query("INSERT INTO Users VALUES (@firstName, @lasttName, @isBlocked)", 
                new 
                { 
                    firstName = entity.FirstName,
                    lasttName = entity.LasttName,
                    isBlocked = entity.IsBlocked
                });
        }

        public void Delete(int id)
        {
            db.Query("DELETE Users WHERE id = @id", new { id = id });
        }

        public User Get(int id)
        {
            return db.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE id = @id",
                    new
                    {
                        id = id
                    });           
        }

        public List<User> GetAll()
        {
            return db.Query<User>("SELECT * FROM Users").ToList();
        }

        public void BlockUser(int id)
        {
            db.Query<User>("UPDATE Users SET IsBlocked = 1 WHERE id = @id",
                    new
                    {
                        id = id
                    });
        }
    }
}
