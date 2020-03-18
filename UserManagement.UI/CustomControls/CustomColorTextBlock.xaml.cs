using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace UserManagement.UI.CustomControls
{
    /// <summary>
    /// Interaction logic for CustomColorTextBlock.xaml
    /// </summary>
    public partial class CustomColorTextBlock : Grid
    {
        public static readonly DependencyProperty CustomColorTextProperty = DependencyProperty.Register(nameof(CustomColorText), typeof(string), typeof(CustomColorTextBlock), new FrameworkPropertyMetadata(
            string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty CustomColorFontSizeProperty = DependencyProperty.Register(nameof(CustomColorFontSize), typeof(double), typeof(CustomColorTextBlock), new PropertyMetadata(14.0));
        public static readonly DependencyProperty CustomColorFontWeightProperty = DependencyProperty.Register(nameof(CustomColorFontWeight), typeof(FontWeight), typeof(CustomColorTextBlock), new PropertyMetadata(FontWeights.Bold));
        public static readonly DependencyProperty CustomColorFontColorProperty = DependencyProperty.Register(nameof(CustomColorFontColor), typeof(string), typeof(CustomColorTextBlock), new FrameworkPropertyMetadata(
            "Black", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string CustomColorText
        {
            get { return (string)GetValue(CustomColorTextProperty); }
            set { SetValue(CustomColorTextProperty, value); }
        }

        public double CustomColorFontSize
        {
            get { return System.Convert.ToDouble(GetValue(CustomColorFontSizeProperty)); }
            set { SetValue(CustomColorFontSizeProperty, value); }
        }

        public string CustomColorFontColor
        {
            get { return (string)GetValue(CustomColorFontColorProperty); }
            set { SetValue(CustomColorFontColorProperty, value); }
        }
        
        public FontWeight CustomColorFontWeight
        {
            get { return (FontWeight)GetValue(CustomColorFontWeightProperty); }
            set { SetValue(CustomColorFontWeightProperty, value); }
        }

        public CustomColorTextBlock()
        {
            InitializeComponent();
        }

        private string[] CustomColors
        {
            get => new string[11]
            {
                "#FF000000",
                "#FF828282",
                "#FF283D89",
                "#FF4C72FE",
                "#FFFE4C4C",
                "#FFC45307",
                "#FF800080",
                "#FF7BD424",
                "#FFFFA201",
                "#FFFFD801",
                "#FFEF65E0"
            };
        }

        private void Ucc_Loaded(object sender, RoutedEventArgs e)
        {
            CreatTextBlock(CustomColorFontColor);
        }

        TextBlock txtBlock;
        public void CreatTextBlock(string textboxName)
        {
            if (txtBlock != null)
            {
                txtBlock = null;
            }
            MainGrid.Children.Clear();

            txtBlock = new TextBlock
            {
                FontSize = CustomColorFontSize,
                Text = CustomColorText,
                FontWeight = this.CustomColorFontWeight,
                TextWrapping = TextWrapping.Wrap
            };

            if ("Gray".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4D4D4D"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Navy".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF283D89"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Blue".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C72FE"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Red".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFE4C4C"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Brown".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC45307"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Purple".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush(Colors.Purple);
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Green".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7BD424"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Orange".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFA201"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Yellow".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFD801"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Pink".Equals(textboxName))
            {
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEF65E0"));
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Other".Equals(textboxName))
            {
                txtBlock.Text = string.Empty;
                Random random = new Random();
                foreach (var item in CustomColorText.ToArray())
                {
                    int index = random.Next(0, CustomColors.Length);
                    Run run = new Run
                    {
                        Text = item.ToString(),
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(CustomColors[index]))
                    };
                    txtBlock.Inlines.Add(run);
                }
                MainGrid.Children.Add(txtBlock);
            }
            else if ("Silver".Equals(textboxName))
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

                txtBlock.Foreground = lgb;
                MainGrid.Children.Add(txtBlock);
            }
            else if ("White".Equals(textboxName))
            {
                TranslateTransform translateTransform = new TranslateTransform
                {
                    X = -1,
                    Y = 1
                };
                TransformCollection transforms = new TransformCollection
                {
                    translateTransform
                };
                TransformGroup transformGroup = new TransformGroup
                {
                    Children = transforms
                };

                TranslateTransform translateTransform1 = new TranslateTransform
                {
                    X = 1,
                    Y = -1
                };
                TransformCollection transforms1 = new TransformCollection
                {
                    translateTransform1
                };
                TransformGroup transformGroup1 = new TransformGroup
                {
                    Children = transforms1
                };

                TextBlock tb1 = new TextBlock
                {
                    FontSize = CustomColorFontSize,
                    Text = CustomColorText,
                    Foreground = new SolidColorBrush(Colors.Black),
                    RenderTransform = transformGroup,
                    FontWeight = this.CustomColorFontWeight,
                    TextWrapping = TextWrapping.Wrap
                };

                TextBlock tb2 = new TextBlock
                {
                    FontSize = CustomColorFontSize,
                    Text = CustomColorText,
                    Foreground = new SolidColorBrush(Colors.Black),
                    RenderTransform = transformGroup1,
                    FontWeight = this.CustomColorFontWeight,
                    TextWrapping = TextWrapping.Wrap
                };

                txtBlock.Foreground = new SolidColorBrush(Colors.White);

                Grid grid = new Grid();
                grid.Children.Add(tb1);
                grid.Children.Add(tb2);
                grid.Children.Add(txtBlock);

                MainGrid.Children.Add(grid);
            }
            else if ("Beige".Equals(textboxName))
            {
                TranslateTransform translateTransform = new TranslateTransform
                {
                    X = 1,
                    Y = 1
                };
                TransformCollection transforms = new TransformCollection
                {
                    translateTransform
                };
                TransformGroup transformGroup = new TransformGroup
                {
                    Children = transforms
                };

                TextBlock tb1 = new TextBlock
                {
                    FontSize = CustomColorFontSize,
                    Text = CustomColorText,
                    Foreground = new SolidColorBrush(Colors.Black),
                    RenderTransform = transformGroup,
                    FontWeight = this.CustomColorFontWeight,
                    TextWrapping = TextWrapping.Wrap
                };

                //txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFF2E0"));
                txtBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFA64D"));

                Grid grid = new Grid();
                grid.Children.Add(tb1);
                grid.Children.Add(txtBlock);

                MainGrid.Children.Add(grid);
            }
            else
            {
                txtBlock.Foreground = new SolidColorBrush(Colors.Black);
                MainGrid.Children.Add(txtBlock);
            }
        }
    }
}
