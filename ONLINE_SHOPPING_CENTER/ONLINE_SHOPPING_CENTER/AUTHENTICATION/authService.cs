using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.AUTHENTICATION
{
    internal class authService
    {
        public authModel model = new authModel();
        
        public bool CheckAdminConditions(string username, int password)
        {
            if (username == model.Username && password == model.Password)
            {
                return true;
            }

            return false;
        }
    }
}
