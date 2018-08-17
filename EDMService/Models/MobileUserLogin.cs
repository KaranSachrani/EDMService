using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDMService.Models
{
    public class MobileUserLogin
    {
        public string cnic { set; get; }

        public string number { set; get; }

        public int status { set; get; }

        public bool found { set; get; }

    }
}