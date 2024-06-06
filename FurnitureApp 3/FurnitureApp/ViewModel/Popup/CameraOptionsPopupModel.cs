using System;
namespace FurnitureApp.ViewModel.Popup
{
	public class CameraOptionsPopupModel
	{
		
        #region Fields  
        private INavigation _navigation;

        #endregion

        #region Ctor 
        public CameraOptionsPopupModel(INavigation navigation)
        {
            _navigation = navigation;
          
        }
        #endregion
    }
}

