using System.Linq;
using Derkii.FindByInterfaces;
using Derkii.MVVM.Abstraction;
using UnityEngine;

namespace Code.Sample
{
    public class MainScreenInitializer : MonoBehaviour
    {
        private IBinder _binder;
        private void Start()
        {
            _binder = Finder.FindByInterface<IBinder>().Build().ComponentsAsInterface<IBinder>().ElementAt(0);
            _binder.ShowScreen<MainScreen, CountViewModel>(new CountViewModel());
        }
    }
}