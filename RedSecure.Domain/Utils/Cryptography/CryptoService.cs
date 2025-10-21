using System.Security.Cryptography;
using System.Text;

namespace RedSecure.Domain.Utils.Cryptography
{
    public class CryptoService
    {
        /// <summary>
        /// Hash password using SHA-256 with salt
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <param name="salt">Salt value (optional, will generate if not provided)</param>
        /// <returns>Tuple with hashed password and salt</returns>
        public static (string HashedPassword, string Salt) HashPassword(string password, string? salt = null)
        {
            // Generate salt if not provided
            if (string.IsNullOrEmpty(salt))
            {
                salt = GenerateSalt();
            }

            // Combine password and salt
            string passwordWithSalt = password + salt;

            // Hash using SHA-256
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(passwordWithSalt));
            string hashedPassword = Convert.ToBase64String(bytes);
            hashedPassword = hashedPassword.Replace('A', '@').Replace('a', '@');

            return (hashedPassword, salt);
        }

        /// <summary>
        /// Hash username using SHA-256
        /// </summary>
        /// <param name="username">Plain text username</param>
        /// <returns>Hashed username</returns>
        public static string HashUsername(string username)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(username));
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Generate a random salt
        /// </summary>
        /// <param name="length">Salt length (default: 32)</param>
        /// <returns>Random salt string</returns>
        public static string GenerateSalt(int length = 32)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var salt = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                salt.Append(chars[random.Next(chars.Length)]);
            }

            return salt.ToString();
        }

        /// <summary>
        /// Generate secret code for sign up
        /// </summary>
        /// <param name="length">Code length (default: 32)</param>
        /// <returns>Random secret code</returns>
        public static string GenerateSecretCode(int length = 32)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var code = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                code.Append(chars[random.Next(chars.Length)]);
            }

            return code.ToString();
        }

        /// <summary>
        /// Verify password against hash
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <param name="hashedPassword">Stored hashed password</param>
        /// <param name="salt">Salt used for hashing</param>
        /// <returns>True if password matches</returns>
        public static bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            var (computedHash, _) = HashPassword(password, salt);
            return computedHash.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Validate email format
        /// </summary>
        /// <param name="email">Email to validate</param>
        /// <returns>True if email is valid</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validate password strength
        /// </summary>
        /// <param name="password">Password to validate</param>
        /// <returns>Validation result with message</returns>
        public static (bool IsValid, string Message) ValidatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return (false, "Password cannot be empty");

            if (password.Length < 6)
                return (false, "Password must be at least 6 characters long");

            if (password.Length > 128)
                return (false, "Password must be less than 128 characters");

            // Check for at least one uppercase, lowercase, number, and special character
            bool hasUppercase = password.Any(char.IsUpper);
            bool hasLowercase = password.Any(char.IsLower);
            bool hasNumber = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            if (!hasUppercase || !hasLowercase || !hasNumber || !hasSpecialChar)
            {
                return (false, "Password must contain at least one uppercase letter, lowercase letter, number, and special character");
            }

            return (true, "Password is strong");
        }
    }
}


