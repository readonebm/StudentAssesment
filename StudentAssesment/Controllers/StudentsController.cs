using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAssesment.Controllers.Data;
using StudentAssesment.Models;
using StudentAssesment.Models.Student;
using PagedList;


namespace StudentAssesment.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDbContext context;

        public StudentsController(StudentDbContext _context)
        {
            this.context = _context;  
        }


        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber=1)
        {
            //var students = await context.Students.ToListAsync();
            var students = await PagInatedList<Student>.CreateAsync(context.Students, pageNumber, 3);

            return View(students);

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentsVM dataParam)
        {
            if (!ModelState.IsValid)
            {
                return View(dataParam);
            }

            var data = new Student()
            {
                Id = Guid.NewGuid(),
                NIM = dataParam.NIM,
                Nama = dataParam.Nama,
                Nilai = dataParam.Nilai,
                Catatan = dataParam.Catatan
            };

            await context.Students.AddAsync(data);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            var data = new DetailStudentVM()
            {
                Id = student.Id,
                NIM = student.NIM,
                Nama = student.Nama,
                Nilai = student.Nilai,
                Catatan = student.Catatan
            };

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            var data = new StudentsVM()
            {
                Id = student.Id,
                NIM = student.NIM,
                Nama = student.Nama,
                Nilai = student.Nilai,
                Catatan = student.Catatan
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentsVM dataParam)
        {
            var student = await context.Students.FindAsync(dataParam.Id);

            if (student != null)
            {
                student.NIM = dataParam.NIM;
                student.Nama = dataParam.Nama;
                student.Nilai = dataParam.Nilai;
                student.Catatan = dataParam.Catatan;

                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DetailStudentVM dataParam)
        {
            var student = await context.Students.FindAsync(dataParam.Id);

            if (student != null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
