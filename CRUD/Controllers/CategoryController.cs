using CRUD.DataAccess.Repository.IRepository;
using CRUD.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> CatList = await _unitOfWork.Category.GetAllAsync();
            return View(CatList);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(Guid id)
        {
            Category cat = new();
            if(id == Guid.Empty)
            {
                return View(cat);
            }
            else
            {
                var categoryItem = await _unitOfWork.Category.FirstOrDefaultAsync(x => x.Id == id);
                return View(categoryItem);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if(obj.Id == Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Category.AddAsync(obj);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Category.Update(obj);
                }
            }
            await _unitOfWork.Category.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _unitOfWork.Category.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category obj)
        {
            if(obj.Id != Guid.Empty)
            {
                var item = await _unitOfWork.Category.FirstOrDefaultAsync(x => x.Id == obj.Id);
                await _unitOfWork.Category.Remove(item);
                await _unitOfWork.Category.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}
