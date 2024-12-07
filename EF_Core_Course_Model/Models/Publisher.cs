using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EF_Core_Course_Model.Models
{
    public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public string Loction { get; set; }
        public int Status { get; set; } = 0;
        [ValidateNever]
        public List<Book> Books { get; set; }
    }
}
