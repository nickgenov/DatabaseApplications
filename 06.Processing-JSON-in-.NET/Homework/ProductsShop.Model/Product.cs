﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsShop.Models
{
    public class Product
    {
        private ICollection<Category> categories;

        public Product()
        {
            this.categories = new HashSet<Category>();
        }
            
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public virtual User Seller { get; set; }     
        public virtual User Buyer { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}