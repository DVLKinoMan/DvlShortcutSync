using DvlShortcutSync.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            FillDataGrid();
            textBoxTimer.Text = jsonFile.TimerInMilliseconds.ToString();
        }

        private void FillDataGrid()
        {
            var jsonFile = ReadJson();
            dataGridViewFoldersToSync.Rows.Clear();
            foreach (var sync in jsonFile.Paths)
            {
                var arr = sync.Split(',');
                dataGridViewFoldersToSync.Rows.Add(arr[0], arr[1]);
            }
        }

        private Settings ReadJson()
        {
            var item = new Settings();
            using (StreamReader r = new StreamReader("Settings.json"))
            {
                string json = r.ReadToEnd();
                item = JsonConvert.DeserializeObject<Settings>(json);
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
                var item = new Settings
                {
                    Paths = ReadPathsFromDataGrid(),
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

        private List<string> ReadPathsFromDataGrid()
        {
            var list = new List<string>();
            foreach (DataGridViewRow row in dataGridViewFoldersToSync.Rows)
                if (row.Cells.Count == 2 && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()) &&
                    !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                    list.Add($"{row.Cells[0].Value}, {row.Cells[1].Value}");

            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormDvlSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && !this._exitClicked)
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

        private void dataGridViewFoldersToSync_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridViewFoldersToSync.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
