using InstallerWizard.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace InstallerWizard.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase
    {
        private readonly PageNavigationManager _pageNavigationManager;
        private readonly ButtonStateManager _buttonStateManager;

        private string _title = "Prism Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool CanPrevButton => _buttonStateManager.CanPrevButton;
        public bool CanNextButton => _buttonStateManager.CanNextButton;
        public bool CanCancelButton => _buttonStateManager.CanCancelButton;
        public bool CanFinishButton => _buttonStateManager.CanFinishButton;


        public DelegateCommand PrevCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand<Window> CancelCommand { get; set; }
        public DelegateCommand<Window> FinishCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _buttonStateManager = new ButtonStateManager();
            _pageNavigationManager = new PageNavigationManager(regionManager, _buttonStateManager);

            _buttonStateManager.PropertyChanged += ButtonStateManager_PropertyChanged;

            PrevCommand = new DelegateCommand(PrevNavigate).ObservesCanExecute(() => CanPrevButton);
            NextCommand = new DelegateCommand(NextNavigate).ObservesCanExecute(() => CanNextButton);
            CancelCommand = new DelegateCommand<Window>(Cancel).ObservesCanExecute(() => CanCancelButton);
            FinishCommand = new DelegateCommand<Window>(Finish).ObservesCanExecute(() => CanFinishButton);
        }

        private void ButtonStateManager_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }

        private void PrevNavigate()
        {
            _pageNavigationManager.NavigateToPreviousPage();
        }

        private void NextNavigate()
        {
            _pageNavigationManager.NavigateToNextPage();
        }

        private void Cancel(Window window)
        {
            window?.Close();
        }

        private void Finish(Window window)
        {
            window?.Close();
        }
    }
}
