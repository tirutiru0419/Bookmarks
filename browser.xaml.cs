using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace Bookmarks
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class browser : Page
    {
        public browser()
        {
            this.InitializeComponent();

            this.webView1.NavigationCompleted += webView1_NavigationCompleted;

        }

        //アドレスバーの右の矢印をタップされた
        private async void buttonGo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Uri newUri;
            if (Uri.TryCreate(this.textBox1.Text, UriKind.Absolute, out newUri)
                && newUri.Scheme.StartsWith("http"))
            {
                this.webView1.Navigate(newUri);
            }
            else
            {
                // エラー処理
                string errMsg = @"入力された文字列がURIとして不正か、""http""で始まっていません";
                await new Windows.UI.Popups.MessageDialog(errMsg).ShowAsync();
            }
        }

        // ［戻る］ボタンがタップされた
        private void buttonGoBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.webView1.GoBack();
        }

        // ［進む］ボタンがタップされた
        private void buttonGoForward_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.webView1.GoForward();
        }

        // ［リフレッシュ］ボタンがタップされた
        private void buttonRefresh_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.webView1.Refresh();
        }

        //エラー表示
        async void webView1_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (!args.IsSuccess)
            {
                // エラー発生
                string errMsg = args.WebErrorStatus.ToString();
                int errCode = (int)args.WebErrorStatus;
                string msg = string.Format("サーバ側エラー：{0}（{1}）", errMsg, errCode);
                await new Windows.UI.Popups.MessageDialog(msg).ShowAsync();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string item = e.Parameter as string;
            
            if (item != null)
            {
                base.OnNavigatedTo(e);
                textBox1.Text = item;

            }

        }

        //ダイアログ保存ボタン
        private void Dialog1_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Work.IsChecked == true) 
            {
                return;
            }

            else if (Music.IsChecked == true)
            {
                return;

            }

            else if (Entertainment.IsChecked == true)
            {
                return;

            }

            else if (Sports.IsChecked == true)
            {
                return;

            }

            else if (Fashion.IsChecked == true)
            {
                return;

            }

            else if (Game.IsChecked == true)
            {
                return;

            }

            else
            {
                return;

            }
        }

        //ダイアログ閉じるボタン
        private void Dialog1_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private async void SaveButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await this.Dialog1.ShowAsync();
        }
    }
}
