using Bookish.ViewModels;
using System .ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

public class BookCopy {
    [Key]
    public required int CopyId { get; set; }
    
    [ForeignKey("BookId")]
    public required int BookId { get; set; }
    public required Book Book{ get; set; }
   

    // public BookCopy(BookCopyViewModel bookCopyViewModel) {
    //     CopyId = bookCopyViewModel.CopyId;        
    // }
    //  public BookCopy(int copyId) {
    //     CopyId = copyId;       
    //  }
     
     public BookCopy() {}
}