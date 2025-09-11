namespace HabitTracker.API.Models
{
	public class Habit
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public DateTime StartDate { get; set; } = DateTime.Now;
		public bool IsCompleted { get; set; } = false;
	}
}
