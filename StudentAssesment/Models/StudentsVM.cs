namespace StudentAssesment.Models
{
    public class StudentsVM
    {
        public Guid Id { get; set; }
        public long NIM { get; set; }
        public string Nama { get; set; }
        public long Nilai { get; set; }
        public string Catatan { get; set; }
    }
}
