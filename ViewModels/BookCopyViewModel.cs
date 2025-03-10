using Bookish.Models;

namespace Bookish.ViewModels;

public class BookCopyViewModel
{

    public required int BookCopyId { get; set; }
    public required int BookId { get; set; }
    public required Book Book{ get; set; }

    public int NumberOfCopies {get;set;}

    public BookCopyViewModel() {}
    public BookCopyViewModel(BookCopy bookCopy) {
        BookCopyId = bookCopy.BookCopyId;
        BookId = bookCopy.BookId;
    }
}