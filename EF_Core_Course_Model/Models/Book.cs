using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Course_Model.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Titel { get; set; }
        public string ISNB { get; set; }
        public Double Price { get; set; }
        public BookDetila BookDetila { get; set; }

        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }

        public List<Auther> Authers { get; set; }
    }
}
