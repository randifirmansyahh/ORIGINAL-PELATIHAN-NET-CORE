using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace go_blogs.Helper
{
    public class BantuanUmum
    {
        public static string BuatPrimary()
        {
            Guid buat = Guid.NewGuid();
            return buat.ToString();
        }

        public static int BuatOTP()
        {
            Random r = new(); // cara simple dari Random r = new Random();
            return r.Next(1000, 9999); //(start, stop)
        }

        public static List<Claim> BuatKlaim(string Username, string Role)
        {
            return new List<Claim>
            {
                new Claim("Username", Username),
                new Claim("Role", Role) // isi harus sesuai sama [Authorize(Roles="isinya")]
            };
        }
    }
}
