using Hotel_Management_System.Data;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Numerics;

namespace Hotel_Management_System.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult start()
        {
            return View();
        }
        public IActionResult StaffLog()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StaffLog(StaffLog Model)
        {
            if (ModelState.IsValid)
            {

                if (Model.Name == "staff" && Model.Password == "12")
                {

                    return RedirectToAction( "StaffIndex", "Staff");
                }
                else
                {

                    ViewBag.ErrorMessage = "Invalid username or password!";
                }
            }
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(Staff obj)
        {
            if (ModelState.IsValid)
            {


                _context.Staff.Add(obj);
                _context.SaveChanges();
                return RedirectToAction(nameof(Registration));
            }
            return View();
        }
        public async Task<IActionResult> StaffIndex()
        {

            var staffList = await _context.Staff.ToListAsync();


            return View(staffList);
        }
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }
            var cat = await _context.Staff.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Staff Staff)
        {
            if (id != Staff.Sid)
            {
                return NotFound();
            }

            _context.Update(Staff);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(StaffIndex));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Staff' is null");
            }

            var staff = await _context.Staff.FindAsync(Id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(StaffIndex));
        }
        public IActionResult FoodReg()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> FoodReg(Food obj)
        {
            if (ModelState.IsValid)
            {


                _context.foods.Add(obj);
                _context.SaveChanges();
                return RedirectToAction(nameof(FoodReg));
            }
            return View();
        }

        public async Task<IActionResult> FoodIndex()
        {
            var q = from c in _context.foods where c.Status == "Request" select c;
            return View(q.ToList());
        }
        public async Task<IActionResult> Approve(int id)
        {
            _context.foods.Where(x => x.Fid == id)
            .ToList()
                .ForEach(x => x.Status = "Approve");
            _context.SaveChanges();
            return RedirectToAction(nameof(FoodIndex));
        }



        public IActionResult Roomreg()
        {
            List<Hotel> cl = new List<Hotel>();
            cl = (from c in _context.hotels select c).ToList();
            cl.Insert(0, new Hotel { Hid = 0, HotelName = "--Select Hotel Name--" });
            ViewBag.message = cl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Roomreg(ROOM Rooms)
        {
            _context.Add(Rooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Roomreg));

        }
        public async Task<IActionResult> RoomIndex()
        {

            var q = from c in _context.Rooms where c.Status == "Request" select c;
            return View(q.ToList());
        }
        public async Task<IActionResult> RoomApprove(int id)
        {
            _context.Rooms.Where(x => x.Rid == id)
            .ToList()
                .ForEach(x => x.Status = "Available");
            _context.SaveChanges();
            return RedirectToAction(nameof(RoomIndex));
        }
        public async Task<IActionResult> Service(int id)
        {
            _context.Rooms.Where(x => x.Rid == id)
            .ToList()
                .ForEach(x => x.Status = "Out Of Service");
            _context.SaveChanges();
            return RedirectToAction(nameof(RoomIndex));
        }
        public async Task<ActionResult> REdit(int id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }
            var cat = await _context.Rooms.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> REdit(int id, ROOM rooms)
        {
            if (id != rooms.Rid)
            {
                return NotFound();
            }

            _context.Update(rooms);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(RoomIndex));
        }

        public IActionResult Paymentreg()
        {
            List<User> cl = new List<User>();
            cl = (from c in _context.User select c).ToList();
            cl.Insert(0, new User { Uid = 0, Name = "--Select User Name--" });
            ViewBag.message = cl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Paymentreg(Payment product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Paymentreg));

        }




        public IActionResult logout()
        {
            return new RedirectResult(url: "/User/Login", permanent: true,
                preserveMethod: true);
        }

    }
}
