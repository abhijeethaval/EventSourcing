namespace Sourcing.Domain.RFxCreation
{
    public class Supplier
    {
        public Supplier(string name) => this.Name = name;
        public string Name { get; private set; }
    }
}