﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Models
{
    public class Email
    {
        public string To { get; set; } = null!;
        public string Subject { get; set; }= null!;
        public string Body { get; set; }= null!;
    }
}
