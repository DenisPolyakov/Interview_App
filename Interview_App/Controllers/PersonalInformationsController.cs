using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interview_App.Models;

namespace Interview_App.Controllers
{
    public class PersonalInformationsController : Controller
    {
        private readonly PersonalInformationContext _context;

        public PersonalInformationsController(PersonalInformationContext context)
        {
            _context = context;
        }

        // GET: PersonalInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalInformation.ToListAsync());
        }

        // GET: PersonalInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            return View(personalInformation);
        }

        // GET: PersonalInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Patronymic,BirthDate,personalInformationXml")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInformation);

                personalInformation.personalInformationXml = "Not edited";

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalInformation);
        }

        // GET: PersonalInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformation.FindAsync(id);
            if (personalInformation == null)
            {
                return NotFound();
            }
            return View(personalInformation);
        }

        // POST: PersonalInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,BirthDate,personalInformationXml")] PersonalInformation personalInformation)
        {
            if (id != personalInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInformation);

                    personalInformation.personalInformationXml = "Edited";

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInformationExists(personalInformation.Id))
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
            return View(personalInformation);
        }

        // GET: PersonalInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            return View(personalInformation);
        }

        // POST: PersonalInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalInformation = await _context.PersonalInformation.FindAsync(id);
            _context.PersonalInformation.Remove(personalInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInformationExists(int id)
        {
            return _context.PersonalInformation.Any(e => e.Id == id);
        }
    }
}
