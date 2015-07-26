﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products 
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}