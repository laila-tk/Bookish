using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

public class CheckOut {
    [Key]
    public required int CopyId { get; set; }
    
    [ForeignKey("BookId")]
    public required Book Book{ get; set; }
    [ForeignKey("MemberId")]
    public required Member member {get;set;}
    public required DateOnly CheckoutDate {get;set;}
    public required DateOnly DueDate {get;set;}
    public DateOnly ReturnDate {get;set;}
}
