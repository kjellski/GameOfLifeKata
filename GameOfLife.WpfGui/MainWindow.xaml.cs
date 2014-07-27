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
        private int _xSize = 0;
        private int _ySize = 0;
        private Canvas _canvas;
        private Core.GameOfLife _gof;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeGameOfLife();
        }

        private void InitializeCanvas()
        {
            _canvas = LandCanvas;

            _xSize = (int) Math.Floor(_canvas.ActualWidth/PixelWidth);
            _ySize = (int) Math.Floor(_canvas.ActualHeight/PixelHeight);
        }

        public void InitializeGameOfLife()
        {
            _gof = new Core.GameOfLife(_xSize, _ySize);
        }

        public void DrawLandOnCanvas()
        {
            var rect = new Rect(new Point(50, 50), new Size(PixelWidth, PixelHeight));
        }
    }
}