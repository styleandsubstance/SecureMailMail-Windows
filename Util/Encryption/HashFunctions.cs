using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecureMedMail.Util.Encryption
{
    class HashFunctions
    {
        /// <summary>
        /// Generates a SHA256 hash of the string
        /// </summary>
        /// <param name="val">value to be hashed</param>
        /// <returns>SHA256 Hash of val</returns>
        public static String Sha256(String val)
        {
            SHA256 mySHA256 = SHA256Managed.Create();

            byte[] hash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(val));

            StringBuilder hexHash = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                hexHash.AppendFormat("{0:x2}", hash[i]);
            }

            return hexHash.ToString();
        }
    }
}
