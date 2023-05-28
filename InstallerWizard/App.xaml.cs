using InstallerWizard.Views;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InstallerWizard
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WizardInputPage>();
            containerRegistry.RegisterForNavigation<ConfirmationPage>();
            containerRegistry.RegisterForNavigation<InstallProgressPage>();
            containerRegistry.RegisterForNavigation<CompletionPage>();
        }
    }
}
