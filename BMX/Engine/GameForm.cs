using SkiaSharp.Views.Desktop;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMX.Engine.Interfaces;

namespace BMX
{
    internal partial class GameForm : Form
    {
        private readonly IInputHandler _inputHandler;
        private readonly IRenderEngine _renderer;

        private readonly SKControl _skView;
        private GameState _gameState;
        private bool _runRenderLoop = true;
        private const int GameTickLengthMS = 16;

        public GameForm(IInputHandler inputHandler, IRenderEngine renderer)
        {
            _inputHandler = inputHandler;
            _renderer = renderer;


            Text = "BMX";
            ClientSize = new Size(1920, 1080);

            _skView = new SKControl();
            _skView.Dock = DockStyle.Fill;
            Controls.Add(_skView);

            _skView.PaintSurface += Render;
            _skView.MouseClick += HandleMouseClick;
            _skView.KeyPress += HandleKeyPress;

            _gameState = new GameState();

            _ = PresentLoop();
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            _gameState = _inputHandler.HandleMouseClick(e, _gameState);
        }

        private void HandleKeyPress(Object sender, KeyPressEventArgs e)
        {
            _gameState = _inputHandler.HandleKeyPress(e, _gameState);
        }

        private void Render(object sender, SKPaintSurfaceEventArgs e)
        {
            _renderer.Render(e, _gameState);
        }

        private async Task PresentLoop()
        {
            while (_runRenderLoop)
            {
                _gameState = GameEngine.UpdateGameState(_gameState);
                _skView.Invalidate();

                await Task.Delay(GameEngine.GetTickLength(_gameState)).ConfigureAwait(true);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _runRenderLoop = false;
                _skView.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
