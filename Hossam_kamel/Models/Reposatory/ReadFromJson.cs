using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hossam_kamel.Models.Reposatory
{
    public class ReadFromJson: IReadFromFile
    {
        public string path { get; set; }

        public ReadFromJson(string filename)
        {
            path = filename;
        }

        public IEnumerable<Product> readFile()
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    string json = file.ReadToEnd();

                    IEnumerable<Product> items = JsonConvert.DeserializeObject<List<Product>>(json);
                    return items;
                }
            }
            catch
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> search_name_category_brand(IEnumerable<Product> products,string query)
        {
            var returnedProducts = products.Where(product => product.name.Contains(query) || product.category.name.Contains(query) || product.brand.Contains(query)).ToList();
            return returnedProducts;
        }

        public IEnumerable<Product> productsFromCategory(IEnumerable<Product> products, string query)
        {
          
            var returnedProducts = products.Where(product => product.category.name.ToLower()== query.ToLower()).ToList();
            return returnedProducts;
        }

        public IEnumerable<Product> productsFromBrand(IEnumerable<Product> products, string query)
        {
            var returnedProducts = products.Where(product => product.brand.ToLower() == query.ToLower()).ToList();
            return returnedProducts;
        }
        public IEnumerable<string> findUniqueCategories(IEnumerable<Product> products)
        {

            return products.Select(c => c.category.name.ToUpper()).Distinct().ToList();
        }

        public IEnumerable<string> findUniqueBrand(IEnumerable<Product> products)
        {

            return products.Select(c => c.brand).Distinct().ToList();
        }

        public IEnumerable<Product> findProductsPriceLessThanGivenPrice(IEnumerable<Product> products,double price)
        {

            return products.Where(product => product.price<price).ToList();
        }


    }
}
