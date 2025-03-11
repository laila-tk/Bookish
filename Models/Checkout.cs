using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookish.ViewModels;

namespace Bookish.Models;

public class CheckOut {
    [Key]
    public int CheckOutId { get; set; }
  
    public int BookCopyId {get;set;}
    public BookCopy BookCopy{ get; set; }

    public int MemberId {get;set;}
    public Member Member {get;set;}
    
    public DateOnly CheckoutDate {get;set;}
    public DateOnly DueDate {get;set;}
    public DateOnly? ReturnDate {get;set;}

    public CheckOut() {}

}
