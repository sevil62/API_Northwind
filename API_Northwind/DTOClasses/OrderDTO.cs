using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Northwind.DTOClasses
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string ShipName { get; set; }
    }
}