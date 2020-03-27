using System;
using System.Collections.Generic;
using System.Text;

namespace Sourcing.Domain.RFxCreation
{
    public class RFxModel
    {
        public string Name { get; set; }

        public DateTime BiddingStartDateInUtc { get; set; }

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
