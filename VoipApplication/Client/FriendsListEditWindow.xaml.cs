﻿using cscprotocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VoipApplication;

namespace VoIP_Client
{
    /// <summary>
    /// Interaction logic for DB_AddUserWindow.xaml
    /// </summary>
    public partial class FriendsListEditWindow : Window
    {
        Client client;
        CscUserMainData friendData;
        private bool isoutfriend;

        public FriendsListEditWindow(Client client, CscUserMainData userdata, bool isfriend)
        {
            this.client = client;
            friendData = userdata;
            isoutfriend = isfriend;
            InitializeComponent();
                EmailTextBlock.Text = userdata.Email;
            if (isfriend)
            {
                UsernameTextBox.Text = userdata.FriendName;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        { this.Close(); }

        private void EditFavouriteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (isoutfriend)
            {
                if (UsernameTextBox.Text != string.Empty)
                {
                    //wyslij komunikat od serwera o zmiane friendname tego usera
                    //czyli tak na prawde usun tego usera ze znajomych
                    //a potem go dodaj z inna friendname
                }
                else
                { //usun tego usera z ulubionych
                }
            }
            else
            {
                if (UsernameTextBox.Text != string.Empty)
                {
                    //dodaj tego usera do naszych znajomych
                    client.SendAddUserToFriendsListDataRequest(new CscChangeFriendData {Id = friendData.Id, FriendName = UsernameTextBox.Text });
                }
            }
            Close();
        }
    }
}
