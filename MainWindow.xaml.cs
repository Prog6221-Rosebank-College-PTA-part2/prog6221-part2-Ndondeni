using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Services;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AudioPlayer _audioPlayer;
        private RespondingServices _responseService;
        private UserProfile _userProfile;


        public MainWindow()
        {
           _userProfile = new UserProfile();
            _audioPlayer = new AudioPlayer();
            _responseService = new RespondingServices();



            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }



        private async void SendText(object sender, RoutedEventArgs e)
        {
            string userMessage = input.Text;


            if (string.IsNullOrWhiteSpace(userMessage))
                return;


            AddMessage(userMessage, true);


            AddMessage("Thinking...", false);

            await Task.Delay(1500);


            if (chatPanel.Children.Count > 0)
                chatPanel.Children.RemoveAt(chatPanel.Children.Count - 1);


            string botReply = _responseService.GetRespond(userMessage);


            AddMessage(botReply, false);

            input.Clear();
        }

        private void AddMessage(string message, bool isUser)
        {
            Border bubble = new Border
            {
                Background = isUser ? System.Windows.Media.Brushes.LightGray : System.Windows.Media.Brushes.LightBlue,
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(10),
                Margin = new Thickness(0, 5, 0, 5),
                HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left,
                MaxWidth = 250
            };

            TextBlock text = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap
            };

            bubble.Child = text;
            chatPanel.Children.Add(bubble);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            _audioPlayer = new AudioPlayer();
            _audioPlayer.welcomeAudio();
            AddMessage($"{_userProfile.GetArt()}",false);
            AddMessage("👋 Welcome to CyberBot! ", false);
        }
    }
    }
