using System.IO;
using System.Windows;
using Microsoft.Web.WebView2.Core;

namespace WpfCesium;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += async (sender, e) =>
        {
            var op = new CoreWebView2EnvironmentOptions("--disable-web-security");//设置禁用CORS
            var env = await CoreWebView2Environment.CreateAsync(null, null, op);
            await WebView.EnsureCoreWebView2Async(env);
            if (WebView != null && WebView.CoreWebView2 != null)
            {
                FileInfo fileInfo = new(@".\lib\index.html");
                WebView.CoreWebView2.Navigate("file:///" + fileInfo.FullName.Replace('\\', '/'));
            }
        };

        Unloaded += (sender, e) => WebView.Dispose();
    }
}
