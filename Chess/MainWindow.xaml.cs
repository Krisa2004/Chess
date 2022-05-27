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

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Chessboard _chessboard;
        public MainWindow()
        {
            InitializeComponent();
            // 310 514
            _chessboard = new Chessboard(this, 20, 500);
        }

        private void OnRadioClick(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton) sender;
            switch (button.Name)
            {
                case "lightPawnRB":
                    _chessboard.CurrentPiece = Piece.LightPawn;
                    break;
                case "darkPawnRB":
                    _chessboard.CurrentPiece = Piece.DarkPawn;
                    break;
                case "rookRB":
                    _chessboard.CurrentPiece = Piece.Rook;
                    break;
                case "knightRB":
                    _chessboard.CurrentPiece = Piece.Knight;
                    break;
                case "bishopRB":
                    _chessboard.CurrentPiece = Piece.Bishop;
                    break;
                case "queenRB":
                    _chessboard.CurrentPiece = Piece.Queen;
                    break;
                case "kingRB":
                    _chessboard.CurrentPiece = Piece.King;
                    break;
            }
        }
    }
}