using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BloodDonor.Utils
{
    class Hashing
    {
        private string text;
        private MD5 md5Hash;

        public Hashing(String input)
        {
            this.text = input;
            this.md5Hash = MD5.Create();
        }

        public string getMd5Hash()
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sBuilder = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool verifyMd5Hash(string hash)
        {
            string hashOfInput = getMd5Hash();
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            if (0 == stringComparer.Compare(hashOfInput, hash))
                return true;
            return false;
        }
    }
}
