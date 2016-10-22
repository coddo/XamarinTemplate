using GalaSoft.MvvmLight.Ioc;

namespace XamarinTemplate.Core.Base.Containers
{
    public abstract class Services
    {
        private static Services Instance => SimpleIoc.Default.GetInstance<Services>();

        #region Fields
        #endregion

        #region Properties
        #endregion
    }
}
