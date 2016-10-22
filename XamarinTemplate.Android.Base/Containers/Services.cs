using GalaSoft.MvvmLight.Ioc;

namespace XamarinTemplate.Android.Base.Containers
{
    public abstract class Services : Core.Base.Containers.Services
    {
        private static Services Instance => SimpleIoc.Default.GetInstance<Services>();

        #region Fields
        #endregion

        #region Properties
        #endregion
    }
}