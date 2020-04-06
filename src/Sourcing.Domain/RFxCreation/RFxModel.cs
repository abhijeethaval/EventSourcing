using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sourcing.Domain.RFxCreation
{
    public class RFxModel : Model
    {
        [Display(Order = 0, Name = "Name")]
        public string Name { get; set; }

        [Display(Order = 1, Name = "Bidding Start Date")]
        public DateTime BiddingStartDateInUtc { get; set; }

        [Display(Order = 2, Name = "Bidding End Date")]
        public DateTime BiddingEndDateInUtc { get; set; }

        public List<LineItemModel> LineItems { get; set; }

        public List<SupplierModel> Suppliers { get; set; }
    }

    public class LineItemModel
    {
        public string Name { get; set; }
    }

    public class SupplierModel
    {
        public string Name { get; set; }
    }


}
