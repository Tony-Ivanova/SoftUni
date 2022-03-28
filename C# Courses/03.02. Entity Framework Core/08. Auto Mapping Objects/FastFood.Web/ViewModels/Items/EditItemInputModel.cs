using System;
using System.Collections.Generic;

namespace FastFood.Web.ViewModels.Items
{
    public class EditItemViewModel
    {
        public EditItemInputModel MappedItem { get; set; }

        public List<string> CategoryName { get; set; }
    }
}
