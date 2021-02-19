using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button">0 = left, 1 = right, 2 = middle</param>
        public void MouseDown(int button)
        {
            unsafe
            {
                int* ptrToValue = &button;
                SteamHTMLSurface.Internal.MouseDown(Handle, (IntPtr)ptrToValue);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button">0 = left, 1 = right, 2 = middle</param>
        public void MouseUp(int button)
        {
            unsafe
            {
                int* ptrToValue = &button;
                SteamHTMLSurface.Internal.MouseUp(Handle, (IntPtr)ptrToValue);
            }
        }

        public void MouseWheel(int delta)
        {
            SteamHTMLSurface.Internal.MouseWheel(Handle, delta);
        }

    }
}
