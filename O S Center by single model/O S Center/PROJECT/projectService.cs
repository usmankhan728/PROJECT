using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace O_S_Center.PROJECT
{
    internal class projectService
    {
        public projectRepository repo = new projectRepository();

        public void product(List<projectModel> products)
        {
            repo.save(products);
        }

        public void addnewproduct(projectModel a)
        {
            repo.addItem(a);
        }

        public List<projectModel> data()
        {
            return repo.fetch();
        }

        public bool priceChange(string upd, double pri)
        {
            if (repo.updateprice(upd, pri))
            {
                return true;
            }
            return false;
        }

        public void delete(string del)
        {
             repo.deleteItem(del);
        }
    }
}
