using System.ComponentModel.DataAnnotations;

namespace RestfulDemo.Dto
{
    public class MemberCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string CellPhone { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string ReportTo { get; set; }
        public string CreateTime { get; set; }
        public string Editor { get; set; }
        public string EditTime { get; set; }
    }
}
