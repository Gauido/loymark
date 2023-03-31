using Data.Entities;

namespace WebApplicationLoyMark.Models
{
    public class TaskByUser
    {
        public string FullName { get; set; }
        public List<Activity> Task { get; set; }
    }
}
