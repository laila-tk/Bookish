using Bookish.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace Bookish.Models;

public class Book {

    [Key]
    public int BookId { get; set; }
    
    public  string Title { get; set; }
    public string Author {get; set; }
    public string Category {get; set;}

    public List<BookCopy> Copies {get;set;} = new List<BookCopy>();
    

    public Book(BookViewModel bookViewModel) {
        BookId = bookViewModel.BookId;
        Title = bookViewModel.Title;
        Author = bookViewModel.Author;
        Category = bookViewModel.Category;
    }
    //  public Book(int bookId, string title, string author, string category) {
    //     BookId = bookId;
    //     Title = title;
    //     Author = author;  
    //     Category = category;     
    //  }
     public Book() {}
}