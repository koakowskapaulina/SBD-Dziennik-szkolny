﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DziennikSzkolny.Models
{
    public class Rodzic : User
    {
        public List<Uczen> dzieci { get; set; }
    }
}