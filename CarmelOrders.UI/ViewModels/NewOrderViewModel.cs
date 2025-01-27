using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CarmelOrders.Core.Models;
using CarmelOrders.Core.Interfaces;

namespace CarmelOrders.UI.ViewModels
{
    public class NewOrderViewModel : INotifyPropertyChanged
    {
        private readonly IOrderService _orderService;
        private הזמנה _הזמנה;

        public NewOrderViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            _הזמנה = new הזמנה
            {
                תאריך_הזמנה = DateTime.Now,
                סטטוס = סטטוס_הזמנה.חדש,
                דחיפות = רמת_דחיפות.רגיל
            };

            שמור_Command = new RelayCommand(שמור_הזמנה, CanSave);
            בטל_Command = new RelayCommand(סגור_חלון);
        }

        public הזמנה הזמנה
        {
            get => _הזמנה;
            set
            {
                _הזמנה = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<סוג_אריזה> סוגי_אריזה => Enum.GetValues<סוג_אריזה>();
        public IEnumerable<רמת_דחיפות> רמות_דחיפות => Enum.GetValues<רמת_דחיפות>();

        public ICommand שמור_Command { get; }
        public ICommand בטל_Command { get; }

        public event EventHandler<הזמנה> הזמנה_נשמרה;
        public event EventHandler בקשת_סגירה;

        private async void שמור_הזמנה()
        {
            try
            {
                var הזמנה_חדשה = await _orderService.צור_הזמנה_חדשה(הזמנה);
                הזמנה_נשמרה?.Invoke(this, הזמנה_חדשה);
                בקשת_סגירה?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // TODO: טיפול בשגיאות
            }
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(הזמנה.שם_חברה) &&
                   !string.IsNullOrEmpty(הזמנה.מוצר) &&
                   הזמנה.כמות > 0;
        }

        private void סגור_חלון()
        {
            בקשת_סגירה?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Helper class for commands
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
        public void Execute(object parameter) => _execute();
    }
}