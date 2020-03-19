using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TODOList.Views
{
    public partial class TODOsPage : ContentPage
    {
        public TODOsPage()
        {
            InitializeComponent();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // This is to avoid the orange on selected background color on android
            if (e.SelectedItem == null) return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}
