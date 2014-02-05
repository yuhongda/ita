using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ITA.Utility
{
	/// <summary>
	/// Summary description for MD5Encrypt
	/// </summary>
	public class DESEncrypt
	{
		public DESEncrypt()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKey = "GREAT!!!";
        private static string EncryptionKey4Client = "Client!!";

        private static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }



        private static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

        public static string EncryptQueryString(string password)
        {
            return Encrypt(password, EncryptionKey);
        }

        public static string DecryptQueryString(string password)
        {
            return Decrypt(password, EncryptionKey);
        }

        #region 798¿Í»§¶ËÓÃ
        public static string EncryptQueryString4Client(string password)
        {
            return Encrypt(password, EncryptionKey4Client);
        }

        public static string DecryptQueryString4Client(string password)
        {
            return Decrypt(password, EncryptionKey4Client);
        }
        #endregion
    }
}