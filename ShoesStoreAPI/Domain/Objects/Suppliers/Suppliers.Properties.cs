using Domain.ValueObjects.Suppliers;

namespace Domain.Objects.Suppliers
{
    public sealed partial class Supplier
    {
        public SupplierId Id { get; private set; }

        public SupplierName Name { get; private set; }

        public void ChangeName(SupplierName name)
            => Name = name;
    }
}
