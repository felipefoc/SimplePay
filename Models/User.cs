using System.ComponentModel.DataAnnotations;
using SimplePay.DTOs;

namespace SimplePay.Models;

public class User
{
    public Guid Id { get; init; }
    public required string FullName { get; set; }
    public required decimal Cpf { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public decimal? Balance { get; set; }
}