using Bookish.Models;

namespace Bookish.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author {get; set; }
    public int TotalNumberOfCopies {get; set; }
    public int NumberOfCopiesAvailable {get; set; }
    
    public BookViewModel() {}
    public BookViewModel(Book book) {
        Id = book.Id;
        Title = book.Title; 
        Author = book.Author;
        TotalNumberOfCopies = book.TotalNumberOfCopies;
        NumberOfCopiesAvailable = book.NumberOfCopiesAvailable;      
    }
}