using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ControlSystem.Model;
using Microsoft.Extensions.Configuration;

namespace ControlSystemServer.Services
{
    public class UserService : IUserService
    {
        private string _connectionString;
        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public bool Check(string login, string passwordSalt)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select Login,Password from Users with(nolock) where Login=@Login", connection);
                command.Parameters.AddWithValue("Login", login);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var pwd = reader.GetString(1);
                        return pwd == passwordSalt;
                    }
                    else
                        return false;
                }
                return false;
            }
        }

        public User GetUser(Guid id)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select ID, Name, Role from users with(nolock) where ID=@ID", connection);
                command.Parameters.AddWithValue("ID", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User()                        
                        {
                            ID = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Role = (Role)reader.GetInt32(2)
                        };
                    }
                }
            }
            return user;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select ID, Name, Role from Users with(nolock)", connection);
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var user = new User
                        {
                            ID = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Role = (Role)reader.GetInt32(2)
                        };                        
                        users.Add(user);
                    }
                }
            }               
            return users;
        }

        public void CreateUser(User user)
        {
            if (user.ID == Guid.Empty)
                user.ID = Guid.NewGuid();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var command = new SqlCommand("Insert into Users (ID, Name, Password, Role) values(@ID,@Name,@Password,@Role)", connection, transaction);
                command.Parameters.AddWithValue("ID", user.ID);
                command.Parameters.AddWithValue("Name", user.Name);
                command.Parameters.AddWithValue("Password", user.Password);
                command.Parameters.AddWithValue("Role", user.Role);
               
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public void ChangeUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var command = new SqlCommand("Update Users set Name=@Name, Role=@Role where ID=@ID", connection, transaction);
                command.Parameters.AddWithValue("ID", user.ID);
                command.Parameters.AddWithValue("Name", user.Name);
                command.Parameters.AddWithValue("Role", user.Role);

                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public void DeleteUser(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var command = new SqlCommand("Delete from Users where ID=@ID", connection, transaction);
                command.Parameters.AddWithValue("ID", userId);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public User GetUser(string login)
        {
            User user = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select ID, Name, Role from users with(nolock) where Login=@Login", connection);
                command.Parameters.AddWithValue("Login", login);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            ID = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Role = (Role)reader.GetInt32(2)
                        };
                    }
                }
            }
            return user;
        }
    }
}
