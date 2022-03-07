using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Helper
{
    public static class BanyakBantuan
    {
        public static int BuatOTP()
        {
            Random r = new(); // cara simple dari Random r = new Random();
            return r.Next(1000, 9999); //(start, stop)
        }
    }
}
