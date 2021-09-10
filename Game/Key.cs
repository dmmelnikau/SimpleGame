
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Key
    {
        public static string Gen()
        {
            var key = new byte[16];
            using (var generator = RandomNumberGenerator.Create())
            generator.GetBytes(key);
            var newKey= BitConverter.ToString(key).Replace("-", "").ToUpper();
            return newKey;
        }
    }
}
