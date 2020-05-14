using Programming.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
   public class BaseDAL
    {
        protected ProgramingDbEntities1 db;
        public BaseDAL()
        {
            db = new ProgramingDbEntities1();
        }
    }
}
