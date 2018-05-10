using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //private void Page1_Click(object sender, RoutedEventArgs e)
        //{
        //    this.frmMain.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        //}
        private Task RunNewWindowAsync<TWindow>() where TWindow : System.Windows.Window, new()
        {
            TaskCompletionSource<object> tc = new TaskCompletionSource<object>();
            // 新线程
            Thread t = new Thread(() =>
            {
                TWindow win = new TWindow();
                win.Closed += (d, k) =>
                {
                    // 当窗口关闭后马上结束消息循环
                    System.Windows.Threading.Dispatcher.ExitAllFrames();
                };
                win.Show();
                // Run 方法必须调用，否则窗口一打开就会关闭
                // 因为没有启动消息循环
                System.Windows.Threading.Dispatcher.Run();
                // 这句话是必须的，设置Task的运算结果
                // 但由于此处不需要结果，故用null
                tc.SetResult(null);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            // 新线程启动后，将Task实例返回
            // 以便支持 await 操作符
            return tc.Task;
        }

        private async void Win1_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            b.IsEnabled = false;
            await RunNewWindowAsync<Window1>(); //可异步等待
            b.IsEnabled = true;
        }
        private async void Win2_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            b.IsEnabled = false;
            await RunNewWindowAsync<Window2>(); //可异步等待
            b.IsEnabled = true;
        }
    }
}
