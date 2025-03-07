using Bookish.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace Bookish.Models;

public class Book {

    [Key]
    public required int BookId { get; set; }
    
    public required string Title { get; set; }
    public required string Author {get; set; }
    public required string Category {get; set;}

    public required List<BookCopy> Copies {get;set;} = new List<BookCopy>();
    

    // public Book(BookViewModel bookViewModel) {
    //     BookId = bookViewModel.BookId;
    //     Title = bookViewModel.Title;
    //     Author = bookViewModel.Author;
    //     Category = bookViewModel.Category;
    // }
    //  public Book(int bookId, string title, string author, string category) {
    //     BookId = bookId;
    //     Title = title;
    //     Author = author;  
    //     Category = category;     
    //  }
     public Book() {}
}