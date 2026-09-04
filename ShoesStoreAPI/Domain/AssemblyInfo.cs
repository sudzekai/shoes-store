using System.Runtime.CompilerServices;

/// <summary>
/// Позволяет проекту "Infrastructure" видеть внутренние типы этого сборки для тестирования/восстановления.
/// </summary>
[assembly: InternalsVisibleTo("Infrastructure")]