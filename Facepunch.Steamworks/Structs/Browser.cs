﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steamworks.Structs
{
    public struct Browser
    {

        public readonly uint Handle;

        public Browser(uint handle)
        {
            Handle = handle;
        }

        public static async Task<Browser> Create(string userAgent = null, string userCss = null)
        {
            var result = await SteamHTMLSurface.Internal.CreateBrowser(userAgent, userCss);
            return new Browser(result.Value.UnBrowserHandle);
        }

        public void FileLoadDialogResponse(string selectedFiles)
        {
            SteamHTMLSurface.Internal.FileLoadDialogResponse(Handle, selectedFiles);
        }

        public void JSDialogResponse(bool response)
        {
            SteamHTMLSurface.Internal.JSDialogResponse(Handle, response);
        }

        public void AllowStartRequest(bool allowed)
        {
            SteamHTMLSurface.Internal.AllowStartRequest(Handle, allowed);
        }

        public void SetSize(int width, int height)
        {
            SteamHTMLSurface.Internal.SetSize(Handle, (uint)width, (uint)height);
        }

        public void LoadURL(string url, string postData = null)
        {
            SteamHTMLSurface.Internal.LoadURL(Handle, url, postData);
        }

        public void Remove()
        {
            SteamHTMLSurface.Internal.RemoveBrowser(Handle);
        }

        public void MouseMove(int x, int y)
        {
            SteamHTMLSurface.Internal.MouseMove(Handle, x, y);
        }

        public void KeyDown(int nativeKeyCode, bool alt, bool ctrl, bool shift, bool isSystemKey = false)
        {
            int keyModifiers = 0;
            if (alt) keyModifiers |= 1 << 0;
            if (ctrl) keyModifiers |= 1 << 1;
            if (shift) keyModifiers |= 1 << 2;
            SteamHTMLSurface.Internal.KeyDown(Handle, (uint)nativeKeyCode, keyModifiers, isSystemKey);
        }

        public void KeyChar(char unicode, bool alt, bool ctrl, bool shift)
        {
            int keyModifiers = 0;
            if (alt) keyModifiers |= 1 << 0;
            if (ctrl) keyModifiers |= 1 << 1;
            if (shift) keyModifiers |= 1 << 2;
            SteamHTMLSurface.Internal.KeyChar(Handle, unicode, keyModifiers);
        }

        public void KeyUp(int nativeKeyCode, bool alt, bool ctrl, bool shift)
        {
            int keyModifiers = 0;
            if (alt) keyModifiers |= 1 << 0;
            if (ctrl) keyModifiers |= 1 << 1;
            if (shift) keyModifiers |= 1 << 2;
            SteamHTMLSurface.Internal.KeyUp(Handle, (uint)nativeKeyCode, keyModifiers);
        }

        public void SetKeyFocus(bool hasFocus)
        {
            SteamHTMLSurface.Internal.SetKeyFocus(Handle, hasFocus);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button">0 = left, 1 = right, 2 = middle</param>
        public void MouseDown(int button)
        {
            SteamHTMLSurface.Internal.MouseDown(Handle, button);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button">0 = left, 1 = right, 2 = middle</param>
        public void MouseUp(int button)
        {
            SteamHTMLSurface.Internal.MouseUp(Handle, button);
        }

        public void MouseWheel(int delta)
        {
            SteamHTMLSurface.Internal.MouseWheel(Handle, delta);
        }

    }
}
