using MUSACA.Data;
using MUSACA.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MUSACA.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserById(string username, string password)
        {
            var hashedPassword = this.Hash(password);
            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            return user.Id;
        }

        public bool EmailExists(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public void Register(string username, string password, string email)
        {
            var hashedPassword = this.Hash(password);

            var user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
