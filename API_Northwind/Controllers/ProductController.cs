using API_Northwind.DTOClasses;
using API_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Northwind.Controllers
{
   
    public class ProductController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        //Product listeleme
      
        public List<ProductDTO> GetProducts()
        {
            return db.Products.Select(x=>new ProductDTO
            {
                ProductID = x.ProductID,
                ProductName= x.ProductName,
                UnitPrice= (decimal)x.UnitPrice
            }).ToList();
        }

        //ID göre Product çağırma

        public ProductDTO GetProduct(int id)
        {
            return db.Products.Where(x => x.ProductID == id).Select(x => new ProductDTO
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = (decimal)(x.UnitPrice)
            }).FirstOrDefault();
        }


        //Product Ekleme
        [HttpPost]
        public List<ProductDTO> AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return GetProducts();


        }

        //Product Güncelleme
        [HttpPut]
        public List<ProductDTO> UpdateProduct(Product product)
        {
            Product toBeUpdated=db.Products.Find(product.ProductID);
            db.Entry(toBeUpdated).CurrentValues.SetValues(product);
            db.SaveChanges();
            return GetProducts();
        }

        //Product Silme

        [HttpDelete]
        public List<ProductDTO> DeleteProduct(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return GetProducts();

        }


    }
}
