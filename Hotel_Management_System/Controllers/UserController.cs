using Hotel_Management_System.Data;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hotel_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(User obj)
        {
            if (ModelState.IsValid)
            {


                _context.User.Add(obj);
                _context.SaveChanges();
                return RedirectToAction(nameof(Register));
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(Log r)
        {
            if (ModelState.IsValid)
            {

                var filtered = from l in _context.User
                               where l.Email == r.Email && l.Password == r.Password
                               select l;
                foreach (var p in filtered)
                {

                    return new RedirectResult(url: "/User/Index", permanent: true,
                        preserveMethod: true);
                }

            }
            return View();

        }
       


        public async Task<IActionResult> Index()
        {

            var UserList = await _context.User.ToListAsync();


            return View(UserList);
        }
        public async Task<ActionResult> UserEdit(int id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }
            var cat = await _context.User.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(int id, User user)
        {
            if (id != user.Uid)
            {
                return NotFound();
            }

            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User' is null");
            }

            var user = await _context.User.FindAsync(Id);
            if (user != null)
            {
                _context.User.Remove(user);
            }


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> HotelIndex()
        {

            var hotelList = await _context.hotels.ToListAsync();


            return View(hotelList);
        }
        public async Task<IActionResult> FoodIndex()
        {

            var hotelList = await _context.foods.ToListAsync();


            return View(hotelList);
        }
        public async Task<IActionResult> PaymentIndex()
        {

            var hotelList = await _context.payments.ToListAsync();


            return View(hotelList);
        }
        public async Task<IActionResult> Payment(int id)
        {
            _context.payments.Where(x => x.Pid == id)
            .ToList()
                .ForEach(x => x.Status = "Payment Success");
            _context.SaveChanges();
            return RedirectToAction(nameof(PaymentIndex));
        }
        public async Task<IActionResult> Request(int id)
        {
            _context.foods.Where(x => x.Fid == id)
            .ToList()
                .ForEach(x => x.Status = "Request");
            _context.SaveChanges();
            return RedirectToAction(nameof(FoodIndex));
        }
        
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null || _context.foods == null)
            {
                return NotFound();
            }
            var cat = await _context.foods.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Food foods)
        {
            if (id != foods.Fid)
            {
                return NotFound();
            }

            _context.Update(foods);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(FoodIndex));
        }
       


        public async Task<IActionResult> RoomIndex()
        {

            var objregisterList = _context.Rooms.ToList();
             return View(objregisterList);
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
            List<Hotel> cl = new List<Hotel>();
            cl = (from c in _context.hotels select c).ToList();
            cl.Insert(0, new Hotel { Hid = 0, HotelName = "--Select Hotel Name--" });
            ViewBag.message = cl;
            return View(cat);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> REdit(int id, ROOM Rooms)
        {
            if (id != Rooms.Rid)
            {
                return NotFound();
            }

            _context.Update(Rooms);
            await _context.SaveChangesAsync();
            

            return RedirectToAction(nameof(RoomIndex));
        }
    




        public async Task<IActionResult> StaffIndex()
        {

            var objregisterList = _context.Staff.ToList();
            return View(objregisterList);
        }
        public async Task<IActionResult> RoomRequest(int id)
        {
            _context.Rooms.Where(x => x.Rid == id)
            .ToList()
                .ForEach(x => x.Status = "Request");
            _context.SaveChanges();
            return RedirectToAction(nameof(RoomIndex));
        }


        public IActionResult reviewreg()
        {
            List<Hotel> cl = new List<Hotel>();
            cl = (from c in _context.hotels select c).ToList();
            cl.Insert(0, new Hotel { Hid = 0, HotelName = "--Select Hotel Name--" });
            ViewBag.message = cl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> reviewreg(Review review)
        {
            _context.Add(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(reviewreg));

        }
        public IActionResult logout()
        {
            return new RedirectResult(url: "/Admin/AdminLogin", permanent: true,
                preserveMethod: true);
        }
    }
}
