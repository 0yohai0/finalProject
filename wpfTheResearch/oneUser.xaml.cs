using ModelTheResearch;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using viewModelTheResearch;
using WpfViewModelTheResearch;


namespace viewModelWpfTheResearch
{
    /// <summary>
    /// Interaction logic for oneUser.xaml
    /// </summary>
    public partial class oneUser : Page
    {
        private UserActions action;
        private User user;
        private AuthLevelList auths;
        AuthLevelDB authDb = new AuthLevelDB();

        public oneUser()
        {
            InitializeComponent();
        }
        public oneUser(UserActions action, User user) : this()
        {
            auths = authDb.selectAll();
            this.action = action;
            this.user = user;
            txbUserName.DataContext = user;
            txbEmail.DataContext = user;
            txbPassword.DataContext = user;
            cmbAuths.ItemsSource = auths;
            cmbAuths.DataContext = user.authLevel;
            if(user.authLevel != null)
            cmbAuths.SelectedItem = user.authLevel;

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            int result = action(user);
            if (result == 0)
            {
                //שגיאה 
            }
            if (result == 2)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                if (nav.CanGoBack)
                    nav.GoBack();
            }
            if (result > 2)
            {
                //שגיאה שאין כדוגמתה
            }
        }

        private void cmbAuths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbAuths.SelectedItem != null)
            {
              AuthLevel newAuth = cmbAuths.SelectedItem as AuthLevel;
              user.authLevel = newAuth;
            }
        }
    }
}
