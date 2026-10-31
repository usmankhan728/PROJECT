using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONLINE_SHOPPING_CENTER.PRODUCT
{
    internal class productService
    {
        private readonly productRepository _repository;
        public List<productModel> _products;

        public productService()
        {
            _repository = new productRepository();
            _products = _repository.LoadProducts();
        }

        public List<productModel> GetAllProducts()
        {
            return _products;
        }

        public void AddProduct(string name, int price, int warranty, float discount, int delivery)
        {
            _products.Add(new productModel(name, price, warranty, discount, delivery));
            _repository.SaveProducts(_products);
        }

        public bool RemoveProduct(string name)
        {
            productModel product = null;

            foreach (var p in _products)
            {
                if (p.Name.ToLower() == name.ToLower())
                {
                    product = p;
                    break; // Stop searching once we find the match
                }
            }
            if (product != null)
            {
                _products.Remove(product);
                _repository.SaveProducts(_products);
                return true;
            }
            return false;
        }

        public bool UpdatePrice(string name, int newPrice)
        {
            productModel product = null;

            foreach (var p in _products)
            {
                if (p.Name.ToLower() == name.ToLower())
                {
                    product = p;
                    break; // Stop searching once we find the match
                }
            }
            if (product != null)
            {
                product.Price = newPrice;
                _repository.SaveProducts(_products);
                return true;
            }
            return false;
        }
    }
}
