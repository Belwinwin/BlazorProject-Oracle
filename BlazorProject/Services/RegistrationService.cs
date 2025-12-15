using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BlazorProject.Services
{
    public interface IRegistrationService
    {
        Task<bool> RegisterUserAsync(string userId, string userName, string email, string password);

        Task<RegistrationDetails?> GetUserAsync(string email, string password);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly OracleDbContext3 _context;

        public RegistrationService(OracleDbContext3 context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(string userId, string userName, string email, string password)
        {
            var existingUser = await _context.RegistrationDetails
                .FirstOrDefaultAsync(r => r.Email == email || r.UserId == userId);
            
            if (existingUser != null)
                return false;

            var registration = new RegistrationDetails
            {
                UserId = userId,
                UserName = userName,
                Email = email,
                PasswordHash = HashPassword(password)
            };

            _context.RegistrationDetails.Add(registration);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<RegistrationDetails?> GetUserAsync(string email, string password)
        {
            var user = await _context.RegistrationDetails
                .FirstOrDefaultAsync(r => r.Email == email);
            
            if (user != null && VerifyPassword(password, user.PasswordHash))
                return user;
            
            return null;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}