using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDMService.Models
{
    public class Survey
    {
        public string surveyed_by { set; get; }
        public string cnic { set; get; }

        public string supporting_party { set; get; }

        public int status { set; get; }
    }
}