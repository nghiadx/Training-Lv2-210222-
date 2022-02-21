using Application.ViewModels.Members;
using Infrastructure.Models.Entities;

namespace Application.Services.Interface
{
    public interface IMemberService
    {
        //IEnumerable<MemberViewModel> GetAllMemberView();
        IEnumerable<Member> GetAllMembers();
        IEnumerable<MemberViewModel> GetAllMemberViewModel();
        Task<Member> GetMemberById(int? id);
        Task DeleteMemberById(int id);
        Task UpdateMember(Member member);
        Task CreateMember(Member member);
        
    }
}
