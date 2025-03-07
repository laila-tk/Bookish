using Bookish.ViewModels;

namespace Bookish.Models;

public class Member {
    public required int MemberId { get; set; }
    public required string Name { get; set; }
    public required DateOnly DateOfRegistration {get; set; }
    public required string Email {get; set;}

    public Member(MemberViewModel memberViewModel) {
        MemberId = memberViewModel.MemberId;
        Name = memberViewModel.Name;
        DateOfRegistration = memberViewModel.DateOfRegistration;
        Email = memberViewModel.Email;
    }

    public Member(int memberId, string name, DateOnly dateOfRegistration, string email) {
        MemberId = memberId;
        Name = name;
        DateOfRegistration = dateOfRegistration;
        Email = email;
    }

    public Member() {}
}