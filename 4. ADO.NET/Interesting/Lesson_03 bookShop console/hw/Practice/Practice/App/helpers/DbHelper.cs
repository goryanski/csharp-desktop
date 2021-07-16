using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.App.helpers
{
    public class DbHelper
    {
        public DataContext GetContext()
        {
            string connecionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            DataContext ctx = new DataContext(connecionString);
            return ctx;
        }
    }
}
