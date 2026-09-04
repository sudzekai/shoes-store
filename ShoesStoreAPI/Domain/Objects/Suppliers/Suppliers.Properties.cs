using Domain.ValueObjects.Suppliers;

namespace Domain.Objects.Suppliers
{
    /// <summary>Частичная реализация поставщика: свойства и операции изменения.</summary>
    public sealed partial class Supplier
    {
        /// <summary>Идентификатор поставщика.</summary>
        public SupplierId Id { get; private set; }

        /// <summary>Название поставщика.</summary>
        public SupplierName Name { get; private set; }

        /// <summary>Изменить название поставщика.</summary>
        public void ChangeName(SupplierName name)
            => Name = name;
    }
}