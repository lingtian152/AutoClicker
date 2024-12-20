using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker
{
    /// <summary>
    /// code source from: https://www.cnblogs.com/zhaoshujie/p/14294614.html
    /// key hook class
    /// </summary>
    class KeyboardHook
    {
        public event KeyEventHandler KeyDownEvent;
        public event KeyPressEventHandler KeyPressEvent;
        public event KeyEventHandler KeyUpEvent;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        private static int hKeyboardHook = 0; // 声明键盘钩子处理的初始值
        public const int WH_KEYBOARD_LL = 13; // 全局键盘监听鼠标消息设为13
        private HookProc keyboardHookProcedure; // 声明KeyboardHookProcedure作为HookProc类型

        // 键盘结构
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  // 定义一个虚拟键码。该代码必须有一个价值的范围1至254
            public int scanCode; // 指定的硬件扫描码的关键
            public int flags;  // 键标志
            public int time; // 指定的时间戳记的这个讯息
            public int dwExtraInfo; // 指定额外信息相关的信息
        }

        // 使用此功能，安装了一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        // 调用此函数卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // 使用此功能，通过信息钩子继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        // 取得当前线程编号（线程钩子需要用到）
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        // 使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        // ToAscii职能的转换指定的虚拟键码和键盘状态的相应字符或字符
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        // 获取按键的状态
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        private const int WM_KEYDOWN = 0x100; // KEYDOWN
        private const int WM_KEYUP = 0x101; // KEYUP
        private const int WM_SYSKEYDOWN = 0x104; // SYSKEYDOWN
        private const int WM_SYSKEYUP = 0x105; // SYSKEYUP

        public void Start()
        {
            // 安装键盘钩子
            if (hKeyboardHook == 0)
            {
                keyboardHookProcedure = KeyboardHookProc;
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);

                // 如果SetWindowsHookEx失败
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("安装键盘钩子失败");
                }
            }
        }

        public void Stop()
        {
            if (hKeyboardHook != 0)
            {
                bool retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;

                if (!retKeyboard)
                {
                    throw new Exception("卸载钩子失败！");
                }
            }
        }

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 侦听键盘事件
            if (nCode >= 0 && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))
            {
                var keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                // raise KeyDown
                if (KeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    var keyData = (Keys)keyboardHookStruct.vkCode;
                    var e = new KeyEventArgs(keyData);
                    KeyDownEvent(this, e);
                }

                // 键盘按下
                if (KeyPressEvent != null && wParam == WM_KEYDOWN)
                {
                    var keyState = new byte[256];
                    GetKeyboardState(keyState);

                    var inBuffer = new byte[2];
                    if (ToAscii(keyboardHookStruct.vkCode, keyboardHookStruct.scanCode, keyState, inBuffer, keyboardHookStruct.flags) == 1)
                    {
                        var e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPressEvent(this, e);
                    }
                }

                // 键盘抬起
                if (KeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    var keyData = (Keys)keyboardHookStruct.vkCode;
                    var e = new KeyEventArgs(keyData);
                    KeyUpEvent(this, e);
                }
            }

            // 如果返回1，则结束消息，这个消息到此为止，不再传递。
            // 如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }

        ~KeyboardHook()
        {
            Stop();
        }
    }
}