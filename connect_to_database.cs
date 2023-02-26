using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metro_rail_management_system
{
    public static class Connect_to_database//static class
    {
        public static string Connecting()//static method
        {
            string constring = "Server=localhost; database=metro_rail_management_system; Uid=root; Pwd=''; SslMode=none";
            return constring;
        }
    }
}
