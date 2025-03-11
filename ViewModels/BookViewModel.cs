using Bookish.Models;

namespace Bookish.ViewModels;

public class BookViewModel
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author {get; set; }
    public string Category {get; set; }

    public int NumberOfCopies {get;set;}

    public List<BookCopyViewModel> Copies {get;set;} = new List<BookCopyViewModel>();

    public BookViewModel() {}
    public BookViewModel(Book book) {
        BookId = book.BookId;
        Title = book.Title; 
        Author = book.Author; 
        Category = book.Category;   
    }
}