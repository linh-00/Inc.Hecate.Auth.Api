using Inc.Hecate.Auth.Shared.Extensions;
using Inc.Hecate.Auth.Shared.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Shared.Utils
{
    public class Encryptor : IEncryptor
    {
        private readonly string key;

        public Encryptor(IConfiguration configuration)
        {
            var appConfig = configuration.LoadConfiguration();
            key = appConfig.Authentication.Key;
        }


        public string Encrypt(string plainText)
        {
            try
            {
                string EncryptionKey = key;
                byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        plainText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                // Torna a string URL-safe
                plainText = plainText.Replace("+", "-").Replace("/", "_").Replace("=", "");
                return plainText;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criptografar", ex);
            }
        }

        public string Decrypt(string encryptedText)
        {
            try
            {
                string EncryptionKey = key;
                // Reverte as alterações para a Base64 válida
                encryptedText = encryptedText.Replace("-", "+").Replace("_", "/");
                int mod4 = encryptedText.Length % 4;
                if (mod4 > 0)
                {
                    encryptedText += new string('=', 4 - mod4);
                }

                byte[] cipherBytes = Convert.FromBase64String(encryptedText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        encryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return encryptedText;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao descriptografar", ex);
            }
        }
    }
}
