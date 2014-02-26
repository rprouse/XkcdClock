using System.Windows;
using System.Windows.Input;

namespace XkcdClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
                Close();
        }

        private void OnExit(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void OnAbout( object sender, RoutedEventArgs e )
        {
            var about = new About();
            about.Owner = this;
            about.ShowDialog();
        }
    }
}
