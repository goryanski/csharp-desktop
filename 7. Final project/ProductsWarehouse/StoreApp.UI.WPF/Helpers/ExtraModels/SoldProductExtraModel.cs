﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.UI.WPF.Helpers.ExtraModels
{
    // extra model - only for display in archive window
    public class SoldProductExtraModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ShopName { get; set; }
        public int Amount { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
