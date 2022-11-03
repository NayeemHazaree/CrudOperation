using CRUD.DataAccess.Repository.IRepository;
using CRUD.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Brand> brands = await _unitOfWork.Brand.GetAllAsync();
            return View(brands);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(Guid id)
        {
            Brand brand = new Brand();
            if (id == Guid.Empty)
            {
                return View(brand);
            }
            else
            {
                var brItem = await _unitOfWork.Brand.FirstOrDefaultAsync(x => x.Id == id);
                if(brItem != null)
                {
                    return View(brItem);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Brand brand)
        {
            if(brand.Id == Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Brand.AddAsync(brand);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Brand.Update(brand);
                }
            }
            await _unitOfWork.Brand.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            if(id != Guid.Empty)
            {
                var brItem = await _unitOfWork.Brand.FirstOrDefaultAsync(x => x.Id == id);
                return View(brItem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Brand brand)
        {
            if(brand.Id != Guid.Empty)
            {
                var delBr = await _unitOfWork.Brand.FirstOrDefaultAsync(x => x.Id == brand.Id);
                await _unitOfWork.Brand.Remove(delBr);
                await _unitOfWork.Brand.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
