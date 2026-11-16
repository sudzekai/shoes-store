using System.ComponentModel.DataAnnotations;

namespace StoreData.Dto
{
    public sealed record LoginDto([Required] string Login, [Required] string Password);
    public sealed record AccountDto(long Id, string Login, string FullName, string Role);
}
