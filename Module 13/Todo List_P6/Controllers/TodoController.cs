using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo_List_P6.Models;

namespace Todo_List_P6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly TodoAppContext _context;
        public TodoController(TodoAppContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllTodos() 
        {
            try
            {
                var todos = await _context.TodoItems.ToListAsync();
                return Ok(todos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while retrieving Todos.",
                    Details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _context.TodoItems.FindAsync(id);
                if (todo == null)
                {
                    return NotFound(new
                    {
                        Message = $"Todo for ID {id} not found."
                    });
                }
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while retrieving Todo.",
                    Details = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult>
            CreateTodo([FromBody] TodoItem todoItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _context.TodoItems.AddAsync(todoItem);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTodoById), new
                {
                    id = todoItem.Id,
                }, todoItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the todo.", Details = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoItem todoItem)
        {
            try
            {
                if (id != todoItem.Id)
                {
                    return BadRequest("Todo Id mismatch");
                }
                var foundTodo = await _context.TodoItems.FindAsync(id);
                if (foundTodo == null)
                {
                    return NotFound(new
                    {
                        Message = $"Todo For ID {id} not found."
                    });
                }
                foundTodo.Title = todoItem.Title;
                foundTodo.Date = todoItem.Date;
                foundTodo.isCompleted = todoItem.isCompleted;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the Todo.", Details = ex.InnerException?.Message ?? ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the Todo.", Details = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            try
            {
                var todo = await _context.TodoItems.FindAsync(id);
                if (todo == null)
                {
                    return NotFound(new
                    {
                        Message = $"Todo with ID {id} not found."
                    });
                }
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while deleting the Todo.",
                    Details = ex.Message
                });
            }
        }
        [HttpHead]
        [Route("{id}")]
        public async Task<IActionResult> HeadTodo(int id)
        {
            try
            {
                var todoExists = await _context.TodoItems.AnyAsync(td => td.Id == id);
                if (!todoExists)
                {
                    return NotFound(new
                    {
                        Message = $"Todo does not exists for ID {id}."
                    });
                }
                Response.Headers.Append("Content-Type", "application/json");
                var contentLength = System.Text.Json.JsonSerializer.Serialize(todoExists).Length;
                Response.Headers.Append("Content-Length", contentLength.ToString());

                Response.Headers.Append("X-Custom-Header", "CustomHeaderValue");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving product metadata.", Details = ex.Message });
            }
        }

        [HttpOptions]
        public IActionResult GetOptions()
        {
            try
            {
                Response.Headers.Append("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS, HEAD");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving options.", Details = ex.Message });
            }
        }
    }
}
