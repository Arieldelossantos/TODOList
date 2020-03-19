using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using PropertyChanged;
using TODOList.Helpers;
using TODOList.Models;
using TODOList.Services;

namespace TODOList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CreateTaskViewModel:IInitialize
    {
        private TaskTODO task;
        private ITODODb _todoDb;
        private INavigationService _navigationService;

        public string TaskName { get; set; }
        public bool EnabledToComplete { get; set; }

        public DelegateCommand CreateTaskCommand { get; set; }
        public DelegateCommand CompleteTaskCommand { get; set; }
        
        public DelegateCommand CancelCommand { get; set; }

        public CreateTaskViewModel(ITODODb todoDb, INavigationService navigationService)
        {
            _todoDb = todoDb;
            _navigationService = navigationService;

            CancelCommand = new DelegateCommand(Cancel);
            CreateTaskCommand = new DelegateCommand(CreateTask);
            CompleteTaskCommand = new DelegateCommand(CompleteTask);
        }
       

        private async void CreateTask()
        {
            var _taskTodo = new TaskTODO()
            {
                TaskName = TaskName
            };

            await _todoDb.SaveTask(_taskTodo);
            await _navigationService.GoBackAsync(null, true);
        }

        private async void CompleteTask()
        {
            await _todoDb.CompleteTask(task);
            await _navigationService.GoBackAsync(null, true);
        }

        private async void Cancel()
        {
            await _navigationService.GoBackAsync(null, true);
        }

        public void Initialize(INavigationParameters parameters)
        {
            EnabledToComplete = parameters.ContainsKey("completed");
            if(EnabledToComplete)
            {
                task = parameters.GetValue<TaskTODO>("task");
                TaskName = task.TaskName;
            }
        }
    }
}
