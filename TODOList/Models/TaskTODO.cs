using System;
using PropertyChanged;
using SQLite;

namespace TODOList.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TaskTODO
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string TaskName { get; set; }
        public bool Completed { get; set; }

        public string Pending => Completed ? "Ready" : "Pending";

        public TaskTODO()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
