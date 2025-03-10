using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookish.ViewModels;

namespace Bookish.Models;

public class CheckOut {
    [Key]
    public int CheckOutId { get; set; }
    
    [ForeignKey("Copy")]
    public int CopyId {get;set;}
    public BookCopy BookCopy{ get; set; }
    [ForeignKey("Member")]
    public int MemberId {get;set;}
    public Member Member {get;set;}
    public DateOnly CheckoutDate {get;set;}
    public DateOnly DueDate {get;set;}
    public DateOnly? ReturnDate {get;set;}

    public bool Late{get;set;}

     public CheckOut(CheckOutViewModel checkOutViewModel) {
        MemberId = checkOutViewModel.MemberId;     
        CopyId = checkOutViewModel.CopyId;
    }
}
