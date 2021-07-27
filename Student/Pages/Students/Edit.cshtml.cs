using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly Student.Data.StudentContext _context;

        public EditModel(Student.Data.StudentContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentListExists(StudentList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentListExists(int id)
        {
            return _context.StudentList.Any(e => e.Id == id);
        }
    }
}
