using DvlShortcutSync.Domain;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DvlShortcutSync.WinForm
{
    public partial class FormDvlSync : Form
    {
        private bool _exitClicked = false;

        public FormDvlSync()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.CustomNotifyIcon.Visible = true;
            timer1.Interval = ReadJson().TimerInMilliseconds;
            timer1.Start();
            Sync();
        }

        private void OpenForm()
        {
            this.WindowState = FormWindowState.Normal;
            var jsonFile = ReadJson();
            textBoxItems.Text = string.Join(Environment.NewLine, jsonFile.Paths.ToArray());
            textBoxTimer.Text = jsonFile.TimerInMilliseconds.ToString();
        }

        private Item ReadJson()
        {
            var item = new Item();
            using (StreamReader r = new StreamReader("Settings.json"))
            {
                string json = r.ReadToEnd();
                item = JsonConvert.DeserializeObject<Item>(json);
            }

            return item;
        }

        private void HideForm()
        {
            this.WindowState = FormWindowState.Minimized;
            errorProviderTimer.Clear();
        }

        private void Sync()
        {
            var item = ReadJson();
            string[] paths = item.Paths.ToArray();

            foreach (var path in paths)
            {
                var p = path.Split(',');
                for (int j = 1; j < p.Length; j++)
                {
                    try
                    {
                        FoldersWorker.Sync2Folders(p[j].Trim(), p[j - 1].Trim());
                    }
                    catch (Exception exc)
                    {
                        //Log exception
                    }
                }
            }
        }

        #region Events

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                Sync();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxTimer.Text, out int interval) && interval >= 5000)
            {
                var item = new Item
                {
                    Paths = textBoxItems.Text.Split(new[]
                        {System.Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList(),
                    TimerInMilliseconds = interval
                };
                string json = JsonConvert.SerializeObject(item);
                timer1.Interval = interval;

                //write string to file
                System.IO.File.WriteAllText("Settings.json", json);
                HideForm();
                Sync();
            }
            else
            {
                errorProviderTimer.SetError(textBoxTimer, "Interval should be integer and more or equal than 5 seconds");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormDvlSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._exitClicked)
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._exitClicked = true;
            Close();
        }

        private void CustomNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CustomNotifyIcon.ContextMenuStrip.Show();
            else if (e.Button == MouseButtons.Left)
                OpenForm();
        }
#endregion

    }
}
