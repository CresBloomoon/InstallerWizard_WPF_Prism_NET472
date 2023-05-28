using InstallerWizard.Factories;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerWizard.Services
{
    public class PageNavigationManager
    {
        private readonly IRegionManager _regionManager;
        private readonly ButtonStateManager _buttonStateManager;

        public PageNavigationManager(IRegionManager regionManager, ButtonStateManager buttonStateManager)
        {
            _regionManager = regionManager;
            _buttonStateManager = buttonStateManager;
        }

        public void NavigateToNextPage()
        {
            var currentPageType = GetCurrentPageType();
            var nextPageType = GetNextPageType(currentPageType);

            if (nextPageType != null)
            {
                _buttonStateManager.UpdateButtonState(currentPageType, nextPageType);
                _regionManager.RequestNavigate("ContentRegion", nextPageType.Name);
            }
        }

        public void NavigateToPreviousPage()
        {
            var currentPageType = GetCurrentPageType();
            var previousPageType = GetPreviousPageType(currentPageType);

            if (previousPageType != null)
            {
                _buttonStateManager.UpdateButtonState(currentPageType, previousPageType);
                _regionManager.RequestNavigate("ContentRegion", previousPageType.Name);
            }
        }

        private Type GetCurrentPageType()
        {
            return _regionManager.Regions["ContentRegion"].ActiveViews.First().GetType();
        }

        private Type GetNextPageType(Type currentPageType)
        {
            var pages = PageFactory.GetPageList();

            var currentPageIndex = pages.IndexOf(currentPageType);
            if (currentPageIndex >= 0 && currentPageIndex < pages.Count - 1)
            {
                return pages[currentPageIndex + 1];
            }
            return null;
        }

        private Type GetPreviousPageType(Type currentPageType)
        {
            var pages = PageFactory.GetPageList();

            var currentPageIndex = pages.IndexOf(currentPageType);
            if (currentPageIndex >= 1)
            {
                return pages[currentPageIndex - 1];
            }

            return null;
        }
    }

}
