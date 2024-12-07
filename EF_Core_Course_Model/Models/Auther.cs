using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Course_Model.Models
{
    public class Auther
    {
        [Key]
        public int Auther_Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Location { get; set; }
        [NotMapped]
        [MaxLength(1024)]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }
        public int Status { get; set; } = 0;
        [ValidateNever]
        public List<Book> Books { get; set; }
    }
}
