using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EF_Core_Course_Model.Models
{
    public class BookDetila
    {
        [Key]
        public int BookDetila_Id { get; set; }
        public string Chapter { get; set; }
        public string Pages { get; set; }
        public string BookType { get; set; }

        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        public Book Book { get; set; }

    }
}
