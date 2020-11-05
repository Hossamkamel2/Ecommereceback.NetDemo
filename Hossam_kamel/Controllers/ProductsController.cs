using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hossam_kamel.Models;
using Hossam_kamel.Models.Reposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hossam_kamel.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IReadFromFile readFromFile;

        public ProductsController(IReadFromFile read)
        {
            readFromFile=read;
        }

        [HttpGet]
        public IActionResult GetProducts(string query)
        {
            var resultProduct = readFromFile.readFile();
            if (resultProduct.Count() == 0)
                return NoContent();
            if (query == null)
            {
                string resulted = JsonConvert.SerializeObject(resultProduct, Formatting.Indented);


                return Ok(resulted);
            }
            else
            {
                string searchquery = query.Trim();

                return Ok(readFromFile.search_name_category_brand(resultProduct, searchquery));
            }
        }

        [Route("categories")]
        public IActionResult GetAllCategories()
        {
            var resultProduct = readFromFile.readFile();
            if (resultProduct.Count() == 0)
                return NoContent();
            IEnumerable<string> categories = readFromFile.findUniqueCategories(resultProduct);
            return Ok(categories);

        }

        [Route("categories/products")]
        public IActionResult GetAllCategoriesProducts(string query)
        {
            if(query==null)
                return NoContent();
            var resultProduct = readFromFile.readFile();
            if (resultProduct.Count() == 0)
                return NoContent();
            IEnumerable<Product> products = readFromFile.productsFromCategory(resultProduct, query);
            return Ok(products);

        }

        [Route("categories/Brands")]
        public IActionResult GetAllbrandProducts(string query)
        {
            if (query == null)
                return NoContent();
            var resultProduct = readFromFile.readFile();
            if (resultProduct.Count() == 0)
                return NoContent();
            IEnumerable<Product> products = readFromFile.productsFromBrand(resultProduct, query);
            return Ok(products);

        }

        [Route("brands")]
        public IActionResult GetAllbrands()
        {
            var resultProduct = readFromFile.readFile();
            if (resultProduct.Count() == 0)
                return NoContent();
            IEnumerable<string> categories = readFromFile.findUniqueBrand(resultProduct);
            return Ok(categories);

        }

        [Route("price")]
        public IActionResult GetAllproductswithpriceLess(double price)
        {
            var resultProduct = readFromFile.readFile();
            if (resultProduct.Count() == 0 || price<=0)
                return NoContent();
            IEnumerable<Product> products = readFromFile.findProductsPriceLessThanGivenPrice(resultProduct,price);
            return Ok(products);

        }



    }
}
