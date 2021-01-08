using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Redpack.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            //首先注册开始和退出事件
            Startup += new StartupEventHandler(App_Startup);
            Exit += new ExitEventHandler(App_Exit);
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            //UI线程未捕获异常处理事件
            DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            //Task线程内未捕获异常处理事件
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            //非UI线程未捕获异常处理事件
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        void App_Exit(object sender, ExitEventArgs e)
        {
            //程序退出时需要处理的业务
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true; //把 Handled 属性设为true，表示此异常已处理，程序可以继续运行，不会强制退出      
            MessageBox.Show("UI线程异常:" + e.Exception.Message);

        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            StringBuilder  stringBuilder = new StringBuilder();
            if (e.IsTerminating)
            {
                stringBuilder.Append("非UI线程发生致命错误");
            }
            stringBuilder.Append("非UI线程异常：");
            if (e.ExceptionObject is Exception)
            {
                stringBuilder.Append(((Exception)e.ExceptionObject).Message);
            }
            else
            {
                stringBuilder.Append(e.ExceptionObject);
            }
            MessageBox.Show(stringBuilder.ToString());
        }

        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            //task线程内未处理捕获
            MessageBox.Show("Task线程异常：" + e.Exception.Message);
            e.SetObserved();//设置该异常已察觉（这样处理后就不会引起程序崩溃）
        }
    }
}
