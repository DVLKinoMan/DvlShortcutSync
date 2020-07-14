using DvlShortcutSync.Domain;
using DvlShortcutSync.WinService.Properties;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace DvlShortcutSync.WinService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;

        public Service1()
        {
            InitializeComponent();
            timer = new Timer {AutoReset = false, Interval = 10000};

            timer.Elapsed += new ElapsedEventHandler(DoStuff);
        }

        private void DoStuff(object sender, ElapsedEventArgs e)
        {
        }

        protected override void OnStart(string[] args)
        {
            while (true)
            {
                var foldersToSync = Resources.FoldersToSync.Split(',');
                for (int i = 1; i < foldersToSync.Length; i++)
                    FoldersWorker.Sync2Folders(foldersToSync[i].Trim(), foldersToSync[i - 1].Trim());
                Thread.Sleep(10000);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
