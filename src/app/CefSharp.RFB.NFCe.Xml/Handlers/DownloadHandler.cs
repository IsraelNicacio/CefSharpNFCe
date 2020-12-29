using CefSharp;
using System;
using System.IO;

namespace CefSharp.RFB.NFCe.Xml
{
    class DownloadHandler : IDownloadHandler
    {
        private string filePath;
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;
        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public DownloadHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            OnBeforeDownloadFired?.Invoke(this, downloadItem);

            if (!callback.IsDisposed)
            {
                using (callback)
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: false);
            }
        }

        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            OnDownloadUpdatedFired?.Invoke(this, downloadItem);
        }
    }
}
