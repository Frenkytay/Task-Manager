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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var userList = _context.Users.Select(x => new User
            {
                userID = x.userID,
                userName = x.userName,
                userEmail = x.userEmail,
                userPassword = x.userPassword,

            });
            return userList.ToList();
        }

        // GET api/<UserController>/5
      /*  [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> Get(int id)
        {
            var userAcc = await _context.Users.Select(x => new GetUserResponse
            {
                userID = x.userID,
                userName = x.userName,
                userEmail = x.userEmail,
                userPassword = x.userPassword,

            }).Where(e => e.userID == id ).ToListAsync();
            
            if (userAcc == null)
            {
                var response1 = new ApiResponse<GetUserResponse>()
                {
                    statusCode = StatusCodes.Status404NotFound,
                    requestMethod = HttpContext.Request.Method,
                    massage = "Data Not Found!",
                    data = null
                };
                return Ok(response1);
            }
            var response = new ApiResponse<GetUserResponse>()
            {
                statusCode = StatusCodes.Status200OK,
                requestMethod = HttpContext.Request.Method,
                massage  = "Data Found!",
                data = userAcc
            };
            return Ok(response);
         
        }
      */
        [HttpPost("/Login")]
        public async Task<ActionResult<GetUserResponse>> PostLogin([FromBody] LoginUserRequest LoginUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       
            var login = await _context.Users.Select(x => new User
            {
                userID = x.userID,
                userName = x.userName,
                userEmail = x.userEmail,
                userPassword = x.userPassword,
            }).Where(u => u.userEmail == LoginUserRequest.userEmail && u.userPassword == LoginUserRequest.userPassword).ToListAsync();
            
            if(login.Count() == 0)
            {
                var response1 = new ApiResponse<User>()
                {
                    statusCode = StatusCodes.Status401Unauthorized,
                    requestMethod = HttpContext.Request.Method,
                    massage = "Wrong Username or Password!"
                };
                return Ok(response1);
            }
            
            var response = new ApiResponse<User>()
            {
                statusCode = StatusCodes.Status200OK,
                requestMethod = HttpContext.Request.Method,
                massage = "Successfully Login!",
                data = login
            };
            return Ok(response);


        }
        // POST api/<UserController>
        [HttpPost("/Register")]
        public  async Task<IActionResult> Post([FromBody] UserRequest CreateUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(CreateUserRequest.userPassword != CreateUserRequest.userConfirmPassword)
            {
                var response1 = new ApiResponse<GetUserResponse>()
                {
                    statusCode = StatusCodes.Status409Conflict,
                    requestMethod = HttpContext.Request.Method,
                    massage = "Password and Confirm Password Not Match!"
                };
                return NotFound(response1);
            }
            var checkEmail = _context.Users.Where(x => x.userEmail == CreateUserRequest.userEmail).Count();

            if(checkEmail > 0)
            {
                var response1 = new ApiResponse<GetUserResponse>()
                {
                    statusCode = StatusCodes.Status409Conflict,
                    requestMethod = HttpContext.Request.Method,
                    massage = "User Email Already Exists!"
                };
                return NotFound(response1);
            }
            var userAcc = new User
            {
                userName = CreateUserRequest.userName,
                userEmail = CreateUserRequest.userEmail,
                userPassword = CreateUserRequest.userPassword
            };
            _context.Users.Add(userAcc);
            await _context.SaveChangesAsync();
            var response = new ApiResponse<GetUserResponse>()
            {
                statusCode = StatusCodes.Status201Created,
                requestMethod = HttpContext.Request.Method,
                massage = "User Successfully Created!"
               
            };
            return Ok(response);


        }

        
    }
}
