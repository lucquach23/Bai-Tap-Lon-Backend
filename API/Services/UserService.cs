using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        Account Authenticate(string username, string password);
        IEnumerable<Account> GetAll();
        Account GetById(int id);
    }


    public class UserService : IUserService
    {
        //public RegisterSubjectDBContext _context;

        //public UserService(RegisterSubjectDBContext context)
        //{
        //    _context = context;

        //}
        List<Account> _users;
        public List<Account> getList()
        {
            using (RegisterSubjectDBContext db=new RegisterSubjectDBContext())
            {
                return _users = db.Accounts.ToList();
            }                        
        }
       

        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, FirstName = "Đông", LastName = "Nguyễn Hữu", Username = "admin", Password = "admin", Role = Role.Admin },
        //    new User { Id = 2, FirstName = "Huệ", LastName = "Nguyễn Thị Thanh", Username = "gv01", Password = "gv01", Role = Role.Gv },
        //    new User { Id = 3, FirstName = "Thảo", LastName = "Nguyễn Diệu", Username = "sv01", Password = "sv01", Role = Role.Sv },

        //};


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Account Authenticate(string username, string password)
        {
            getList();
            var user = _users.SingleOrDefault(x => x.UserName == username && x.PassWord == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<Account> GetAll()
        {
            getList();
            return _users.WithoutPasswords();
        }

        public Account GetById(int id)
        {
            getList();
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user.WithoutPassword();
        }
    }
}