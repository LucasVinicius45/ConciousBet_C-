using BCrypt.Net;

namespace ConsciousbetApp.Utils
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Gera o hash da senha usando BCrypt
        /// </summary>
        /// <param name="password">Senha em texto plano</param>
        /// <returns>Hash da senha</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        /// <summary>
        /// Verifica se a senha informada corresponde ao hash armazenado
        /// </summary>
        /// <param name="password">Senha em texto plano</param>
        /// <param name="hashedPassword">Hash armazenado no banco</param>
        /// <returns>True se a senha estiver correta</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}