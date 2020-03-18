using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UserManagement.UI.CustomControls
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : Grid
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(CustomTextBox));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text), typeof(string), typeof(CustomTextBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty ControlFontSizeProperty = DependencyProperty.Register(nameof(ControlFontSize), typeof(double), typeof(CustomTextBox), new PropertyMetadata(14.0));
        public static readonly DependencyProperty ControlMaxLengthProperty = DependencyProperty.Register(nameof(ControlMaxLength), typeof(double), typeof(CustomTextBox), new PropertyMetadata(100.0));
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(nameof(BorderBrush), typeof(SolidColorBrush), typeof(CustomTextBox), new PropertyMetadata(Brushes.LightGray));
        public static readonly DependencyProperty CustomColorFontWeightProperty = DependencyProperty.Register(nameof(CustomColorFontWeight), typeof(FontWeight), typeof(CustomTextBox), new PropertyMetadata(FontWeights.Normal));
        public static readonly DependencyProperty IsNumericProperty = DependencyProperty.Register(nameof(IsNumeric), typeof(bool), typeof(CustomTextBox));
        public static readonly DependencyProperty IsDateFormatProperty = DependencyProperty.Register(nameof(IsDateFormat), typeof(bool), typeof(CustomTextBox), new PropertyMetadata(false));

        public static readonly DependencyProperty FontColorProperty = DependencyProperty.Register(
            nameof(FontColor), typeof(string), typeof(CustomTextBox),
            new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, FontColorProperty_Changed));

        private static void FontColorProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lPropertyUpdateControl = (CustomTextBox)d;
            lPropertyUpdateControl.FontColor_Changed((string)e.OldValue, (string)e.NewValue);
        }

        private void FontColor_Changed(string oldValue, string newValue)
        {
            this.FontColor = newValue;
            UpdateColorOfTextBox();
        }

        public string FontColor
        {
            get { return (string)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }
        }

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

        public double ControlMaxLength
        {
            get { return System.Convert.ToDouble(GetValue(ControlMaxLengthProperty)); }
            set { SetValue(ControlMaxLengthProperty, value); }
        }

        public double ControlFontSize
        {
            get { return System.Convert.ToDouble(GetValue(ControlFontSizeProperty)); }
            set { SetValue(ControlFontSizeProperty, value); }
        }

        public FontWeight CustomColorFontWeight
        {
            get { return (FontWeight)GetValue(CustomColorFontWeightProperty); }
            set { SetValue(CustomColorFontWeightProperty, value); }
        }

        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public bool IsNumeric
        {
            get { return (bool)GetValue(IsNumericProperty); }
            set { SetValue(IsNumericProperty, value); }
        }

        public bool IsDateFormat
        {
            get { return (bool)GetValue(IsDateFormatProperty); }
            set { SetValue(IsDateFormatProperty, value); }
        }

        public CustomTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        public void UpdateColorOfTextBox()
        {
            textBox.Background = new SolidColorBrush(Colors.Transparent);

            if ("Gray".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4D4D4D"));
            }
            else if ("Navy".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF283D89"));
            }
            else if ("Blue".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C72FE"));
            }
            else if ("Red".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFE4C4C"));
            }
            else if ("Brown".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC45307"));
            }
            else if ("Purple".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush(Colors.Purple);
            }
            else if ("Green".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7BD424"));
            }
            else if ("Orange".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFA201"));
            }
            else if ("Yellow".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFD801"));
            }
            else if ("Pink".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEF65E0"));
            }
            else if ("Other".Equals(this.FontColor))
            {
                GradientStop gradientStop = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFFFD59C")
                };
                GradientStop gradientStop1 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFFFD59C"),
                    Offset = 1
                };
                GradientStop gradientStop2 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFA9E2A9"),
                    Offset = 0.703
                };
                GradientStop gradientStop3 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF5DC9DA"),
                    Offset = 0.767
                };
                GradientStop gradientStop4 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFDCA6F5"),
                    Offset = 0.83
                };
                GradientStop gradientStop5 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFEAE470"),
                    Offset = 0.887
                };
                GradientStop gradientStop6 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF9FF0C0"),
                    Offset = 0.943
                };
                GradientStop gradientStop7 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFF8A09C"),
                    Offset = 0.05
                };
                GradientStop gradientStop8 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFE2F19D"),
                    Offset = 0.107
                };
                GradientStop gradientStop9 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF9DECE8"),
                    Offset = 0.173
                };
                GradientStop gradientStop10 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FFB4E49E"),
                    Offset = 0.233
                };
                GradientStop gradientStop11 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FEA29FDA"),
                    Offset = 0.307
                };
                GradientStop gradientStop12 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FED6A0D9"),
                    Offset = 0.363
                };
                GradientStop gradientStop13 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FEDBDBA2"),
                    Offset = 0.427
                };
                GradientStop gradientStop14 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FEA3C2DC"),
                    Offset = 0.49
                };
                GradientStop gradientStop15 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FECBCF87"),
                    Offset = 0.55
                };
                GradientStop gradientStop16 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FE92B889"),
                    Offset = 0.623
                };
                GradientStopCollection gradientStops = new GradientStopCollection
                {
                    gradientStop,
                    gradientStop1,
                    gradientStop2,
                    gradientStop3,
                    gradientStop4,
                    gradientStop5,
                    gradientStop6,
                    gradientStop7,
                    gradientStop8,
                    gradientStop9,
                    gradientStop10,
                    gradientStop11,
                    gradientStop12,
                    gradientStop13,
                    gradientStop14,
                    gradientStop15,
                    gradientStop16
                };

                LinearGradientBrush lgb = new LinearGradientBrush
                {
                    EndPoint = new Point(0, 0),
                    StartPoint = new Point(0.5, 11),
                    GradientStops = gradientStops
                };

                textBox.Background = lgb;
                textBox.Foreground = new SolidColorBrush(Colors.White);
            }
            else if ("Silver".Equals(this.FontColor))
            {
                GradientStop gradientStop1 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF515151"),
                    Offset = 0.56
                };
                GradientStop gradientStop2 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF999EB6"),
                    Offset = 0.693
                };
                GradientStop gradientStop3 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF999EB6"),
                    Offset = 0.113
                };
                GradientStop gradientStop4 = new GradientStop
                {
                    Color = Colors.Black
                };
                GradientStop gradientStop5 = new GradientStop
                {
                    Color = (Color)ColorConverter.ConvertFromString("#FF666979"),
                    Offset = 0.437
                };

                GradientStopCollection gradientStops = new GradientStopCollection
                {
                    gradientStop1,
                    gradientStop2,
                    gradientStop3,
                    gradientStop4,
                    gradientStop5
                };

                LinearGradientBrush lgb = new LinearGradientBrush
                {
                    EndPoint = new Point(0.5, 1),
                    MappingMode = BrushMappingMode.RelativeToBoundingBox,
                    StartPoint = new Point(0.5, 0),
                    GradientStops = gradientStops
                };

                textBox.Foreground = lgb;
            }
            else if ("White".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush(Colors.White);
                textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B3B3B3"));
            }
            else if ("Beige".Equals(this.FontColor))
            {
                textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFA64D"));
            }
            else
            {
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBlock_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (IsNumeric)
                e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void DateFormat(string text)
        {
            this.Text = string.Empty;

            text = text.Trim().Replace(" ", string.Empty)
                            .Replace("/", string.Empty)
                            .Replace(".", string.Empty)
                            .Replace("-", string.Empty);

            var count = text.Length;

            if (count == 2)
            {
                text = text + "/";
            }
            else if (count == 3)
            {
                text = text.Insert(2, "/");
            }
            else if (count >= 4)
            {
                text = text.Insert(2, "/").Insert(5, "/");
            }

            this.Text = text.Length >= 11 ? text.Remove(10) : text;
            textBox.CaretIndex = textBox.Text.Length;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Text) && IsDateFormat &&
                e.Key != Key.Left && e.Key != Key.Right &&
                e.Key != Key.Up && e.Key != Key.Down &&
                e.Key != Key.Back && e.Key != Key.Delete)
                DateFormat(this.Text);
        }
    }
}
