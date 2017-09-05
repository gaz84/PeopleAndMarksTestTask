using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleAndMarksTestTask.Models
{
    public class PageInfo
    {
        public int RowPerPage { get; set; }
        public int CurrentPageNumber { get; set; }
        public bool SortByValue { get; set; }
        
    }
}