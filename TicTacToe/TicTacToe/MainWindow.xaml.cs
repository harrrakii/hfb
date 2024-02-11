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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[,] gameField;
        private Random random = new Random();
        private string HumanField = Figures.Circle;
        private string RobotField = Figures.Cross;
        public MainWindow()
        {
            InitializeComponent();
            gameField = new Button[,] { { button1, button2, button3 }, { button4, button5, button6 }, { button7, button8, button9 } };
        }
        public void MakeMoveHuman(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content != null)
            {
                return;
            }
            button.Content = HumanField;


            if (CheckEndGame())
            {
                NewGameInternal();
                return;
            }
            MakeMoveRobot();
            if (CheckEndGame())
            {
                NewGameInternal();
            }
        }
        public void MakeMoveRobot()
        {
            bool moved = false;
            while (!moved)
            {
                var i = random.Next(0, 3);
                var j = random.Next(0, 3);
                var randomButton = gameField[i, j];
                if (randomButton.Content == null)
                {
                    randomButton.Content = RobotField;
                    moved = true;
                }
            }
        }
        private bool CheckEndGame()
        {
            var winner = CheckWin();
            if (winner != null)
            {
                var winnerString = winner == HumanField ? "человека" : "робота";
                MessageBox.Show($"Победа {winnerString}");
                return true;
            }
            if (CheckDraw())
            {
                MessageBox.Show("Ничья");
                return true;
            }
            return false;
        }
        private string CheckWin()
        {
            for (var i = 0; i < 3; i++)
            {
                if (gameField[i, 0].Content != null && gameField[i, 0].Content == gameField[i, 1].Content && gameField[i, 1].Content == gameField[i, 2].Content)
                    return gameField[i, 0].Content.ToString();
                if (gameField[0, i].Content != null && gameField[0, i].Content == gameField[1, i].Content && gameField[1, i].Content == gameField[2, i].Content)
                    return gameField[0, i].Content.ToString();
            }
            if (gameField[0, 0].Content != null && gameField[0, 0].Content == gameField[1, 1].Content && gameField[1, 1].Content == gameField[2, 2].Content)
                return gameField[0, 0].Content.ToString();
            if (gameField[0, 2].Content != null && gameField[0, 2].Content == gameField[1, 1].Content && gameField[1, 1].Content == gameField[2, 0].Content)
                return gameField[0, 2].Content.ToString();
            return null;
        }
        private bool CheckDraw()
        {
            for (var row = 0; row < gameField.GetLength(0); row++)
            {
                for (var col = 0; col < gameField.GetLength(1); col++)
                {
                    if (gameField[row, col].Content == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void NewGame(object sender, RoutedEventArgs e)
        {

            NewGameInternal();
        }
        private void NewGameInternal()
        {
            for (var i = 0; i < gameField.GetLength(0); i++)
            {
                for (var j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j].IsEnabled = true;
                    gameField[i, j].Content = null;
                }
            }
            HumanField = HumanField == Figures.Circle ? Figures.Cross : Figures.Circle;
            RobotField = RobotField == Figures.Circle ? Figures.Cross : Figures.Circle;
            Human.Text = $"Человек играет за {HumanField}";
            Robot.Text = $"Робот играет за {RobotField}";
            if (RobotField == Figures.Cross)
            {
                MakeMoveRobot();
            }
        }
    }
}