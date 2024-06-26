﻿using Microsoft.AspNetCore.Mvc;
using Waigaya2.Controllers.Request;
using Waigaya2.Data;
using Waigaya2.Models;

namespace Waigaya2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly WaigayaDbContext _context;

        public CategoriesController(WaigayaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// カテゴリ追加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] SaveCategory request)
        {
            //Insertしかしないけど、念のため確認
            var product = _context.Categories.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                _context.Categories.Add(new Category
                {
                    Title = request.Title,
                    CreatedAt = DateTime.Now,
                });
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
        /// <summary>
        /// カテゴリ追加
        /// </summary>
        /// <returns></returns>
        [Route("insertdemo")]
        public IActionResult InsertDemo()
        {
            var request = new SaveCategory
            {
                Title = "たいとる"
            };

            var product = _context.Categories.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                _context.Categories.Add(new Category
                {
                    Title = request.Title,
                    CreatedAt = DateTime.Now,
                });
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            //return RedirectToAction(nameof(Index));
            return Ok();
        }
    }
}
