using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CustomerApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.Navigation.PushModalAsync(new LoginPage());
        }
    }
}
