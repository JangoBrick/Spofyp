namespace Spofyp.Gui
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.DestDir_Label = new System.Windows.Forms.Label();
            this.DestDir_Input = new System.Windows.Forms.TextBox();
            this.DestDir_Button_Open = new System.Windows.Forms.Button();
            this.DestDir_Button_Choose = new System.Windows.Forms.Button();
            this.CurrentlyPlaying_Label = new System.Windows.Forms.Label();
            this.CurrentlyPlaying_Value = new System.Windows.Forms.Label();
            this.Record_Button_Once = new System.Windows.Forms.Button();
            this.Record_Button_All = new System.Windows.Forms.Button();
            this.Record_Button_Stop = new System.Windows.Forms.Button();
            this.TracksGrid = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TracksSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TracksGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TracksSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DestDir_Label
            // 
            this.DestDir_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestDir_Label.AutoSize = true;
            this.DestDir_Label.Location = new System.Drawing.Point(12, 18);
            this.DestDir_Label.Name = "DestDir_Label";
            this.DestDir_Label.Size = new System.Drawing.Size(106, 13);
            this.DestDir_Label.TabIndex = 0;
            this.DestDir_Label.Text = "Destination directory:";
            // 
            // DestDir_Input
            // 
            this.DestDir_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestDir_Input.Location = new System.Drawing.Point(124, 15);
            this.DestDir_Input.Name = "DestDir_Input";
            this.DestDir_Input.ReadOnly = true;
            this.DestDir_Input.Size = new System.Drawing.Size(474, 20);
            this.DestDir_Input.TabIndex = 0;
            this.DestDir_Input.TabStop = false;
            // 
            // DestDir_Button_Open
            // 
            this.DestDir_Button_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestDir_Button_Open.Location = new System.Drawing.Point(675, 13);
            this.DestDir_Button_Open.Name = "DestDir_Button_Open";
            this.DestDir_Button_Open.Size = new System.Drawing.Size(65, 23);
            this.DestDir_Button_Open.TabIndex = 6;
            this.DestDir_Button_Open.Text = "Open";
            this.DestDir_Button_Open.UseVisualStyleBackColor = true;
            this.DestDir_Button_Open.Click += new System.EventHandler(this.DestDir_Button_Open_Click);
            // 
            // DestDir_Button_Choose
            // 
            this.DestDir_Button_Choose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestDir_Button_Choose.Location = new System.Drawing.Point(604, 13);
            this.DestDir_Button_Choose.Name = "DestDir_Button_Choose";
            this.DestDir_Button_Choose.Size = new System.Drawing.Size(65, 23);
            this.DestDir_Button_Choose.TabIndex = 5;
            this.DestDir_Button_Choose.Text = "...";
            this.DestDir_Button_Choose.UseVisualStyleBackColor = true;
            this.DestDir_Button_Choose.Click += new System.EventHandler(this.DestDir_Button_Choose_Click);
            // 
            // CurrentlyPlaying_Label
            // 
            this.CurrentlyPlaying_Label.AutoSize = true;
            this.CurrentlyPlaying_Label.Location = new System.Drawing.Point(12, 55);
            this.CurrentlyPlaying_Label.Name = "CurrentlyPlaying_Label";
            this.CurrentlyPlaying_Label.Size = new System.Drawing.Size(87, 13);
            this.CurrentlyPlaying_Label.TabIndex = 0;
            this.CurrentlyPlaying_Label.Text = "Currently playing:";
            // 
            // CurrentlyPlaying_Value
            // 
            this.CurrentlyPlaying_Value.AutoSize = true;
            this.CurrentlyPlaying_Value.Location = new System.Drawing.Point(121, 57);
            this.CurrentlyPlaying_Value.Name = "CurrentlyPlaying_Value";
            this.CurrentlyPlaying_Value.Size = new System.Drawing.Size(19, 13);
            this.CurrentlyPlaying_Value.TabIndex = 0;
            this.CurrentlyPlaying_Value.Text = "    ";
            // 
            // Record_Button_Once
            // 
            this.Record_Button_Once.Location = new System.Drawing.Point(12, 82);
            this.Record_Button_Once.Name = "Record_Button_Once";
            this.Record_Button_Once.Size = new System.Drawing.Size(106, 23);
            this.Record_Button_Once.TabIndex = 1;
            this.Record_Button_Once.Text = "Record once";
            this.Record_Button_Once.UseVisualStyleBackColor = true;
            this.Record_Button_Once.Click += new System.EventHandler(this.Record_Button_Once_Click);
            // 
            // Record_Button_All
            // 
            this.Record_Button_All.Location = new System.Drawing.Point(124, 82);
            this.Record_Button_All.Name = "Record_Button_All";
            this.Record_Button_All.Size = new System.Drawing.Size(106, 23);
            this.Record_Button_All.TabIndex = 2;
            this.Record_Button_All.Text = "Record all";
            this.Record_Button_All.UseVisualStyleBackColor = true;
            this.Record_Button_All.Click += new System.EventHandler(this.Record_Button_All_Click);
            // 
            // Record_Button_Stop
            // 
            this.Record_Button_Stop.Location = new System.Drawing.Point(256, 82);
            this.Record_Button_Stop.Name = "Record_Button_Stop";
            this.Record_Button_Stop.Size = new System.Drawing.Size(106, 23);
            this.Record_Button_Stop.TabIndex = 3;
            this.Record_Button_Stop.Text = "Stop recording";
            this.Record_Button_Stop.UseVisualStyleBackColor = true;
            this.Record_Button_Stop.Click += new System.EventHandler(this.Record_Button_Stop_Click);
            // 
            // TracksGrid
            // 
            this.TracksGrid.AllowUserToAddRows = false;
            this.TracksGrid.AllowUserToDeleteRows = false;
            this.TracksGrid.AllowUserToResizeColumns = false;
            this.TracksGrid.AllowUserToResizeRows = false;
            this.TracksGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TracksGrid.AutoGenerateColumns = false;
            this.TracksGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TracksGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TracksGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.Artist,
            this.Title,
            this.Length,
            this.StartedAt});
            this.TracksGrid.DataSource = this.TracksSource;
            this.TracksGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TracksGrid.Location = new System.Drawing.Point(12, 112);
            this.TracksGrid.MultiSelect = false;
            this.TracksGrid.Name = "TracksGrid";
            this.TracksGrid.ReadOnly = true;
            this.TracksGrid.RowHeadersVisible = false;
            this.TracksGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TracksGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TracksGrid.Size = new System.Drawing.Size(728, 269);
            this.TracksGrid.TabIndex = 4;
            // 
            // Status
            // 
            this.Status.FillWeight = 10F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Artist
            // 
            this.Artist.FillWeight = 30F;
            this.Artist.HeaderText = "Artist";
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            this.Artist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Title
            // 
            this.Title.FillWeight = 45F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Length
            // 
            this.Length.FillWeight = 15F;
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StartedAt
            // 
            this.StartedAt.FillWeight = 1F;
            this.StartedAt.HeaderText = "Started At";
            this.StartedAt.Name = "StartedAt";
            this.StartedAt.ReadOnly = true;
            this.StartedAt.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 393);
            this.Controls.Add(this.TracksGrid);
            this.Controls.Add(this.Record_Button_Stop);
            this.Controls.Add(this.Record_Button_All);
            this.Controls.Add(this.Record_Button_Once);
            this.Controls.Add(this.CurrentlyPlaying_Value);
            this.Controls.Add(this.CurrentlyPlaying_Label);
            this.Controls.Add(this.DestDir_Button_Choose);
            this.Controls.Add(this.DestDir_Button_Open);
            this.Controls.Add(this.DestDir_Input);
            this.Controls.Add(this.DestDir_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spofyp";
            ((System.ComponentModel.ISupportInitialize)(this.TracksGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TracksSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DestDir_Label;
        private System.Windows.Forms.TextBox DestDir_Input;
        private System.Windows.Forms.Button DestDir_Button_Open;
        private System.Windows.Forms.Button DestDir_Button_Choose;
        private System.Windows.Forms.Label CurrentlyPlaying_Label;
        private System.Windows.Forms.Label CurrentlyPlaying_Value;
        private System.Windows.Forms.Button Record_Button_Once;
        private System.Windows.Forms.Button Record_Button_All;
        private System.Windows.Forms.Button Record_Button_Stop;
        private System.Windows.Forms.DataGridView TracksGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartedAt;
        private System.Windows.Forms.BindingSource TracksSource;
    }
}