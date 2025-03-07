using Bookish.Models;

namespace Bookish.ViewModels;

public class MemberViewModel
{
    public required int MemberId { get; set; }
    public required string Name { get; set; }
    public required DateOnly DateOfRegistration {get; set; }
    public required string Email {get; set;}

    public MemberViewModel() {}
    public MemberViewModel(Member member) {
        MemberId = member.MemberId;
        Name = member.Name;
        DateOfRegistration = member.DateOfRegistration;
        Email = member.Email;    
    }
}