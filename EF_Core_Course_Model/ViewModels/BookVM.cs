using EF_Core_Course_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Course_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public BookDetila BookDetila { get; set; }
        public IEnumerable<SelectListItem> PuplisherList { get; set; }

    }
}
