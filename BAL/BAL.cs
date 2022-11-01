using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.BAL
{
    public class BAL
    {
        public static string GetToken(string uname, string password)
        {
            if (uname == "" || uname == null || password == "" || password == null)
                return DAL.DAL.GetToken(uname, password);
            return null;
        }
    }
}
