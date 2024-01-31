using Backend_API.Data;
using Backend_API.Models;
using Backend_API.Models.Requests;
using Backend_API.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        // GET: api/<CategoryController>
        public CategoryController(AppDbContext context) {

            _context = context;


        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<GetCategoryResponse>> GetCategoryByIdItems(Guid id)
        {
            var categoryList = await _context.Categories.Select(x => new GetCategoryResponse
            {
                categoryID = x.categoryID,
                userID = x.userID,
                category = x.category


            }).Where(e => e.userID == id).ToListAsync();
            if(categoryList == null  )
            {
                var response1 = new ApiResponse<GetCategoryResponse>()
                {
                    statusCode = StatusCodes.Status404NotFound,
                    requestMethod = HttpContext.Request.Method,
                    massage = "Data Not Found!",
                    data = null
                };

                return Ok(response1);
            }
            Console.WriteLine(categoryList);
            var response = new ApiResponse<GetCategoryResponse>()
            {
                statusCode = StatusCodes.Status200OK,
                requestMethod = HttpContext.Request.Method,
                massage = "Data Found!",
                data = categoryList
            };
            return Ok(response);
        }
      
    
     

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<GetCategoryResponse>> PostCategory([FromBody] CreateCategoryRequest CreateCategoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCatergory = new Category
            {
                userID = CreateCategoryRequest.userID,
                category = CreateCategoryRequest.category
            };
            _context.Categories.Add(newCatergory);
            await _context.SaveChangesAsync();
            var response = new ApiResponse<GetCategoryResponse>()
            {
                statusCode = StatusCodes.Status201Created,
                requestMethod = HttpContext.Request.Method,
                massage = "Category Successfully Created!"
            };
            return Ok(response);




        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCategoryResponse>> Put(int id, [FromBody] UpdateCategoryRequest UpdateCategoryRequest)
        {
            if(!ModelState.IsValid) {


                return BadRequest(ModelState);
            }
            var category = await _context.Categories.FirstOrDefaultAsync(s => s.categoryID == id);
            if (category == null)
            {
                var response1 = new ApiResponse<UpdateCategoryResponse>()
                {
                    statusCode = StatusCodes.Status404NotFound,
                    requestMethod = HttpContext.Request.Method,
                    massage = "Category Not Found"
                };
                return NotFound(response1);
            }
            category.category = UpdateCategoryRequest.category;
            await _context.SaveChangesAsync();
            var response = new ApiResponse<UpdateCategoryResponse>()
            {
                statusCode = StatusCodes.Status200OK,
                requestMethod = HttpContext.Request.Method,
                massage = "Update Successfully!"
            };
            
            return Ok(response);
            

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCategoryResponse>> Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(s => s.categoryID==id);
            if( category == null)
            {
                var response1 = new ApiResponse<DeleteCategoryResponse>()
                {
                    statusCode = StatusCodes.Status404NotFound,
                    requestMethod = HttpContext.Request.Method,
                    massage = "Category Not Found"
                };
                return NotFound(response1);
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            var response = new ApiResponse<DeleteCategoryResponse>()
            {
                statusCode = StatusCodes.Status200OK,
                requestMethod = HttpContext.Request.Method,
                massage = "Delete Successfully!"
            };
            return Ok(response);

        }
    }
}
