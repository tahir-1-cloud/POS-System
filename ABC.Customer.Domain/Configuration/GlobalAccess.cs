using ABC.EFCore.Repository.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Customer.Domain.Configuration
{
    public class GlobalAccess
    {


        public static List<CartDetail> _listcart;
        public static List<CartDetail> listcart
        {
            set { _listcart = value; }
            get { return _listcart; }

        }
    }
}
