using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UserManagement.UI.CustomControls
{
    /// <summary>
    /// Interaction logic for CustomColorTextBox.xaml
    /// </summary>
    public partial class CustomColorTextBox : Grid
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(CustomColorTextBox));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(CustomColorTextBox), new FrameworkPropertyMetadata(
            string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty ControlFontSizeProperty = DependencyProperty.Register(nameof(ControlFontSize), typeof(double), typeof(CustomColorTextBox), new PropertyMetadata(14.0));
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(nameof(BorderBrush), typeof(SolidColorBrush), typeof(CustomColorTextBox), new PropertyMetadata(Brushes.LightGray));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public double ControlFontSize
        {
            get { return System.Convert.ToDouble( GetValue(ControlFontSizeProperty)); }
            set { SetValue(ControlFontSizeProperty, value); }
        }
        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public CustomColorTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }
    }
}
