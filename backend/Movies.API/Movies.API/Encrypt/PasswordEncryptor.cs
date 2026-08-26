using System.Security.Cryptography;

namespace Movies.API.Encrypt
{
    public class PasswordEncryptor
    {
        public static string EncryptPassword(string password)
        {
            // ESSE CODIGO ABAIXO VAMOS APAGAR NA PRÓXIMA AULA! ESTA AÍ SOMENTE PARA REMOVER O ERRO
            byte[] hashBytes = new byte[48];
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {   
            return true;
        }
    }
}
