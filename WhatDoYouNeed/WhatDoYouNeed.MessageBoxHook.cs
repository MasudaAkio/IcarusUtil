using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Icarus
{
    public partial class WhatDoYouNeed
    {
        private IntPtr HHook;

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SetHook(this);
        //    MessageBox.Show(this, "確認メッセージです", "確認");
        //}

        private void PrepareCenteringMessageBoxOnTheForm(IWin32Window owner)
        {
            // フック設定
            IntPtr hInstance = WindowsAPI.GetWindowLong(this.Handle, (int)WindowsAPI.WindowLongParam.GWLP_HINSTANCE);
            IntPtr threadId = WindowsAPI.GetCurrentThreadId();
            HHook = WindowsAPI.SetWindowsHookEx((int)WindowsAPI.HookType.WH_CBT, new WindowsAPI.HOOKPROC(CBTProc), hInstance, threadId);
        }

        private IntPtr CBTProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == (int)WindowsAPI.HCBT.HCBT_ACTIVATE)
            {
                WindowsAPI.RECT rectOwner;
                WindowsAPI.RECT rectMsgBox;
                int x, y;

                // オーナーウィンドウの位置と大きさを取得
                WindowsAPI.GetWindowRect(this.Handle, out rectOwner);
                // MessageBoxの位置と大きさを取得
                WindowsAPI.GetWindowRect(wParam, out rectMsgBox);

                // MessageBoxの表示位置を計算
                x = rectOwner.Left + (rectOwner.Width - rectMsgBox.Width) / 2;
                y = rectOwner.Top + (rectOwner.Height - rectMsgBox.Height) / 2;

                //MessageBoxの位置を設定
                WindowsAPI.SetWindowPos(wParam, 0, x, y, 0, 0,
                  (uint)(WindowsAPI.SetWindowPosFlags.SWP_NOSIZE | WindowsAPI.SetWindowPosFlags.SWP_NOZORDER | WindowsAPI.SetWindowPosFlags.SWP_NOACTIVATE));

                // フック解除
                WindowsAPI.UnhookWindowsHookEx(HHook);
            }
            // 次のプロシージャへのポインタ
            return WindowsAPI.CallNextHookEx(HHook, nCode, wParam, lParam);
        }
    }
}
