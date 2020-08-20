using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using policedata.Models;

namespace policedata.ViewModel
{
    public class AllCrimeInformation
    {
        public List<CrimeDetails> CrimeDetails { set; get; }
        public List<CrimeTypes> CrimeTypes { set; get; }
        public IEnumerable<SelectListItem> listItems { set; get; }
    }

}

