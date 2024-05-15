﻿using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class todoController : ControllerBase
    {
        private readonly TodoDbContext _todoDbContext;
        public todoController(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoDbContext.Todos.ToListAsync();
            return Ok(todos);
        }
        [HttpPost]
        public async Task<IActionResult> AddTodo(todo Todo)
        {
            Todo.Id = Guid.NewGuid();
            _todoDbContext.Todos.Add(Todo);
            await _todoDbContext.SaveChangesAsync();
            return Ok(Todo);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoById(Guid id)
        {
            var todoToDelete = await _todoDbContext.Todos.FindAsync(id);

            if (todoToDelete == null)
            {
                return NotFound();
            }

            _todoDbContext.Todos.Remove(todoToDelete);
            await _todoDbContext.SaveChangesAsync();

            return Ok(todoToDelete);
        }

        // Inside your todoController
        [HttpPut("{id}")]
        public async Task<IActionResult> ToggleTodoIsCompleted(Guid id)
        {
            var todoToUpdate = await _todoDbContext.Todos.FindAsync(id);

            if (todoToUpdate == null)
            {
                return NotFound();
            }

            todoToUpdate.IsCompleted = !todoToUpdate.IsCompleted; // Toggle the isCompleted property
            await _todoDbContext.SaveChangesAsync();

            return Ok(todoToUpdate);
        }




    }
}
