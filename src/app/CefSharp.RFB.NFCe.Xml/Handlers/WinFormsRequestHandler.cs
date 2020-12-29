using CefSharp;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.RFB.NFCe.Xml
{
    class WinFormsRequestHandler : IRequestHandler
    {
        public bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            Task.Run(() =>
            {
                using (callback)
                {
                    if (originUrl.Contains("https://httpbin.org/basic-auth/"))
                    {
                        var parts = originUrl.Split('/');
                        var username = parts[parts.Length - 2];
                        var password = parts[parts.Length - 1];
                        callback.Continue(username, password);
                    }
                }
            });

            return true;
        }

        public IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            return false;
        }

        public bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            Task.Run(() =>
            {
                //NOTE: When executing the callback in an async fashion need to check to see if it's disposed
                if (!callback.IsDisposed)
                {
                    using (callback)
                    {
                        //We'll allow the expired certificate from badssl.com
                        if (requestUrl.ToLower().Contains("https://expired.badssl.com/"))
                        {
                            callback.Continue(true);
                        }
                        else
                        {
                            callback.Continue(false);
                        }
                    }
                }
            });

            return true;
        }

        public bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;
        }

        public void OnPluginCrashed(IWebBrowser chromiumWebBrowser, IBrowser browser, string pluginPath)
        {

        }

        public bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status)
        {

        }

        public void OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {

        }

        public bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            var control = (Control) chromiumWebBrowser;

            var selectedCertificateCollection = X509Certificate2UI.SelectFromCollection(certificates, "Certificates Dialog", "Select Certificate for authentication", X509SelectionFlag.SingleSelection);

            /// Tip: SelectedCertificateCollection[0] not exist for If user cancel select certificate
            callback.Select(selectedCertificateCollection[0]);

            return true;
        }
    }
}
