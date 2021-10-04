﻿using SkiaSharp.Views.Desktop;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMX.Engine.Interfaces;
using BMX.Models;

namespace BMX
{
    internal partial class GameForm : Form
    {
        private readonly IInputHandler _inputHandler;
        private readonly IRenderEngine _renderer;

        private readonly SKControl _skView;
        private ApplicationState _applicationState;
        private bool _runRenderLoop = true;

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

            _applicationState = new ApplicationState
            {
                GameState = new GameState(),
                UIState = new UIState()
            };

            _ = PresentLoop();
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            _applicationState = _inputHandler.HandleMouseClick(e, _applicationState);
        }

        private void HandleKeyPress(Object sender, KeyPressEventArgs e)
        {
            _applicationState = _inputHandler.HandleKeyPress(e, _applicationState);
        }

        private void Render(object sender, SKPaintSurfaceEventArgs e)
        {
            _renderer.Render(e, _applicationState);
        }

        private async Task PresentLoop()
        {
            while (_runRenderLoop)
            {
                _applicationState = _applicationState with { GameState = GameEngine.UpdateGameState(_applicationState.GameState)};
                _skView.Invalidate();

                await Task.Delay(GameEngine.GetTickLength(_applicationState.GameState)).ConfigureAwait(true);
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
