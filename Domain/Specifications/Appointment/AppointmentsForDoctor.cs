namespace Domain.Specifications.Appointment
{
    public class TaskItemsForTask : BaseSpecification<Appointment>
    {
        public TaskItemsForTask(int taskId) : base(task => task.Id == taskId)
        {
            AddInclude(task => task.Items);
        }
    }
}
