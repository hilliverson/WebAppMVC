using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models;
using WebAppMVC.Models.ViewModel.Employees;

namespace WebAppMVC.Controllers
{
    public class FriendsController : Controller
    {
        private readonly FriendContext _context;

        public FriendsController(FriendContext context)
        {
            _context = context;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            List<SiteInfo> siteInfos = new List<SiteInfo>
              {
                  new SiteInfo{ siteId=1, siteName="新案件", cards=new List<Card>
                  {
                      new Card{ }
                  } },
                  new SiteInfo{ siteId=2, siteName="報價簽核" },
                  new SiteInfo{ siteId=3, siteName="Erp開單" },
                  new SiteInfo{ siteId=4, siteName="齊料" },
                  new SiteInfo{ siteId=5, siteName="入庫"}
              };
            return View(siteInfos); 
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friends = await _context.Friends
                .FirstOrDefaultAsync(m => m.id == id);
            if (friends == null)
            {
                return NotFound();
            }

            return View(friends);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,phone,email,city")] Friends friends)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friends);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friends);
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friends = await _context.Friends.FindAsync(id);
            if (friends == null)
            {
                return NotFound();
            }
            return View(friends);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,phone,email,city")] Friends friends)
        {
            if (id != friends.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friends);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendsExists(friends.id))
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
            return View(friends);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friends = await _context.Friends
                .FirstOrDefaultAsync(m => m.id == id);
            if (friends == null)
            {
                return NotFound();
            }

            return View(friends);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Friends == null)
            {
                return Problem("Entity set 'FriendContext.Friends'  is null.");
            }
            var friends = await _context.Friends.FindAsync(id);
            if (friends != null)
            {
                _context.Friends.Remove(friends);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendsExists(int id)
        {
          return (_context.Friends?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
