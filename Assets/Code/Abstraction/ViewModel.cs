using System;

namespace Derkii.MVVM.Abstraction
{
    public abstract class ViewModel<TModel> : IDisposable, IViewModel<TModel> where TModel : IModel
    {
        protected TModel _model;
        
        public void Bind(TModel modelInstance)
        {
            _model = modelInstance;
            OnBind(modelInstance);
        }

        protected virtual void OnBind(TModel modelInstance)
        {
            
        }
        public virtual void Dispose()
        {
            _model.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}