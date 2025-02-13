using System.ComponentModel.DataAnnotations;

namespace SimplePay.Models;

public class PaymentHistory : IValidatableObject
{
    public enum PaymentType
    {
        U2U = 1, // User-to-User
        U2B = 2  // User-to-Business
    }
    
    public required Guid Id { get; init; }
    public required DateTime Date { get; set; }
    public required decimal Amount { get; set; }
    public required PaymentType Type { get; set; }
    
    // Who payed
    public required Guid PayerId { get; set; }
    public required User Payer { get; set; }
    
    // Who Received
    // - U2U
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    // - U2B
    public Guid? ShopkeeperId { get; set; }
    public Shopkeeper? Shopkeeper { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (PayerId == UserId)
        {
            yield return new ValidationResult(
                "The payer cannot also be the user.",
                [nameof(PayerId), nameof(UserId)]);
        }

        if (Amount <= 0)
        {
            yield return new ValidationResult(
                "The amount must be greater than zero.",
                [nameof(Amount)]);
        }

        if (Type == PaymentType.U2U && (Shopkeeper != null || ShopkeeperId != null) 
            || Type == PaymentType.U2B && (User != null || UserId != null))
        {
            yield return new ValidationResult(
                "Payment type cannot have both U2U and U2B.",
                [nameof(Type)]);
        }

        if (Date > DateTime.Now)
        {
            yield return new ValidationResult(
                "The date cannot be in the future.",
                [nameof(Date)]);
        }
    }
}