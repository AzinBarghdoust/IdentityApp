using System.Threading.Tasks;
using System;

namespace IdentityApp.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TasksStatus Status { get; set; } = TasksStatus.Pending;
        public string UserId { get; set; }
        public User User { get; set; }
    }
    public enum TasksStatus
    {
        Pending =1 ,
        InProgress = 2 ,
        Completed =3
    }
}
