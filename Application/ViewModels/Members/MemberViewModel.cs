namespace Application.ViewModels.Members
#nullable disable
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MoblieNumber { get; set; }
        public Boolean Gender { get; set; }
        public DateTime Dob { get; set; }
        public int? EmailOptIn { get; set; }
    }
}
