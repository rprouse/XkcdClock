using System.Windows;

namespace XkcdClock
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void OnClose( object sender, RoutedEventArgs e )
        {
            Close();
        }
    }
}
