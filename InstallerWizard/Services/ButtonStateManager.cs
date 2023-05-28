using InstallerWizard.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerWizard.Services
{
    public class ButtonStateManager : BindableBase
    {
        private bool _canPrevButton;
        private bool _canNextButton;
        private bool _canCancelButton;
        private bool _canFinishButton;

        public ButtonStateManager()
        {
            InitializeButtonState();
        }

        public bool CanPrevButton
        {
            get { return _canPrevButton; }
            set { SetProperty(ref _canPrevButton, value); }
        }

        public bool CanNextButton
        {
            get { return _canNextButton; }
            set { SetProperty(ref _canNextButton, value); }
        }

        public bool CanCancelButton
        {
            get { return _canCancelButton; }
            set { SetProperty(ref _canCancelButton, value); }
        }

        public bool CanFinishButton
        {
            get { return _canFinishButton; }
            set { SetProperty(ref _canFinishButton, value); }
        }

        public void UpdateButtonState(Type currentPageType, Type nextPageType)
        {
            if (nextPageType == typeof(WelcomePage))
            {
                CanPrevButton = false;
                CanNextButton = true;
                CanCancelButton = true;
                CanFinishButton = false;
            }
            else if (nextPageType == typeof(WizardInputPage))
            {
                CanPrevButton = true;
                CanNextButton = true;
                CanCancelButton = true;
                CanFinishButton = false;
            }
            else if (nextPageType == typeof(ConfirmationPage))
            {
                CanPrevButton = true;
                CanNextButton = true;
                CanCancelButton = true;
                CanFinishButton = false;
            }
            else if (nextPageType == typeof(InstallProgressPage))
            {
                CanPrevButton = true;
                CanNextButton = true;
                CanCancelButton = true;
                CanFinishButton = false;
            }
            else if (nextPageType == typeof(CompletionPage))
            {
                CanPrevButton = false;
                CanNextButton = false;
                CanCancelButton = false;
                CanFinishButton = true;
            }
        }

        private void InitializeButtonState()
        {
            //最初のページ用のボタンを初期化する
            CanPrevButton = false;
            CanNextButton = true;
            CanCancelButton = true;
            CanFinishButton = false;
        }
    }

}
