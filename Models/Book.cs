using Bookish.ViewModels;

namespace Bookish.Models;

public class Book {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author {get; set; }
    public int TotalNumberOfCopies {get; set; }
    public int NumberOfCopiesAvailable {get; set; }

    public Book(BookViewModel bookViewModel) {
        Id = bookViewModel.Id;
        Title = bookViewModel.Title;
        Author = bookViewModel.Author;
        TotalNumberOfCopies = bookViewModel.TotalNumberOfCopies;
        NumberOfCopiesAvailable = bookViewModel.NumberOfCopiesAvailable;
       
    }
     public Book(int id, string title, string author, int totalNumberOfCopies, int numberOfCopiesAvailable) {
        Id = id;
        Title = title;
        Author = author;
        TotalNumberOfCopies = totalNumberOfCopies;
        NumberOfCopiesAvailable = numberOfCopiesAvailable;
     }
}