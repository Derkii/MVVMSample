using System;
using Derkii.MVVM.Abstraction;

namespace Code.Sample
{
    public sealed class CountModel : IModel
    {
        private int _currentCurrentCountValue;

        private int _currentCount
        {
            get => _currentCurrentCountValue;
            set
            {
                _currentCurrentCountValue = value;
                OnCurrentCountChanged.Invoke(value);
            }
        }

        public event Action<int> OnCurrentCountChanged;
        public void Add(int count)
        {
            _currentCount += count;
        }

        public bool Remove(int count)
        {
            if (_currentCount - count < 0)
            {
                _currentCount = 0;
                return false;
            }
            _currentCount -= count;
            return true;
        }

        public void Dispose()
        {
            OnCurrentCountChanged = null;
            _currentCount = 0;
            GC.SuppressFinalize(this);
        }
    }
}