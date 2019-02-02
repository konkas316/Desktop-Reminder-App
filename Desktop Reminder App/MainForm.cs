using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace r
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        SoundPlayer player = new SoundPlayer();

        public bool enabled = false;

        public DataTable dt = new DataTable("AlertTable");
        public DataSet ds = new DataSet();
        public DataColumn dc;

        static int Flag = 0;

        public static string passingText;

        String path = Environment.CurrentDirectory + @"\R.xml";
        public MainForm()
        {
            InitializeComponent();

            //bool result;
            //var mutex = new System.Threading.Mutex(true, "UniqueAppId", out result);
            //if (!result)
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "Another instance is already running.", "Single instance App.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    System.Environment.Exit(1);
            //}


            InitializeSound();

            this.showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

            SetBall();

            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            if (fi.Exists)
            {

                ds.ReadXml(path);

            }
            if (ds.Tables.Count <= 0)
            {
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "DateTime";
                dc.Caption = "Date and Time ";
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "AlertMessage";
                dc.Caption = "Message to be display";
                dt.Columns.Add(dc);


                ds.Tables.Add(dt);
            }
            timer1.Enabled = true;
        }


        private void SetBall()
        {
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            Reg.SetValue("r", Application.ExecutablePath.ToString());
        }


        private bool allowVisible;
        private bool allowClose;

        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void InitializeSound()
        {
            player.SoundLocation = @"C:\Users\Asus\Desktop\KaunasCodingSchoolCSharp\KaunasCodingBaigiamasisProjektas\AlarmClock-SuSpeech\analog-watch-alarm_daniel-simion.Wav";

        }

        private void ShowReminder()
        {

            if (chkSound.Checked)
            {
                player.PlayLooping();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            chkSound.Checked = Properties.Settings.Default.CheckBox;

            datetimepicker1.Location = new Point(90, 7);

            fnDatGridBind();
            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.Columns[0].ReadOnly = true;
            }
        }


        private void fnDatGridBind()
        {

            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Columns[0].Width = 115;
                dataGridView1.Columns[1].Width = 115;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            fnCheck(0, dt);

        }

        private void Clear()
        {
            textBox1.Text = "";
        }

        private void fnCheck(int flag, DateTime dt)
        {
            DataView dv = new DataView();
            dv = ds.Tables[0].DefaultView;
            dv.Sort = "DateTime Asc";
            DataRowView[] rows = dv.FindRows(dt);

            if (flag == 1)
            {
                if (rows.Length > 0)
                {

                    MetroFramework.MetroMessageBox.Show(this, "Already Alert created on this time , Choose other timmings", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);

                    duplicate();

                    DataRow dr = ds.Tables[0].NewRow();
                    dr["DateTime"] = dt.ToString();
                    dr["AlertMessage"] = textBox1.Text.Trim();
                    ds.Tables[0].Rows.Add(dr);
                    ds.WriteXml(path);
                    fnDatGridBind();


                }

                else
                {

                    duplicate();

                    DataRow dr = ds.Tables[0].NewRow();
                    dr["DateTime"] = dt.ToString();
                    dr["AlertMessage"] = textBox1.Text.Trim();
                    ds.Tables[0].Rows.Add(dr);
                    ds.WriteXml(path);
                    fnDatGridBind();


                }
            }

            else
            {

                String d;
                if (rows.Length > 0)
                {
                    d = rows[0][1].ToString();
                    passingText = (d);
                    PopUpForm f2 = new PopUpForm();

                    ShowReminder();

                    f2.BringToFront();
                    f2.TopMost = true;
                    f2.ShowDialog();

                    ds.WriteXml(path);
                    fnDatGridBind();
                }
            }
        }

        public void duplicate()
        {

            for (int row = 0; row < dataGridView1.Rows.Count; row++)

            {

                for (int col = 0; col < dataGridView1.Columns.Count; col++)

                {

                    if (dataGridView1.Rows[row].Cells[col].Value != null &&

                      dataGridView1.Rows[row].Cells[col].Value.Equals(textBox1.Text.Trim()))
                    {
                        //MessageBox.Show("Duplicate");

                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);

                        ds.WriteXml(path);

                    }
                }
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter) || (e.KeyCode == System.Windows.Forms.Keys.Tab))
            {
                CurrencyManager gridCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];

                gridCurrencyManager.EndCurrentEdit();
                dataGridView1.DataSource = gridCurrencyManager;
                ds.AcceptChanges();
                ds.WriteXml(path);
                fnDatGridBind();

            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                ds.AcceptChanges();
                ds.WriteXml(path);
                fnDatGridBind();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Flag == 0)
            {
                DialogResult dr = MetroFramework.MetroMessageBox.Show(this, "If you close the application, no alert to be display, Do you want to close the application?", "Alerts", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {

                    this.Hide();

                }
                if (dr == DialogResult.Yes)
                {
                    allowClose = true;
                    Application.Exit();
                }

            }

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            allowVisible = true;
            this.Show();

        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {

                this.Hide();

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.CheckBox = chkSound.Checked;
            Properties.Settings.Default.Save();

        }


        private void btnAlarmSettings_Click_1(object sender, EventArgs e)
        {
            metroPanel1.Visible = true;

            textBox1.Clear();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            metroPanel1.Visible = true;

            try
            {
                datetimepicker1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Nothing to edit..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
               
      
        private void btnSetAlarm_Click(object sender, EventArgs e)
        {
            if ((datetimepicker1.TabIndex >= 0))
            {
                if (textBox1.Text.Length != 0)
                {
                    String s1 = datetimepicker1.Text;

                    String tmpdate = datetimepicker1.Value.ToShortDateString() + " " + s1;

                    DateTime dt1 = DateTime.Parse(tmpdate);

                    if (dt1 <= DateTime.Now)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Select Date and Time should be greater than the Current Date Time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        fnCheck(1, dt1);

                        Clear();
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Should enter message", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Select Proper Timings", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAlarmList_Click_1(object sender, EventArgs e)
        {
            metroPanel1.Visible = false;
        }
    }

}




















