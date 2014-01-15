﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace waronline
{
    using waronline.Transport;

    public partial class EditPlayerName : PhoneApplicationPage
    {
        private ICloud cloudProvider;

        public EditPlayerName()
        {
            InitializeComponent();

            this.cloudProvider = new AzureConnector();
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            this.cloudProvider.CreateUser(PlayerName.Text);
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }
    }
}