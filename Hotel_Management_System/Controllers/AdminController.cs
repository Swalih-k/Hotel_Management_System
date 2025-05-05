using Hotel_Management_System.Data;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(AdminLogin Model)
        {
            if (ModelState.IsValid)
            {

                if (Model.Name == "admin" && Model.Password == "12")
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ViewBag.ErrorMessage = "Invalid username or password!";
                }
            }
            return View();
        }

        public IActionResult RegisterHotel()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RegisterHotel(Hotel obj)
        {
            if (ModelState.IsValid)
            {


                _context.hotels.Add(obj);
                _context.SaveChanges();
                return RedirectToAction(nameof(RegisterHotel));
            }
            return View();
        }
       

        public async Task<IActionResult> HotelIndex()
        {

            var hotelList = await _context.hotels.ToListAsync();


            return View(hotelList);
        }
        public async Task<IActionResult> StaffIndex()
        {

            return View(await _context.Staff.ToListAsync());
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
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null || _context.hotels == null)
            {
                return NotFound();
            }
            var cat = await _context.hotels.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hotel hotels)
        {
            if (id != hotels.Hid)
            {
                return NotFound();
            }

            _context.Update(hotels);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(HotelIndex));
        }
        public async Task<IActionResult> Index()
        {

            var UserList = await _context.User.ToListAsync();


            return View(UserList);
        }
        public async Task<IActionResult> Delete1(int Id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User' is null");
            }

            var staff = await _context.User.FindAsync(Id);
            if (staff != null)
            {
                _context.User.Remove(staff);
            }


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> FoodIndex()
        {

            var hotelList = await _context.foods.ToListAsync();


            return View(hotelList);
        }
        public async Task<IActionResult> RoomIndex()
        {

            var hotelList = await _context.Rooms.ToListAsync();


            return View(hotelList);
        }
        public async Task<IActionResult> Review()
        {

            var hotelList = await _context.reviews.ToListAsync();


            return View(hotelList);
        }
        public async Task<ActionResult> ReviewEdit(int id)
        {
            if (id == null || _context.reviews == null)
            {
                return NotFound();
            }
            var cat = await _context.reviews.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewEdit(int id, Review review)
        {
            if (id != review.Reviewid)
            {
                return NotFound();
            }

            _context.Update(review);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Review));
        }
        public async Task<IActionResult> Payment()
        {

            var hotelList = await _context.payments.ToListAsync();


            return View(hotelList);
        }
        public IActionResult logout()
        {
            return new RedirectResult(url: "/Staff/StaffLog", permanent: true,
                preserveMethod: true);
        }

    }
}
