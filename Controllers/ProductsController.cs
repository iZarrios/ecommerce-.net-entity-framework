using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using electronics_shop_mvc_1.Areas.Identity.Data;
using electronics_shop_mvc_1.Models;
using System.Net;
using System.Security.Claims;
using electronics_shop_mvc_1.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace electronics_shop_mvc_1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hosting;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hosting,
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _hosting = hosting;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts(int pg = 1)
        {
            var data = await _context.Products.Include(p => p.Category).ToListAsync();

            

            // const int pageSize = 5;
            //
            // if (pg < 1)
            //     pg = 1;
            //
            // int recsCount = applicationDbContext.Count();
            //
            // var pager = new Pager(recsCount, pg, pageSize);
            //
            // int recSkip = (pg - 1) * pageSize;
            //
            // var data = applicationDbContext.Skip(recSkip).Take(pager.PageSize).ToList();
            //
            // this.ViewBag.Pager = pager;

            return data;
        }

        // GET: Products
        public async Task<IActionResult> Index(int pg = 1)
        {
            var applicationDbContext = await _context.Products.Include(p => p.Category).ToListAsync();

            const int pageSize = 5;

            if (pg < 1)
                pg = 1;

            int recsCount = applicationDbContext.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = applicationDbContext.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        public async Task<IActionResult> Configure()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            WebRequest request = WebRequest.Create("https://random.imagecdn.app/v1/image?width=750&height=750");

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            ProductViewModel p = new();
            // p.ProductImage = responseFromServer;
            ViewData["CategoryId"] = new SelectList(_context.Set<ProductCategory>(), "CategoryId", "Name");
            return View(p);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                ;
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                var product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    Category = model.Category,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    ProductId = model.ProductId,
                    RegistrationDiscount = model.RegistrationDiscount,
                    MultiUnitDiscount = model.MultiUnitDiscount,
                    ProductImage = fileName, //TODO: maybe add default ~/upalods/ for random and uplaoded files to work 
                };
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] =
                new SelectList(_context.Set<ProductCategory>(), "CategoryId", "Name", model.CategoryId);
            return View(model);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] =
                new SelectList(_context.Set<ProductCategory>(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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

            ViewData["CategoryId"] =
                new SelectList(_context.Set<ProductCategory>(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }

            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Configure));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Buy(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }


            // var product = await _context.Products.FindAsync(id);

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = new Order();
            order.ProductId = product.ProductId;
            order.CreatedAt = DateTime.Now;
            order.UserId = currentUserId;

            return View(order);
        }


        [HttpPost]
        public async Task<IActionResult> Buy(int id, Order order)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.ProductId = id;
            order.CreatedAt = DateTime.Now;
            order.UserId = currentUserId;
            order.OrderId = 0;

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            decimal totalDiscount = 0;

            if (order.Quantity > product.Quantity)
            {
                return RedirectToAction("Index");
            }

            if (User.Identity.IsAuthenticated)
            {
                totalDiscount += product.RegistrationDiscount;
            }

            if (order.Quantity > 1)
            {
                totalDiscount += product.MultiUnitDiscount;
            }

            order.TotalPrice = order.Quantity * product.Price;
            order.TotalPrice = order.TotalPrice - order.TotalPrice * (totalDiscount / 100);
            product.Quantity -= order.Quantity;
            //ModelState.IsValid
            if (order.Quantity > 0)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Orders");
            }

            return View(order);
        }
    }
}