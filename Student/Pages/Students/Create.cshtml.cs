using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student.Models;
using System.Threading.Tasks;

namespace Student.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly Student.Data.StudentContext _context;

        public CreateModel(Student.Data.StudentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentList StudentList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentList.Add(StudentList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
