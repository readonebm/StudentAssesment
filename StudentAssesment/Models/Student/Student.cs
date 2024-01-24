using System.ComponentModel.DataAnnotations;

namespace StudentAssesment.Models.Student
{
    public class Student
    {
        public Guid Id { get; set; }
        public long NIM { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string? Nama { get; set; }
        public long Nilai { get; set; }
        public string Catatan { get; set; }

    }
}
