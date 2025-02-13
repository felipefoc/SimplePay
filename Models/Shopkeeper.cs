using System.ComponentModel.DataAnnotations;

namespace SimplePay.Models;

public class Shopkeeper
{
    public required Guid Id { get; init; }
    public required string FullName { get; set; }
    public required decimal Cnpj { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public decimal? Balance { get; set; }
}