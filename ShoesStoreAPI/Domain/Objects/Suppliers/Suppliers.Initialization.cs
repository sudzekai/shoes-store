using Domain.ValueObjects.Suppliers;

namespace Domain.Objects.Suppliers
{
    public sealed partial class Supplier
    {
        private Supplier(SupplierName name)
        {
            Id = new(0);
            Name = name;
        }

        private Supplier(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        public static Supplier Create(SupplierName name)
            => new(name);

        internal static Supplier Restore(long id, string name)
            => new(id, name);
    }
}
