﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Catalog
{
    public class Catalog
    {
        public IEnumerable<CatalogIndex> Movies { get; set; }
    }
}
