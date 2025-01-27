using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CarmelOrders.Core.Models;
using CarmelOrders.Core.Interfaces;

namespace CarmelOrders.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IOrderService _orderService;
        private ObservableCollection<הזמנה> _הזמנות;
        private הזמנה _הזמנה_נבחרת;

        public MainViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            הזמנה_חדשה_Command = new RelayCommand(פתח_טופס_הזמנה_חדשה);
            רענון_Command = new RelayCommand(רענן_נתונים);
            טען_הזמנות();
        }

        public ObservableCollection<הזמנה> הזמנות
        {
            get => _הזמנות;
            set
            {
                _הזמנות = value;
                OnPropertyChanged();
            }
        }

        public הזמנה הזמנה_נבחרת
        {
            get => _הזמנה_נבחרת;
            set
            {
                _הזמנה_נבחרת = value;
                OnPropertyChanged();
            }
        }

        public ICommand הזמנה_חדשה_Command { get; }
        public ICommand רענון_Command { get; }

        private async void טען_הזמנות()
        {
            var הזמנות = await _orderService.קבל_כל_ההזמנות();
            הזמנות = new ObservableCollection<הזמנה>(הזמנות);
        }

        private void פתח_טופס_הזמנה_חדשה()
        {
            // TODO: פתיחת חלון הזמנה חדשה
        }

        private async void רענן_נתונים()
        {
            await טען_הזמנות();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}