using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoApp.Contracts;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoItemsController : Controller
    {
        private readonly IToDoRepository _repo;
        private readonly IMapper _mapper;

        public ToDoItemsController(IToDoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: ToDoItems
        public ActionResult Index()
        {
            var ToDoItems = _repo.FindAll().ToList();
            var model = _mapper.Map<List<ToDoItem>, List<ToDoItemVM>>(ToDoItems);
            return View(model);
        }

        // GET: ToDoItems/Details/5
        public ActionResult Details(int Id)
        {
            var ToDoItem = _repo.FindById(Id);
            var model = _mapper.Map<ToDoItemVM>(ToDoItem);
            return View(model);
        }

        // GET: ToDoItems/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ToDoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoItemVM model)
        {
            try
            {
                var ToDoItem = _mapper.Map<ToDoItem>(model);
                var isSuccess =  _repo.Create(ToDoItem);
                if(!isSuccess)
                {
                    ModelState.AddModelError("","Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItems/Edit/5
        public ActionResult Edit(int Id)
        {
            if (!_repo.isExists(Id))
            {
                return NotFound();
            }
            
            var ToDoItem = _repo.FindById(Id);
            var model = _mapper.Map<ToDoItemVM>(ToDoItem);
            return View(model);

            
        }

        // POST: ToDoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDoItemVM model)
        {
            var ToDoItem = _mapper.Map<ToDoItem>(model);
            var isSuccess = _repo.Update(ToDoItem);
            if (!isSuccess)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));


        }

        // GET: ToDoItems/Delete/5
        public ActionResult Delete(int Id, ToDoItemVM model)
        {
            var ToDoItem = _repo.FindById(Id);
            var isSuccess = _repo.Delete(ToDoItem);
            if (!isSuccess)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: ToDoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}