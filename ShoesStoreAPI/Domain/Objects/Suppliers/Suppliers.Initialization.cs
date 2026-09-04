using Domain.ValueObjects.Suppliers;

namespace Domain.Objects.Suppliers
{
    /// <summary>Частичная реализация поставщика: создание и восстановление.</summary>
    public sealed partial class Supplier
    {
        /// <summary>Создаёт нового поставщика (id = 0).</summary>
        private Supplier(SupplierName name)
        {
            Id = new(0);
            Name = name;
        }

        /// <summary>Восстанавливает поставщика из хранилища.</summary>
        private Supplier(long id, string name)
        {
            Id = new(id);
            Name = new(name);
        }

        /// <summary>Создать поставщика.</summary>
        public static Supplier Create(SupplierName name)
            => new(name);

        /// <summary>Восстановить поставщика.</summary>
        internal static Supplier Restore(long id, string name)
            => new(id, name);
    }
}