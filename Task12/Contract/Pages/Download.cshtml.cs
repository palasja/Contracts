using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayrollBLL.ModelsDTO;
using PayrollBLL.Services;

namespace Contract.Pages
{
    public class DownloadModel : PageModel
    {
        public IActionResult OnGetPayrollById(string id)
        {
            PayrollService ps = new PayrollService();
            LoadedFileDTO loadedFileDTO = ps.GetFileById(id);
            
            return File(loadedFileDTO.LoadFile, "application/force-download", loadedFileDTO.FileName);
        }
    }
}
