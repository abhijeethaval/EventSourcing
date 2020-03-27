namespace Sourcing.Domain.RFxCreation
{
    public class LineItem
    {
        public LineItem(string name) => this.Name = name;

        public string Name { get; private set; }
    }
}