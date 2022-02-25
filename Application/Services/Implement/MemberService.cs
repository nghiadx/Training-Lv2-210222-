using Application.Services.Interface;
using Application.ViewModels.Members;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Models.Entities;

namespace Application.Services.Implement
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork/*, IMapper mapper*/)
        {
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        public async Task CreateMember(Member member)
        {
            await _unitOfWork.Members.Add(member);
            //await _unitOfWork._Context.SaveChangesAsync();
        }

        public async Task DeleteMemberById(int id)
        {
            Member member = await _unitOfWork.Members.Get(id);
            await _unitOfWork.Members.Delete(member);
            //await _unitOfWork._Context.SaveChangesAsync();
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _unitOfWork.Members.GetAll();
            //return _mapper.Map<IEnumerable<MemberViewModel>>(members);
        }

        public IEnumerable<MemberViewModel> GetAllMemberViewModel()
        {
            throw new NotImplementedException();
        }

        public async Task<Member> GetMemberById(int? id)
        {
            return await _unitOfWork.Members.Get(id);
        }
        public async Task UpdateMember(Member member)
        {
            await _unitOfWork.Members.Update(member);
        }
    }
}
