using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace KClinic2._1.Model
{
    class Crypt
    {
        protected internal static string Encrypt_Password(string PasswordData)
        {
            if ((Operators.CompareString(PasswordData, null, TextCompare: false) == 0 || Operators.CompareString(PasswordData, string.Empty, TextCompare: false) == 0) ? true : false)
            {
                return PasswordData;
            }
            int num = 0;
            string text = string.Empty;
            checked
            {
                int num2 = PasswordData.Length - 1;
                int num3 = 0;
                while (true)
                {
                    int num4 = num3;
                    int num5 = num2;
                    if (num4 > num5)
                    {
                        break;
                    }
                    num += Strings.AscW(PasswordData.Substring(num3, 1));
                    num3++;
                }
                int num6 = unchecked(num % 128);
                int num7 = Convert.ToInt32((double)num / 128.0);
                if ((Operators.CompareString("", string.Empty, TextCompare: false) != 0 && "".IndexOf(Strings.ChrW(num6)) > -1) ? true : false)
                {
                    num6++;
                }
                if (num6 == 0)
                {
                    num6++;
                }
                if (Operators.CompareString(Conversions.ToString(Strings.ChrW(num6)), "'", TextCompare: false) == 0)
                {
                    num6++;
                }
                if ((Operators.CompareString("", string.Empty, TextCompare: false) != 0 && "".IndexOf(Strings.ChrW(num7)) > -1) ? true : false)
                {
                    num7++;
                }
                if (num7 == 0)
                {
                    num7++;
                }
                if (Operators.CompareString(Conversions.ToString(Strings.ChrW(num7)), "'", TextCompare: false) == 0)
                {
                    num7++;
                }
                int num8 = num6 + num7;
                int num9 = PasswordData.Length - 1;
                num3 = 0;
                while (true)
                {
                    int num10 = num3;
                    int num5 = num9;
                    if (num10 > num5)
                    {
                        break;
                    }
                    string text2 = Conversions.ToString(Strings.ChrW((Strings.AscW(PasswordData.Substring(num3, 1)) ^ num8) + num3));
                    text = ((Strings.AscW(text2) != 0) ? ((Operators.CompareString(text2, "'", TextCompare: false) != 0) ? (text + text2) : (text + "''")) : (text + PasswordData.Substring(num3, 1)));
                    num3++;
                }
                return Conversions.ToString(Strings.ChrW(num6)) + Conversions.ToString(Strings.ChrW(num7)) + text;
            }
        }
        protected internal static string Decrypt_Password(string PasswordData)
        {
            if ((Operators.CompareString(PasswordData, null, TextCompare: false) == 0 || Operators.CompareString(PasswordData, string.Empty, TextCompare: false) == 0) ? true : false)
            {
                return PasswordData;
            }
            string text = string.Empty;
            int num = Strings.AscW(PasswordData.Substring(0, 1));
            int num2 = Strings.AscW(PasswordData.Substring(1, 1));
            checked
            {
                int num3 = num + num2;
                PasswordData = PasswordData.Substring(2);
                PasswordData = PasswordData.Replace("''", "'");
                int num4 = PasswordData.Length - 1;
                int num5 = 0;
                while (true)
                {
                    int num6 = num5;
                    int num7 = num4;
                    if (num6 > num7)
                    {
                        break;
                    }
                    string @string = Conversions.ToString(Strings.ChrW((Strings.AscW(PasswordData.Substring(num5, 1)) ^ num3) + num5));
                    if (Strings.AscW(@string) == 0)
                    {
                        text += PasswordData.Substring(num5, 1);
                    }
                    else
                    {
                        @string = Conversions.ToString(Strings.ChrW((Strings.AscW(PasswordData.Substring(num5, 1)) - num5) ^ num3));
                        text += @string;
                    }
                    num5++;
                }
                return text;
            }
        }
        public static string Encrypt(string source, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(source);
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }

        public static string Decrypt(string encrypt, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(encrypt);
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
    }
}
