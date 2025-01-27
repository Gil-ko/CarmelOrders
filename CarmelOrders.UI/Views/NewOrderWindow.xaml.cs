using System.Windows;
using CarmelOrders.Core.Models;
using CarmelOrders.UI.ViewModels;

namespace CarmelOrders.UI.Views
{
    public partial class NewOrderWindow : Window
    {
        private readonly NewOrderViewModel _viewModel;

        public NewOrderWindow(NewOrderViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;

            _viewModel.הזמנה_נשמרה += ViewModel_הזמנה_נשמרה;
            _viewModel.בקשת_סגירה += ViewModel_בקשת_סגירה;
        }

        private void ViewModel_הזמנה_נשמרה(object sender, הזמנה הזמנה)
        {
            MessageBox.Show("ההזמנה נשמרה בהצלחה!", "הודעת מערכת", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_בקשת_סגירה(object sender, System.EventArgs e)
        {
            Close();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
            _viewModel.הזמנה_נשמרה -= ViewModel_הזמנה_נשמרה;
            _viewModel.בקשת_סגירה -= ViewModel_בקשת_סגירה;
        }
    }
}