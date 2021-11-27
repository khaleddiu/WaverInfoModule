using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Waver_InfoApp.Entities;

namespace Waver_InfoApp.Controllers
{
    public class SmisWaiverInfoesController : Controller
    {
        private readonly ERPContext _context;

        public SmisWaiverInfoesController(ERPContext context)
        {
            _context = context;
        }

        // GET: SmisWaiverInfoes
        public async Task<IActionResult> Index()
        {
            var eRPContext = _context.SmisWaiverInfo.Include(s => s.Student);
            return View(await eRPContext.ToListAsync());
        }

        // GET: SmisWaiverInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smisWaiverInfo = await _context.SmisWaiverInfo
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (smisWaiverInfo == null)
            {
                return NotFound();
            }

            return View(smisWaiverInfo);
        }

        // GET: SmisWaiverInfoes/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.SmisStudent, "StudentId", "StudentId");
            ViewBag.msg = "";
            return View();
        }

        // POST: SmisWaiverInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file)
        {
            if (file == null)
            {
                ViewBag.msg = "Please Select an Excel File";
                return View();
            }
            var WaverList = new List<SmisWaiverInfo>();
            var NoIdWaverList = new List<SmisWaiverInfo>();

            using (var Stream = new MemoryStream())
            {
                await file.CopyToAsync(Stream);

                using (var Package = new ExcelPackage(Stream))
                {
                    ExcelWorksheet worksheet = Package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;

                    

                    for (int row = 2; row <= rowcount; row++)
                    {
                        if (worksheet.Cells[row, 1].Value != null && worksheet.Cells[row, 2].Value != null)
                        {

                            SmisWaiverInfo waver = new SmisWaiverInfo();

                            waver.StudentId = worksheet.Cells[row, 1].Value.ToString().Trim();
                            waver.WaiverPercent = Convert.ToDouble(worksheet.Cells[row, 2].Value.ToString().Trim());
                            waver.Yn = worksheet.Cells[row, 3].Value.ToString().Trim();
                            waver.CreatedBy = worksheet.Cells[row, 4].Value.ToString().Trim();
                            waver.CreatedTime = null;
                            //waver.CreatedTime = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 5].Value.ToString().Trim()));
                            waver.ModifiedBy = worksheet.Cells[row, 6].Value.ToString().Trim();
                            //waver.ModifiedTime = DateTime.FromOADate(Convert.ToDouble(worksheet.Cells[row, 7].Value.ToString().Trim()));
                            waver.ModifiedTime = null;

                            var stu = await _context.SmisStudent.FirstOrDefaultAsync(x => x.StudentId == waver.StudentId);
                            var waverstu = await _context.SmisWaiverInfo.FirstOrDefaultAsync(x => x.StudentId == waver.StudentId);
                            var stulist = WaverList.FirstOrDefault(x => x.StudentId == waver.StudentId);
                            if (waver.StudentId != null &&  stu != null && waverstu == null && stulist == null)
                            {                            
                                WaverList.Add(waver);
                            }
                            else
                            {
                                NoIdWaverList.Add(waver);
                                
                            }
                               
                        }

                    }
                }
            }


            

            if (WaverList!=null)
            {
                _context.BulkInsert(WaverList);
                await _context.SaveChangesAsync();

                ViewBag.msg = "Insert is Done But some data could not be inserted would be given below";
                return View(NoIdWaverList);
            }

            return View(NoIdWaverList);
        }

        public IActionResult UpdateWaver()
        {
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateWaver(IFormFile file)
        {
            if (file == null)
            {
                ViewBag.msg = "Please Select an Excel File";
                return View();
            }
            var WaverList = new List<SmisWaiverInfo>();
            var NoIdWaverList = new List<SmisWaiverInfo>();

            using (var Stream = new MemoryStream())
            {
                await file.CopyToAsync(Stream);

                using (var Package = new ExcelPackage(Stream))
                {
                    ExcelWorksheet worksheet = Package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;



                    for (int row = 2; row <= rowcount; row++)
                    {
                        if (worksheet.Cells[row, 1].Value != null && worksheet.Cells[row, 2].Value != null)
                        {

                            SmisWaiverInfo waver = new SmisWaiverInfo();

                            waver.StudentId = worksheet.Cells[row, 1].Value.ToString().Trim();
                            waver.WaiverPercent = Convert.ToDouble(worksheet.Cells[row, 2].Value.ToString().Trim());
                            waver.Yn = worksheet.Cells[row, 3].Value.ToString().Trim();
                            waver.CreatedBy = worksheet.Cells[row, 4].Value.ToString().Trim();
                            waver.CreatedTime = null;
                            waver.ModifiedBy = worksheet.Cells[row, 6].Value.ToString().Trim();
                            waver.ModifiedTime = null;

                            var stu = await _context.SmisStudent.FirstOrDefaultAsync(x => x.StudentId == waver.StudentId);
                            var waverstu = await _context.SmisWaiverInfo.FirstOrDefaultAsync(x => x.StudentId == waver.StudentId);
                            var stulist = WaverList.FirstOrDefault(x => x.StudentId == waver.StudentId);
                            if (waver.StudentId != null && stu != null && waverstu != null && stulist == null)
                            {
                                WaverList.Add(waver);
                            }
                            else
                            {
                                NoIdWaverList.Add(waver);

                            }

                        }

                    }
                }
            }




            if (WaverList != null)
            {
                _context.BulkUpdate(WaverList);
                await _context.SaveChangesAsync();

                ViewBag.msg = "Update is Done But some data could not be Updated would be given below";
                return View(NoIdWaverList);
            }

            return View(NoIdWaverList);
        }

        // POST: SmisWaiverInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,WaiverPercent,Yn,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime")] SmisWaiverInfo smisWaiverInfo)
        {
            if (id != smisWaiverInfo.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smisWaiverInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmisWaiverInfoExists(smisWaiverInfo.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.SmisStudent, "StudentId", "StudentId", smisWaiverInfo.StudentId);
            return View(smisWaiverInfo);
        }

        // GET: SmisWaiverInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smisWaiverInfo = await _context.SmisWaiverInfo
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (smisWaiverInfo == null)
            {
                return NotFound();
            }

            return View(smisWaiverInfo);
        }

        // POST: SmisWaiverInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var smisWaiverInfo = await _context.SmisWaiverInfo.FindAsync(id);
            _context.SmisWaiverInfo.Remove(smisWaiverInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmisWaiverInfoExists(string id)
        {
            return _context.SmisWaiverInfo.Any(e => e.StudentId == id);
        }
    }
}
