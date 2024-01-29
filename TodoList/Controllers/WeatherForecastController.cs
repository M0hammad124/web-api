using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<TodoTask> tasks = new List<TodoTask>();

        public WeatherForecastController()
        {
        }

        [HttpPost("add-task")]
        public void AddTask([FromBody] Dto dto)
        {
            TodoTask task = new TodoTask()
            {
                Id = dto.id,
                Name = dto.title,
                Status = dto.status
            };

            tasks.Add(task);
        }

        [HttpPatch("update-task/{id}")]
        public void UpdateTask([FromRoute] string id, [FromBody] Dto dto)
        {
            var task = tasks.Where(_ => _.Id == id).First();

            task.Name = dto.title;
            task.Status = dto.status;
        }

        [HttpGet("get-all")]
        public List<TodoTask> GetAll()
        {
            return tasks;
        }

        [HttpDelete("update-task/{id}")]
        public void DeleteTask([FromRoute] string id)
        {
            var task = tasks.Where(_ => _.Id == id).First();

            tasks.Remove(task);
        }
    }

    public class Dto
    {
        public string id { get; set; }
        public string title { get; set; }
        public TodoTaskStatus status { get; set; }
    }
}