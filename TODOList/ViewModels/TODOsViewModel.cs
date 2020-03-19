using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using TODOList.Models;
using TODOList.Services;
using PropertyChanged;
using Prism.Commands;
using TODOList.Helpers;

namespace TODOList.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TODOsViewModel:INavigatedAware
    {
        private ITODODb _todoDb;
        private INavigationService _navigationService;

        public DelegateCommand AddNewCommand { get; set; }
        public ObservableCollection<TaskTODO> TODOData { get; set; }

        private TaskTODO _selectedTask;
        public TaskTODO SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;

                SetTaskCompleted(_selectedTask);
            }
        }

        private async void SetTaskCompleted(TaskTODO selectedTask)
        {
            var navParam = new NavigationParameters();
            navParam.Add("completed", "");
            navParam.Add("task", selectedTask);

            await _navigationService.NavigateAsync(NavigationPages.CreateTaskPage, navParam, true);
        }

        public TODOsViewModel(ITODODb todoDb, INavigationService navigationService)
        {
            _todoDb = todoDb;
            _navigationService = navigationService;

            AddNewCommand = new DelegateCommand(NavigateToAddNewPage);
        }

        private async void NavigateToAddNewPage()
        {
           await _navigationService.NavigateAsync(NavigationPages.CreateTaskPage,null,true);
        }

      
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadData();
        }

        private void LoadData()
        {
            var data = _todoDb.LoadData();

            TODOData = new ObservableCollection<TaskTODO>(data);
        }

    }
}
