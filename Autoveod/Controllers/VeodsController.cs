using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autoveod.Data;
using Autoveod.Models;

namespace Autoveod.Controllers
{
    public class VeodsController : Controller
    {
        private readonly AutoveodContext _context;

        public VeodsController(AutoveodContext context)
        {
            _context = context;
        }

        // GET: Veods
        public async Task<IActionResult> Index()

        {
            return View(await _context.Veod.ToListAsync());
        }

        public async Task<IActionResult> Kõik()

        {
            var model = _context.Veod.OrderBy(e => e.Valmis).ThenBy(e=>e.Autonr).ThenBy(e=>e.JuhtEesnimi).ThenBy(e=>e.JuhtPerenimi);
            return View(await model.ToListAsync());
        }
        // GET: veods/juhita
        public async Task<IActionResult> Juhita()
        {

            var model = _context.Veod.Where(e => e.JuhtPerenimi==null);
            return View(await model.ToListAsync());
        }



        // GET: veods/juhita
        public async Task<IActionResult> Tegemata()
        {

            var model = _context.Veod.Where(e => e.Valmis == null && e.Autonr!=null);
            return View(await model.ToListAsync());
        }
        // GET: Veods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veod = await _context.Veod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veod == null)
            {
                return NotFound();
            }

            return View(veod);
        }

        // GET: Veods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Algus,Ots,Aeg,Autonr,JuhtEesnimi,JuhtPerenimi,Valmis")] Veod veod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veod);
        }

        // GET: Veods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veod = await _context.Veod.FindAsync(id);
            if (veod == null)
            {
                return NotFound();
            }
            return View(veod);
        }

        // POST: Veods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Algus,Ots,Aeg,Autonr,JuhtEesnimi,JuhtPerenimi,Valmis")] Veod veod)
        {
            if (id != veod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeodExists(veod.Id))
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
            return View(veod);
        }

        // GET: Veods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veod = await _context.Veod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veod == null)
            {
                return NotFound();
            }

            return View(veod);
        }

        // POST: Veods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veod = await _context.Veod.FindAsync(id);
            _context.Veod.Remove(veod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeodExists(int id)
        {
            return _context.Veod.Any(e => e.Id == id);
        }





        // GET: Veods/Create
        public IActionResult Telli()
        {
            return View();
        }

        // POST: Veods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Telli([Bind("Id,Nimi,Algus,Ots,Aeg,Autonr,JuhtEesnimi,JuhtPerenimi,Valmis")] Veod veod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veod);
        
        }




        // GET: Veods/Uuenda/5
        public async Task<IActionResult> Uuenda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veod = await _context.Veod.FindAsync(id);
            if (veod == null)
            {
                return NotFound();
            }
            return View(veod);
        }




        public async Task<IActionResult> Valmis(int Id)
        {
            var veod = await _context.Veod.FindAsync(Id);
            if (veod == null)
            {
                return NotFound();
            }
            veod.Valmis = "Tehtud";
            try
            {
                _context.Update(veod);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeodExists(veod.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return RedirectToAction("Tegemata");
        }




        // POST: Veods/uuenda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Uuenda(int id, [Bind("Id,Nimi,Algus,Ots,Aeg,Autonr,JuhtEesnimi,JuhtPerenimi,Valmis")] Veod veod)
        {
            if (id != veod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeodExists(veod.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Kõik));
            }
            return View(veod);
        }

    }
}
