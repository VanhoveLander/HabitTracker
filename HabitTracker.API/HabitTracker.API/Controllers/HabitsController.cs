using HabitTracker.API.Data;
using HabitTracker.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HabitsController : ControllerBase
    {
        private readonly AppDbContext _context;

		public HabitsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetHabits()
		{
			var habits = await _context.Habits.ToListAsync();
			return Ok(habits);
		}

		[HttpPost]
		public async Task<IActionResult> CreateHabit(Habit habit)
		{
			await _context.Habits.AddAsync(habit);
			_context.SaveChanges();
			return Ok("habit has been added");

		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateHabit(int id, [FromBody]Habit habit)
		{
			var existingHabit = await _context.Habits.FindAsync(id);
			if (existingHabit == null)
			{
				return NotFound();
			}
			existingHabit.Name = habit.Name;
			existingHabit.StartDate = habit.StartDate;
			existingHabit.IsCompleted = habit.IsCompleted;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteHabit(int id)
		{
			var existingHabit = await _context.Habits.FindAsync(id);
			if (existingHabit == null)
			{
				return NotFound();

			}
			_context.Habits.Remove(existingHabit);
			await _context.SaveChangesAsync();
			return NoContent();


		}



	}
}
