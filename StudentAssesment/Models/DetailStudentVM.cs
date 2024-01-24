namespace StudentAssesment.Models
{
    public class DetailStudentVM
    {
        public Guid Id { get; set; }
        public long NIM { get; set; }
        public string Nama { get; set; }
        public long Nilai { get; set; }
        public string Catatan { get; set; }
    }
}
