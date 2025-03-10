using Bookish.ViewModels;
using System .ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

public class BookCopy {
    [Key]
    public int CopyId { get; set; }
    
    [ForeignKey("BookId")]
    public int BookId { get; set; }
    public Book Book{ get; set; }

    public ICollection<CheckOut> BookCopyCheckOuts{get; set;} = new List<CheckOut>();
   

    // public BookCopy(BookCopyViewModel bookCopyViewModel) {
    //     CopyId = bookCopyViewModel.CopyId;        
    // }
    //  public BookCopy(int copyId) {
    //     CopyId = copyId;       
    //  }
     
     public BookCopy() {}
}