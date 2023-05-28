using Prism.Regions;
using System.Windows;

namespace InstallerWizard.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(WelcomePage));
        }
    }
}
