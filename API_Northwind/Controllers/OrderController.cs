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
    public class OrderController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        //Order listeleme

        public List<OrderDTO> GetOrders()
        {
            return db.Orders.Select(x => new OrderDTO
            {
                OrderId = x.OrderID,
                ShipName = x.ShipName,
                
            }).ToList();
        }

        //ID göre Order çağırma

        public OrderDTO GetOrder(int id)
        {
            return db.Orders.Where(x => x.OrderID == id).Select(x => new OrderDTO
            {
                OrderId = x.OrderID,
                ShipName = x.ShipName,
            }).FirstOrDefault();
        }

    }
}
