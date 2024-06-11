using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClicker
{
    internal class AutoClicker
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x0002; // Mouse left button down
        const int MOUSEEVENTF_LEFTUP = 0x0004;   // Mouse left button up

        private CancellationTokenSource cancellationTokenSource;

        public async Task StartClick(int clickInterval)
        {
            if (cancellationTokenSource != null)
            {
                return; // Already clicking
            }

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {
                await Task.Run(async () =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                        await Task.Delay(clickInterval, token);
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Handle the cancellation
            }
        }

        public void StopClick()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }
        }
    }
}
