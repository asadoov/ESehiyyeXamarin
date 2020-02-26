
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ESehiyye.Controller
{
    [Activity(Label = "PasswordRecoveryActivity")]
    public class PasswordRecoveryActivity : Activity
    {
        Android.Webkit.WebView webview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PasswordRecoveryActivity);


            FindViewById<TextView>(Resource.Id.toolbarTitle).Text="Şifrənin bərpası";
             FindViewById<ImageButton>(Resource.Id.backBtn).Visibility=ViewStates.Visible;
            webview = FindViewById<Android.Webkit.WebView>(Resource.Id.passRecover); //new Android.Webkit.WebView(this);
            webview.Settings.JavaScriptEnabled = true;
            webview.Settings.AllowUniversalAccessFromFileURLs = true;
            webview.Settings.AllowFileAccessFromFileURLs = true;
            webview.Settings.AllowFileAccess = false;
            webview.Settings.UseWideViewPort = true;
            webview.Settings.LoadWithOverviewMode = true;
            webview.Settings.BuiltInZoomControls = false;
            webview.Settings.DisplayZoomControls = false;
            // webview.Settings.SupportZoom();

            //webview.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///{0}", "Ghaznavi Beirami və d..pdf")));
            webview.LoadUrl("https://eservice.e-health.gov.az/Login/Login/PasswordReset");//, string.Format("file:///{0}", "Ghaznavi Beirami və d..pdf")));


            webview.SetWebChromeClient(new Android.Webkit.WebChromeClient());
        }
         [Java.Interop.Export("backClicked")]
        public void backClicked(View v)
        {


            OnBackPressed();
            //Toast.MakeText(ApplicationContext, "esdasad", ToastLength.Long).Show();

        }
    }
}
