using Bookish.Models;

namespace Bookish.ViewModels;

public class BookCopyViewModel
{

    public required int CopyId { get; set; }
    public required int BookId { get; set; }
    public required Book Book{ get; set; }

    public BookCopyViewModel() {}
    public BookCopyViewModel(BookCopy bookCopy) {
        CopyId = bookCopy.CopyId;
    }
}