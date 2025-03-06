using Bookish.ViewModels;

namespace Bookish.Models;

public class Book {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author {get; set; }
    public string Category {get; set;}

    public Book(BookViewModel bookViewModel) {
        Id = bookViewModel.Id;
        Title = bookViewModel.Title;
        Author = bookViewModel.Author;
        Category = bookViewModel.Category;
    }
     public Book(int id, string title, string author, string category) {
        Id = id;
        Title = title;
        Author = author;  
        Category = category;     
     }
}