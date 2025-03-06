using Bookish.Models;

namespace Bookish.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author {get; set; }
    public string Category {get; set; }

    public BookViewModel() {}
    public BookViewModel(Book book) {
        Id = book.Id;
        Title = book.Title; 
        Author = book.Author; 
        Category = book.Category;   
    }
}