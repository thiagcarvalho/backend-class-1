﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Persistence.DataModels.Store
{
    public class PetDataModel : DataModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

    }
}
