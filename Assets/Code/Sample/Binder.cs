using System;
using System.Collections.Generic;
using System.Linq;
using Derkii.FindByInterfaces;
using Derkii.MVVM.Abstraction;
using UnityEngine;

namespace Code.Sample
{
    public class Binder : MonoBehaviour, IBinder
    {
        private Dictionary<Type, IScreen> _screens;
        private Dictionary<Type, IScreen> _openedScreens;
        private Dictionary<Type, IScreen> _hiddenScreens;

        private void Awake()
        {
            //TODO
            Init(Finder.FindByInterface<IScreen>().Build().ComponentsAsInterface<IScreen>());
        }

        public void Init(IEnumerable<IScreen> screens)
        {
            _screens = new Dictionary<Type, IScreen>(screens.Count());
            _hiddenScreens = new Dictionary<Type, IScreen>();
            _openedScreens = new Dictionary<Type, IScreen>();
            foreach (var screen in screens)
            {
                Add(screen);
            }
        }

        public void Add(IScreen screen)
        {
            _screens.Add(screen.GetType(), screen);
        }

        public TScreen ShowScreen<TScreen, TViewModel>(TViewModel viewModel) where TScreen : Screen<TViewModel> 
            where TViewModel : IViewModel
        {
            var TScreenType = typeof(TScreen);
#if DEBUG
            if (!_screens.ContainsKey(TScreenType))
                throw new ArgumentException($"Screens list doesn't contain screen by type {TScreenType}");
#endif
            _screens.TryGetValue(TScreenType, out IScreen screenMarker);
            var screen = screenMarker as TScreen;
#if DEBUG

            if (_openedScreens.ContainsKey(TScreenType) && screen.IsMultiplyWindow == false)
                throw new Exception($"Screen by type {TScreenType} is already opened");
#endif
            screenMarker.Show();
            screen.BindViewModel(viewModel);
            return screen;
        }
        public TScreen HideScreen<TScreen>() where TScreen : IScreen
        {
            var TScreenType = typeof(TScreen);
#if DEBUG
            if (!_screens.ContainsKey(TScreenType))
                throw new ArgumentException($"Screens list doesn't contain screen by type {TScreenType}");
#endif
            _screens.TryGetValue(TScreenType, out IScreen screenMarker);
            var screen = (TScreen)screenMarker;
#if DEBUG
            if (_hiddenScreens.ContainsKey(TScreenType) && screen.IsMultiplyWindow == false) 
                throw new Exception($"Screen by type {TScreenType} is already hidden");
#endif
            screen.Hide();
            return screen;
        }
    }
}