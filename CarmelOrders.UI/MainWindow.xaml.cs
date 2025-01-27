using System.Windows;
using CarmelOrders.Core.Interfaces;
using CarmelOrders.UI.ViewModels;
using CarmelOrders.UI.Views;

namespace CarmelOrders.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly IOrderService _orderService;

        public MainWindow(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
            _viewModel = new MainViewModel(_orderService);
            DataContext = _viewModel;

            _viewModel.פתיחת_הזמנה_חדשה += ViewModel_פתיחת_הזמנה_חדשה;
        }

        private void ViewModel_פתיחת_הזמנה_חדשה(object sender, System.EventArgs e)
        {
            var viewModel = new NewOrderViewModel(_orderService);
            var window = new NewOrderWindow(viewModel);
            window.Owner = this;
            window.ShowDialog();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
            _viewModel.פתיחת_הזמנה_חדשה -= ViewModel_פתיחת_הזמנה_חדשה;
        }
    }
}