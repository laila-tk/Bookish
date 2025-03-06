using Bookish.ViewModels;

namespace Bookish.Models;

public class Member {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfRegistration {get; set; }
    public string Email {get; set;}

    public Member(MemberViewModel memberViewModel) {
        Id = memberViewModel.Id;
        Name = memberViewModel.Name;
        DateOfRegistration = memberViewModel.DateOfRegistration;
        Email = memberViewModel.Email;
    }

    public Member(int id, string name, DateOnly dateOfRegistration, string email) {
        Id = id;
        Name = name;
        DateOfRegistration = dateOfRegistration;
        Email = email;
    }
}