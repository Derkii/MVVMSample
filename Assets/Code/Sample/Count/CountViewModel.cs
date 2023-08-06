using System;
using Derkii.MVVM.Abstraction;

namespace Code.Sample
{
    public class CountViewModel : ViewModel<CountModel>
    {
        public event Action<int> OnCurrentCountChanged;
        private int _count;
        public int Count => _count;
        public void AddCount()
        {
            _model.Add(_count);
        }

        public bool RemoveCount()
        {
            return _model.Remove(_count);
        }

        public void ChangeCount(int count)
        {
            _count = count;
        }

        protected override void OnBind(CountModel model)
        {
            _model.OnCurrentCountChanged += value => OnCurrentCountChanged.Invoke(value);
        }
    }
}