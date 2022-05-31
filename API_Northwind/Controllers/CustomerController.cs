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
    public class CustomerController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        //Product listeleme

        public List<CustomerDTO> GetCustomers()
        {
            return db.Customers.Select(x => new CustomerDTO
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
               
            }).ToList();
        }

        //ID göre Product çağırma

        public CustomerDTO GetCustomer(string id)
        {
            return db.Customers.Where(x => x.CustomerID == id).Select(x => new CustomerDTO
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
            }).FirstOrDefault();
        }


    }
}
