using System;
using System.Data;
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
    }
}
