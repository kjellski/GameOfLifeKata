using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GameOfLife.Core;

namespace GameOfLife.WpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PixelWidth = 10;
        private const int PixelHeight = 10;
        private readonly Core.GameOfLife _gof;
        private double _actualHeight;
        private double _actualWidth;
        private Canvas _canvas;
        private int _xSize;
        private int _ySize;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCanvas();
            _gof = new Core.GameOfLife(GameOfLifeStringReader.Read(ExampleLands.Land1));

            DrawLand();
        }

        private void InitializeCanvas()
        {
            _canvas = LandCanvas;
            _actualWidth = _canvas.Width;
            _actualHeight = _canvas.Height;
            _xSize = (int)Math.Floor(_actualWidth / PixelWidth);
            _ySize = (int)Math.Floor(_actualHeight / PixelHeight);
        }

        private void DrawLand()
        {
            _canvas.Children.Clear();
            var actualLand = _gof.Land;
            for (var y = 0; y < _ySize; y++)
            {
                for (var x = 0; x < _xSize; x++)
                {
                    var isCellAlive = Core.GameOfLife.IsCellAlive(x, y, actualLand);

                    var rect = new Rectangle
                    {
                        Width = PixelWidth,
                        Height = PixelHeight,
                        Fill = isCellAlive ? Brushes.Black : Brushes.White,
                        Stroke = Brushes.Gray
                    };

                    Canvas.SetTop(rect, y * PixelHeight);
                    Canvas.SetLeft(rect, x * PixelWidth);
                    _canvas.Children.Add(rect);
                }
            }
        }
        
        private void LandGrid_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawLand();
        }
    
        private void Window_OnKeyDown(object sender, KeyEventArgs e)
        {
            _gof.NextGeneration();
            DrawLand();
        }
    }
}