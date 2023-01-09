using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimateBackgroundColor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Media.Color Orange = Color.FromRgb(255, 127, 0);
        System.Windows.Media.Color LightOrange = Color.FromRgb(252, 180, 109);

        public MainWindow()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Morbi leo mi, nonummy eget, tristique non, rhoncus non, leo. Nullam faucibus mi quis velit.Integer in sapien.Fusce tellus odio, dapibus id, fermentum quis, suscipit id, erat. Fusce aliquam vestibulum ipsum. Aliquam erat volutpat.Pellentesque sapien. Cras elementum. Nulla pulvinar eleifend sem. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Quisque porta. Vivamus porttitor turpis ac leo.");
            sb.AppendLine("Aenean placerat. In vulputate urna eu arcu.Aliquam erat volutpat.Suspendisse potenti. Morbi mattis felis at nunc.Duis viverra diam non justo.In nisl. Nullam sit amet magna in magna gravida vehicula.Mauris tincidunt sem sed arcu.Nunc posuere. Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Etiam neque. Curabitur ligula sapien, pulvinar a, vestibulum quis, facilisis vel, sapien. Nullam eget nisl.Donec vitae arcu.");
            sb.AppendLine("Aenean placerat. In vulputate urna eu arcu.Aliquam erat volutpat.Suspendisse potenti. Morbi mattis felis at nunc.Duis viverra diam non justo.In nisl. Nullam sit amet magna in magna gravida vehicula.Mauris tincidunt sem sed arcu.Nunc posuere. Nullam lectus justo, vulputate eget, mollis sed, tempor sed, magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Etiam neque. Curabitur ligula sapien, pulvinar a, vestibulum quis, facilisis vel, sapien. Nullam eget nisl.Donec vitae arcu.");
            sb.AppendLine("Maecenas ipsum velit, consectetuer eu, lobortis ut, dictum at, dui. In rutrum. Sed ac dolor sit amet purus malesuada congue. In laoreet, magna id viverra tincidunt, sem odio bibendum justo, vel imperdiet sapien wisi sed libero.Suspendisse sagittis ultrices augue. Mauris metus. Nunc dapibus tortor vel mi dapibus sollicitudin.Etiam posuere lacus quis dolor.Praesent id justo in neque elementum ultrices.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. In convallis. Fusce suscipit libero eget elit.Praesent vitae arcu tempor neque lacinia pretium.Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus.");

            SourceText.Text = sb.ToString();
            AnimateBackGroundColor(SourceText, Colors.LightSkyBlue, Colors.White);
        }

        private void BtnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(SourceText.Text);

            AnimateBackGroundColor(SourceText, Colors.LightSkyBlue, Colors.White);
        }


        private void SmallFontMouseDown(object sender, MouseButtonEventArgs e)
        {
            var fontsize = this.SourceText.FontSize;
            fontsize -= 1;

            if (fontsize < 10)
                fontsize = 10;
            this.SourceText.FontSize = fontsize;
            AnimateBackGroundColor(SourceText, LightOrange, Colors.White);
        }

        private void BigFontMouseDown(object sender, MouseButtonEventArgs e)
        {
            var fontsize = this.SourceText.FontSize;
            fontsize += 1;

            if (fontsize > 30)
                fontsize = 30;

            this.SourceText.FontSize = fontsize;
            AnimateBackGroundColor(SourceText, Orange, Colors.White);

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.Clear();
            SourceText.Clear();
            AnimateBackGroundColor(SourceText, Colors.LightGray, Colors.White);
        }




        private void AnimateBackGroundColor(System.Windows.Controls.TextBox tb,
                    Color from, Color to)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds(.9));
            tb.Background = new SolidColorBrush(from);
            tb.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);

        }
    }
}
