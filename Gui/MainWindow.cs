using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Spofyp.Gui
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Load += MainWindow_Load;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // set dest dir value
            DestDir_Input.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Spofyp");

            // init tracks grid
            var tracksData = new DataTable();
            foreach (DataGridViewColumn col in TracksGrid.Columns)
            {
                tracksData.Columns.Add(col.Name);
                col.DataPropertyName = col.Name;
            }
            TracksSource.DataSource = tracksData;
            TracksGrid.Sort(StartedAt, System.ComponentModel.ListSortDirection.Descending);
        }

        private void DestDir_Button_Choose_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                InitialDirectory = DestDir_Input.Text,
                IsFolderPicker = true,
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DestDir_Input.Text = dialog.FileName;
            }
        }

        private void DestDir_Button_Open_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DestDir_Input.Text);
        }
    }
}
