﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Course_Model.Models.FluentModels

{
    public class Fluent_Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PriceRange { get; set; }
       
        public Fluent_BookDetail BookDetail { get; set; }
        public int Publisher_Id { get; set; }
        public Fluent_Publisher Publisher { get; set; }
        //public List<Fluent_Author> Authors { get; set; }
        public List<Fluent_BookAuthorMap> BookAuthorMap{ get; set; }
    } 
}
