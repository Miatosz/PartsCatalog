using Microsoft.AspNetCore.Mvc.ModelBinding;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartsCatalog.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID {get; set;}

        [BindNever]
        public ICollection<CartLine> Lines {get; set;}

        [BindNever]
        public bool Shipped {get; set;}
        
        public Client Client { get; set; }
    }
}