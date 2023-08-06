namespace Derkii.MVVM.Abstraction
{
    public interface IViewModel
    {
        
    }
    public interface IViewModel<TModel> : IViewModel where TModel : IModel
    {
        public void Bind(TModel modelInstance);
    }
}