using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Entities
{
    public class OptIn
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
