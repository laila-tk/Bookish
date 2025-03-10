using Bookish.ViewModels;
using System .ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookish.Models;

public class BookCopy {
    [Key]
    public int CopyId { get; set; }
    
    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book Book{ get; set; }

    public ICollection<CheckOut> BookCopyCheckOuts{get; set;} = new List<CheckOut>();
   

    public BookCopy(BookCopyViewModel bookCopyViewModel) {
        BookId = bookCopyViewModel.BookId;     
        CopyId = bookCopyViewModel.CopyId;
        Book = bookCopyViewModel.Book;   
    }
    //  public BookCopy(int copyId) {
    //     CopyId = copyId;       
    //  }
     
     public BookCopy() {}
}