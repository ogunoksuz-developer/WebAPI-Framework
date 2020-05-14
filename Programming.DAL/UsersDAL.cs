using Programming.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
   public class UsersDAL:BaseDAL
    {
        public Users GetUsersByApiKey(string apiKey)
        {
            return db.Users.FirstOrDefault(x => x.UserKey.ToString() == apiKey);
        }

        public Users GetUsersByName(string name)
        {
            return db.Users.FirstOrDefault(x => x.Name == name);
        }
    }
}
