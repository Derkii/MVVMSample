using System;
using UnityEngine;

namespace Derkii.MVVM.Abstraction
{
    public interface IScreen
    {
        public void Show();
        public void Hide();
        public bool IsMultiplyWindow { get; }
    }
    public abstract class Screen<TViewModel> : MonoBehaviour, IScreen where TViewModel : IViewModel
    {
        [SerializeField]
        protected GameObject _screenGameObject;
        public Type ViewModelType => typeof(TViewModel);
        public abstract bool IsMultiplyWindow { get; }
        protected TViewModel _viewModel;

        public virtual void Show()
        {
            _screenGameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            _screenGameObject.SetActive(false);
        }

        public void BindViewModel(TViewModel viewModel)
        {
            _viewModel = viewModel;
            OnBind(viewModel);
        }

        protected virtual void OnBind(TViewModel viewModel)
        {
            
        }
    }
}