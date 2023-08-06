namespace Derkii.MVVM.Abstraction
{
    public interface IBinder
    {
        public TScreen ShowScreen<TScreen, TViewModel>(TViewModel viewModel)
            where TViewModel : IViewModel where TScreen : Screen<TViewModel>;
        public TScreen HideScreen<TScreen>() where TScreen : IScreen;
    }
}