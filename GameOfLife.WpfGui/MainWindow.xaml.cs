using System;
using System.Windows;
using System.Windows.Controls;

namespace GameOfLife.WpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PixelWidth = 10;
        private const int PixelHeight = 10;
        private readonly int _xSize;
        private readonly int _ySize;
        private Canvas _canvas;
        private GameOfLife.Core.GameOfLife _gof;

        public MainWindow()
        {
            InitializeComponent();
            _canvas = Canvas;

            _xSize = (int) Math.Floor(_canvas.Width/PixelWidth);
            _ySize = (int) Math.Floor(_canvas.Width/PixelHeight);
        }

        public void InitializeGameOfLife()
        {
            _gof = new GameOfLife.Core.GameOfLife(_xSize, _ySize);
        }
    }
}