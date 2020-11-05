using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hossam_kamel.Models.Reposatory
{
    public interface IReadFromFile
    {
        IEnumerable<Product> readFile();
        IEnumerable<Product> search_name_category_brand(IEnumerable<Product> products, string query);
        IEnumerable<string> findUniqueCategories(IEnumerable<Product> products);
        IEnumerable<string> findUniqueBrand(IEnumerable<Product> products);
        IEnumerable<Product> productsFromCategory(IEnumerable<Product> products, string query);

        IEnumerable<Product> productsFromBrand(IEnumerable<Product> products, string query);
        IEnumerable<Product> findProductsPriceLessThanGivenPrice(IEnumerable<Product> products, double price);
    }
}
