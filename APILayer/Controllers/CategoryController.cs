using APILayer.Dal.ApiContext;
using APILayer.Dal.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        public IActionResult CategoryList()
        {
           using var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryId(int id)
        {
            using var c = new Context();
            //var value = c.Categories.Find(id);
            var value = c.Categories.FirstOrDefault(x=>x.CategoryId==id);

            if (value==null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryDto p)
        {
            using var c = new Context();
            Category category = new Category()
            {
                CategoryName = p.CategoryName,
            };
            c.Categories.Add(category);
            c.SaveChanges();
            return Created("", category);

        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var values = c.Categories.FirstOrDefault(x=>x.CategoryId==id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }
           

        }

        [HttpPut]
        public IActionResult CategoryUpdate(CategoryUpdateDto p)
        {
            using var c = new Context();
           var values = c.Categories.FirstOrDefault(x=>x.CategoryId==p.CategoryId);
            values.CategoryName=p.CategoryName;
            values.CategoryId=p.CategoryId;

            c.SaveChanges();
            return Ok();

        }
    }
    public class CategoryDto
    {
        public string CategoryName { get; set; }
   
    }

    public class CategoryUpdateDto
    {
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }

    }
}
