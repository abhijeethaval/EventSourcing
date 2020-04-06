using System;

namespace Sourcing.Domain.RFxCreation
{
    internal abstract class RFxEvent
    {
        private RFxEvent() { }

        public class RFxCreated : RFxEvent
        {
            public RFxCreated(string name, DateTime biddingStartDateInUtc, DateTime biddingEndDateInUtc)
            {
                this.Name = name;
                this.BiddingStartDateInUtc = biddingStartDateInUtc;
                this.BiddingEndDateInUtc = biddingEndDateInUtc;
            }

            public string Name { get; private set; }
            public DateTime BiddingStartDateInUtc { get; private set; }
            public DateTime BiddingEndDateInUtc { get; private set; }
        }

        public class LineItemAdded : RFxEvent
        {
            public LineItemAdded(LineItem lineItems) => this.LineItem = lineItems;

            public LineItem LineItem { get; private set; }
        }

        public class SupplierAdded : RFxEvent
        {
            public SupplierAdded(Supplier supplier) => this.Supplier = supplier;
            public Supplier Supplier { get; private set; }
        }
    }
}