﻿using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using viewModelTheResearch;
using ViewModelTheResearch;
using WpfViewModelTheResearch;

namespace viewModelWpfTheResearch
{
    /// <summary>
    /// Interaction logic for showUsers.xaml
    /// </summary>
    public delegate int UserActions(User user);
    public partial class showUsers : Page
    {
        static int i = 1;
        UserList usersList = new UserList();
        User user = new User();
        private AuthLevelList auths;
        AuthLevelDB authDb = new AuthLevelDB();
        public showUsers()
        {
            InitializeComponent();       
            UserDB users = new UserDB();
            usersList = users.SelectAll();
            populate(usersList);

            auths = authDb.selectAll();

            cmbDemarc.ItemsSource = auths;

        }
        public void populate(UserList usersNew)
        {

            this.lvUsers.ItemsSource = null;
            this.lvUsers.ItemsSource = usersNew;
        }
        public int insertUser(User user)
        {

            UserDB users = new UserDB();
            user.birthDate = DateTime.Now;
            users.Insert(user);
            int rowsEffected = users.saveChanges();
            usersList.Add(user);
            populate(usersList);
            return rowsEffected;
        }
        public int updateUser(User user)
        {
            UserDB users = new UserDB();
            user.birthDate=DateTime.Now;
            users.Update(user);
            int rowsEffected = users.saveChanges();
            populate(usersList);
            return rowsEffected;
        }
        public int deleteUser(User user)
        {
            UserDB users = new UserDB();
            users.Delete(user);
            int rowsEffected = users.saveChanges();
            usersList.Remove(user);
            populate(usersList);
            return rowsEffected;
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            UserActions insert = new UserActions(insertUser);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new oneUser(insert, new User()));
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            UserActions insert = new UserActions(updateUser);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new oneUser(insert, user));
        }
        private void delete(object sender, RoutedEventArgs e)
        {
            UserActions delete = new UserActions(deleteUser);
            int rowsEffected = delete(user);

            this.lvUsers.ItemsSource = null;
            this.lvUsers.ItemsSource = usersList;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //if (AuthorizationControl.authAdmin == false)
            //{
            //    NavigationService nav = NavigationService.GetNavigationService(this);
            //    nav.Navigate(new homePage());
            //}
        }
        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = this.lvUsers.SelectedItem as User;
        }
        public int GetDirection(int currentDirection)
        {
            return currentDirection * -1;
        }
        //-1: asc, 1:dsc
        private void lvUsers_Click(object sender, RoutedEventArgs e)
        {
            int direction = GetDirection(i);
            UserList usersNow = new UserList();
            string colum = ((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString();
            if(colum == "שם משתמש")
            {
               foreach(User user in usersList.OrderBy(x=>x.name))
               {
                    usersNow.Add(user);
               }
            }
            if (colum == "מספר מזהה")
            {
                foreach (User user in usersList.OrderBy(x => x.Id))
                {
                    usersNow.Add(user);
                }
            }
            if (colum == "ססמה")
            {
                foreach (User user in usersList.OrderBy(x => x.password))
                {
                    usersNow.Add(user);
                }
            }
            if (colum == "אימייל")
            {
                foreach (User user in usersList.OrderBy(x => x.email))
                {
                    usersNow.Add(user);
                }
            }
            if (colum == "רמת הרשאה")
            {
                foreach (User user in usersList.OrderBy(x => x.authLevel.name))
                {
                    usersNow.Add(user);
                }
            }
            this.lvUsers.ItemsSource = null;
            this.lvUsers.ItemsSource = usersNow;
        }

        private void btDemarcation_Click(object sender, RoutedEventArgs e)
        {
            UserList newUsers = new UserList(usersList);

            int.TryParse(txbIdUser.Text, out int Id);

            string userName = txbUserName.Text;

            string email = txbEmail.Text;

            AuthLevel newAuth = new AuthLevel();
            if (cmbDemarc.SelectedItem != null)
            {
                 newAuth = cmbDemarc.SelectedItem as AuthLevel;
            }
            if (userName.Length>0)
            {
                foreach (User user in newUsers.FindAll(x => (x.name != userName)))
                {
                    newUsers.Remove(user);
                }
            }
            if (Id != 0)
            {
                foreach (User user in newUsers.FindAll(x =>(x.Id != Id)))
                {
                    newUsers.Remove(user);
                }
            }
            if (email.Length>0)
            {
                foreach (User user in newUsers.FindAll(x => (x.email != email)))
                {
                    newUsers.Remove(user);
                }
            }
            if(newAuth != null && newAuth.name!=null && newAuth.name.Length>0)
            {
                foreach (User user in newUsers.FindAll(x => (x.authLevel.name != newAuth.name)))
                { 
                    newUsers.Remove(user);
                }
            }
            populate(newUsers);
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            cmbDemarc.SelectedIndex = -1;
            populate(usersList);
        }
    }
}
