using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fyp.Data;
using Fyp.Models;

namespace Fyp.Controllers
{
    public class KycsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KycsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kycs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KycDetails.ToListAsync());
        }

        // GET: Kycs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kyc = await _context.KycDetails
                .FirstOrDefaultAsync(m => m.userID == id);
            if (kyc == null)
            {
                return NotFound();
            }

            return View(kyc);
        }

        // GET: Kycs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kycs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,FatherFirstName,FatherLastName,SpouseFirstName,SpouseLastName,MaritialStatus,Dob,Gender,Nationality,ResidentalStatus,pan,StreetAddress,StreetAddress2,City,State,ZipCode,Country,Phone,Email,PhotoProof")] Kyc kyc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kyc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kyc);
        }

        // GET: Kycs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kyc = await _context.KycDetails.FindAsync(id);
            if (kyc == null)
            {
                return NotFound();
            }
            return View(kyc);
        }

        // POST: Kycs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,FatherFirstName,FatherLastName,SpouseFirstName,SpouseLastName,MaritialStatus,Dob,Nationality,ResidentalStatus,pan,StreetAddress,StreetAddress2,City,State,ZipCode,Country,Phone,Email,PhotoProof")] Kyc kyc)
        {
            if (id != kyc.userID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kyc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KycExists(kyc.userID))
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
            return View(kyc);
        }

        // GET: Kycs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kyc = await _context.KycDetails
                .FirstOrDefaultAsync(m => m.userID == id);
            if (kyc == null)
            {
                return NotFound();
            }

            return View(kyc);
        }

        public async Task<IActionResult> Index1()
        {
            return View();
        }

        // POST: Kycs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kyc = await _context.KycDetails.FindAsync(id);
            if (kyc != null)
            {
                _context.KycDetails.Remove(kyc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KycExists(int id)
        {
            return _context.KycDetails.Any(e => e.userID == id);
        }
    }
}
