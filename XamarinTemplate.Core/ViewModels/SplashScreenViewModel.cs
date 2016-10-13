using System;
using System.Threading.Tasks;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Core.ViewModels
{
    public class SplashScreenViewModel : BaseViewModel
    {
        public void NavigateToMainPageDelayed(int secondsDelay = 3)
        {
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(secondsDelay)).ConfigureAwait(false);

                RunOnUiThread(() =>
                {
                    ShowViewModel<MainViewModel>();
                    CloseViewAction?.Invoke();
                });
            }).ConfigureAwait(false);
        }
    }
}
