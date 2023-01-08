using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LVRMWebAPI.Extension
{
    public static class Commoncls
    {
        public static string MD5Hash(string inputString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] inArray = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
