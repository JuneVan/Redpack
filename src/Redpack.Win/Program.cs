using System;
using System.Windows.Forms;

namespace Redpack
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);



            try
            {
                //����Ӧ�ó������쳣��ʽ��ThreadException����
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //����UI�߳��쳣
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //�����UI�߳��쳣
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                #region Ӧ�ó��������ڵ�
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception).Message, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
