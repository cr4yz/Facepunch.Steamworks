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

        public static async Task<Browser> Create(string userAgent, string userCss)
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

        public void SetSize(uint width, uint height)
        {
            SteamHTMLSurface.Internal.SetSize(Handle, width, height);
        }

        public void LoadURL(string url, string postData)
        {
            SteamHTMLSurface.Internal.LoadURL(Handle, url, postData);
        }

        public void Remove()
        {
            SteamHTMLSurface.Internal.RemoveBrowser(Handle);
        }

    }
}
