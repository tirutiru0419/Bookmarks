using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace Bookmarks
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(home));

            string appName = Windows.ApplicationModel.Package.Current.DisplayName;

            //NavView.MenuItemsSource = new NavViewItems();

            double newWidth = 2;
            double newHeight = 3;
            bool result
              = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView()
                .TryResizeView(new Size { Width = newWidth, Height = newHeight });
        }

        //押されたアイテムの処理
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "home":
                        ContentFrame.Navigate(typeof(home));
                        NavView.Header = "ホーム";
                        break;

                    case "signup":
                        ContentFrame.Navigate(typeof(signin));
                        NavView.Header = "サインアップ";
                       
                        break;

                    case "signin":
                        ContentFrame.Navigate(typeof(Signup));
                        NavView.Header = "サインイン";
                        break;

                    case "signout":
                        ContentFrame.Navigate(typeof(Page));
                        NavView.Header = "サインアウト";
                        break;

                    case "work":
                        ContentFrame.Navigate(typeof (BookmarkList));

                        //確認用
                        signin.Visibility = Visibility.Collapsed;
                        signup.Visibility = Visibility.Collapsed;
                        signout.Visibility = Visibility.Visible;

                        NavView.Header = "仕事";
                        break;

                    case "music":
                        ContentFrame.Navigate(typeof(BookmarkList));
                        NavView.Header = "音楽";
                        break;

                    case "enter":
                        ContentFrame.Navigate(typeof(BookmarkList));
                        NavView.Header = "芸能";
                        break;

                    case "sport":
                        ContentFrame.Navigate(typeof(BookmarkList));
                        NavView.Header = "スポーツ";
                        break;

                    case "fashion":
                        ContentFrame.Navigate(typeof(BookmarkList));
                        NavView.Header = "ファッション";
                        break;

                    case "game":
                        ContentFrame.Navigate(typeof(BookmarkList));
                        NavView.Header = "ゲーム";
                        break;

                    case "other":
                        ContentFrame.Navigate(typeof(BookmarkList));
                        NavView.Header = "その他";
                        break;
                }
            }
        }
    }
}
