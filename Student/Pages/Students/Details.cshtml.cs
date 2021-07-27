using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student.Models;
using System.Threading.Tasks;

namespace Student.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Student.Data.StudentContext _context;

        public DetailsModel(Student.Data.StudentContext context)
        {
            _context = context;
        }

        public StudentList StudentList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentList = await _context.StudentList.FirstOrDefaultAsync(m => m.Id == id);

            if (StudentList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
