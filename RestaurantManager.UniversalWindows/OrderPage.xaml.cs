using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RestaurantManager.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
        }

        public DataManager dataManager { get; set; }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_AddtoOrder_Click(object sender, RoutedEventArgs e)
        {
            List<string> menuList = CurrentlySelectedMenuItemsListView.ItemsSource as List<string>;
            string menuSelected = MenuItemsListView.SelectedItem as string;
            menuList.Add(menuSelected);
            Frame.Navigate(typeof(OrderPage));
        }

        private void Button_SubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            List<string> menuList = CurrentlySelectedMenuItemsListView.ItemsSource as List<string>;
            string orderItem = string.Join(", ", menuList);
            ObservableCollection<string> orderItems = OrderItemsControl.ItemsSource as ObservableCollection<string>;
            orderItems.Add(orderItem);
            menuList.Clear();
            Frame.Navigate(typeof(OrderPage));
        }
    }
}
