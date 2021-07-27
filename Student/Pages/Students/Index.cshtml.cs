using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Student.Data.StudentContext _context;

        public IndexModel(Student.Data.StudentContext context)
        {
            _context = context;
        }

        public IList<StudentList> StudentList { get; set; }

        public async Task OnGetAsync()
        {
            StudentList = await _context.StudentList.ToListAsync();
        }
    }
}
