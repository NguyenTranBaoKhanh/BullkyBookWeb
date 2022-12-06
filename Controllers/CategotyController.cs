using BullkyBookWeb.Data;
using BullkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Controllers;
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> categoryList = _db.Categories;
        return View(categoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");

        }
        return View(obj);
    }

    public IActionResult Edit(int id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        // var categoryFist = _db.Categories.FirstOrDefault(x => x.Id == id);
        // var categorySingle = _db.Categories.SingleOrDefault(x => x.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();

        }
        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");

        }
        return View(obj);
    }

    public IActionResult Delete(int id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        // var categoryFist = _db.Categories.FirstOrDefault(x => x.Id == id);
        // var categorySingle = _db.Categories.SingleOrDefault(x => x.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();

        }
        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int id)
    {
        var obj = _db.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}