using InstallerWizard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerWizard.Factories
{
    public static class PageFactory
    {
        public static List<Type> GetPageList()
        {
            return new List<Type>
            {
                typeof(WelcomePage),
                typeof(WizardInputPage),
                typeof(ConfirmationPage),
                typeof(InstallProgressPage),
                typeof(CompletionPage),
                //ページを追加あるいは駆除する場合はこのクラスに書いてください。
            };
        }
    }
}
