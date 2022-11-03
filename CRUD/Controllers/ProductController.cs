using CRUD.DataAccess.Repository.IRepository;
using CRUD.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> prodList = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category,Brand");
            return View(prodList);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(Guid id)
        {
            Product prod = new();
            if (id == Guid.Empty)
            {
                prod.CategoryList = await _unitOfWork.Product.DropDownList("Category");
                prod.BrandList = await _unitOfWork.Product.DropDownList("Brand");
                return View(prod);
            }
            else
            {
                var prodItem = await _unitOfWork.Product.FirstOrDefaultAsync(x => x.Id == id);
                prodItem.CategoryList = await _unitOfWork.Product.DropDownList("Category");
                prodItem.BrandList = await _unitOfWork.Product.DropDownList("Brand");
                return View(prodItem);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Upsert(Product product)
        {
            if(product.Id == Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Product.AddAsync(product);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Product.Update(product);
                }
            }
            await _unitOfWork.Product.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id != Guid.Empty)
            {
                var prodDel = await _unitOfWork.Product.FirstOrDefaultAsync(x => x.Id == id);
                prodDel.CategoryList = await _unitOfWork.Product.DropDownList("Category");
                prodDel.BrandList = await _unitOfWork.Product.DropDownList("Brand");
                return View(prodDel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product prod)
        {
            if(prod.Id != Guid.Empty)
            {
               await _unitOfWork.Product.Remove(prod);
            }
            else
            {
                return NotFound();
            }
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
