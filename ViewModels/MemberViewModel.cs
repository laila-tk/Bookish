using Bookish.Models;

namespace Bookish.ViewModels;

public class MemberViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfRegistration {get; set; }
    public string Email {get; set;}

    public MemberViewModel() {}
    public MemberViewModel(Member member) {
        Id = member.Id;
        Name = member.Name;
        DateOfRegistration = member.DateOfRegistration;
        Email = member.Email;
         
    }
}