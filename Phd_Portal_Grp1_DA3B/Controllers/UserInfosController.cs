using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd_Portal_Grp1_DA3B.Data;
using Phd_Portal_Grp1_DA3B.Models;

namespace Phd_Portal_Grp1_DA3B.Controllers
{
    public class UserInfosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserInfosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserInfos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userinfo.ToListAsync());
        }

        // GET: UserInfos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.Userinfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: UserInfos/Create
        public IActionResult Create()
        {
            var list = new List<string>() { "Admin", "Professor", "Student" };
            // send data from action method to View
            ViewBag.list = list;
            UserInfo usr = new UserInfo()
            {
                RoleType = "Student"
            };
            return View(usr);
        }

        // POST: UserInfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInfo);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = userInfo.Name + " is successfully registered";
                //return RedirectToAction(nameof(Index));
            }
            var list = new List<string>() { "Admin", "Professor", "Student" };
            // send data from action method to View
            ViewBag.list = list;
            return View(userInfo);
        }

        // GET: UserInfos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.Userinfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,UserEmail,Name,Password,Phone,Gender,RoleType")] UserInfo userInfo)
        {
            if (id != userInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.UserId))
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
            return View(userInfo);
        }

        // GET: UserInfos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.Userinfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: UserInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInfo = await _context.Userinfo.FindAsync(id);
            _context.Userinfo.Remove(userInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return _context.Userinfo.Any(e => e.UserId == id);
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserInfo user)
        {
            var account = _context.Userinfo.Where(u => u.UserName == user.UserName && u.Password == user.Password)
                .FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserId", account.UserId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName);
                if (account.RoleType == "Student"){
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    return RedirectToAction("Index", "Professors");
                }
            }
            else
            {
                ModelState.AddModelError("", "username or password is wrong");
            }
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
