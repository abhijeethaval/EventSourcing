using System;
using System.Collections.Generic;
using static Sourcing.Domain.RFxCreation.RFxEvent;

namespace Sourcing.Domain.RFxCreation
{
    internal class RFx : AggregateRoot<RFxEvent>
    {
        public RFx() { }

        public string Name { get; private set; }

        public DateTime BiddingStartDateInUtc { get; private set; }

        public DateTime BiddingEndDateInUtc { get; private set; }

        private readonly List<LineItem> lineItems = new List<LineItem>();
        public IEnumerable<LineItem> LineItems => this.lineItems;

        private readonly List<Supplier> suppliers = new List<Supplier>();
        public IEnumerable<Supplier> Suppliers => this.suppliers;

        public RFx(string name, DateTime biddingStartDateInUtc, DateTime biddingEndDateInUtc) =>
            Raise(new RFxCreated(name, biddingStartDateInUtc, biddingEndDateInUtc));

        public void AddLineItem(string lineItemName) =>
            Raise(new LineItemAdded(new LineItem(lineItemName)));

        public void AddSupplier(string supplierName) =>
            Raise(new SupplierAdded(new Supplier(supplierName)));

        protected override void Apply(RFxEvent @event)
        {
            switch (@event)
            {
                case RFxCreated rFxCreated:
                    (this.Name, this.BiddingStartDateInUtc, this.BiddingEndDateInUtc) =
                        (rFxCreated.Name, rFxCreated.BiddingStartDateInUtc, rFxCreated.BiddingEndDateInUtc);
                    return;
                case LineItemAdded lineItemAdded:
                    this.lineItems.Add(lineItemAdded.LineItem);
                    return;
                case SupplierAdded supplierAdded:
                    this.suppliers.Add(supplierAdded.Supplier);
                    return;
            }
        }
    }
}