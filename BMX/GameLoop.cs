using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMX
{
    public partial class GameLoop : Form
    {
        private readonly SKControl skView;
        private GameState gameState;
        private bool runRenderLoop = true;

        public GameLoop()
        {
            Text = "BMX";
            ClientSize = new Size(1920, 1080);

            skView = new SKControl();
            skView.Dock = DockStyle.Fill;
            Controls.Add(skView);

            skView.PaintSurface += Render;
            skView.MouseClick += HandleMouseClick;
            skView.KeyPress += HandleKeyPress;

            gameState = new GameState();

            _ = PresentLoop();
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            InputHandler.HandleMouseClick(e, gameState);
        }

        private void HandleKeyPress(Object sender, KeyPressEventArgs e)
        {
            InputHandler.HandleKeyPress(e, gameState);
        }

        private void Render(object sender, SKPaintSurfaceEventArgs e)
        {
            Renderer.Render(e, gameState);
        }

        private async Task PresentLoop()
        {
            while (runRenderLoop)
            {
                gameState = GameEngine.UpdateGameState(gameState);
                skView.Invalidate();

                await Task.Delay(16).ConfigureAwait(true);
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                runRenderLoop = false;
                skView.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
