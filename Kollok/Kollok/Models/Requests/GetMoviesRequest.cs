using System.ComponentModel.DataAnnotations;

namespace Kollok.Models.Requests;

public class BuyTicketRequest
{
    /// <summary>
    /// Id сеанса.
    /// </summary>
    [Required]
    public long SessionId { get; set; }
    
    /// <summary>
    /// Количество покупаемых билетов.
    /// </summary>
    [Required]
    public int Count { get; set; }
}