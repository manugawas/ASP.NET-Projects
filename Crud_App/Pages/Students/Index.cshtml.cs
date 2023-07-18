using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crud_App.Data;
using Crud_App.Model;

namespace Crud_App.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Crud_App.Data.Crud_AppContext _context;

        public IndexModel(Crud_App.Data.Crud_AppContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }
    }
}
