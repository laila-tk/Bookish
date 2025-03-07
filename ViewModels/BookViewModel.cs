using Bookish.Models;

namespace Bookish.ViewModels;

public class BookViewModel
{
    public required int BookId { get; set; }
    public required string Title { get; set; }
    public required string Author {get; set; }
    public required string Category {get; set; }

    public required List<BookCopyViewModel> Copies {get;set;} = new List<BookCopyViewModel>();

    public BookViewModel() {}
    public BookViewModel(Book book) {
        BookId = book.BookId;
        Title = book.Title; 
        Author = book.Author; 
        Category = book.Category;   
    }
}