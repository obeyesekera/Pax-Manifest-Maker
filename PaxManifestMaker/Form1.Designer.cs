
namespace FlightManufestMaker
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtShipFlight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaxCount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.radShip = new System.Windows.Forms.RadioButton();
            this.radFlight = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalNat = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1296, 604);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(885, 30);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(158, 74);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(169, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // txtShipFlight
            // 
            this.txtShipFlight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipFlight.Location = new System.Drawing.Point(169, 63);
            this.txtShipFlight.Name = "txtShipFlight";
            this.txtShipFlight.Size = new System.Drawing.Size(150, 31);
            this.txtShipFlight.TabIndex = 4;
            this.txtShipFlight.TextChanged += new System.EventHandler(this.txtShipFlight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pax Count";
            // 
            // txtPaxCount
            // 
            this.txtPaxCount.Location = new System.Drawing.Point(378, 63);
            this.txtPaxCount.Name = "txtPaxCount";
            this.txtPaxCount.Size = new System.Drawing.Size(150, 31);
            this.txtPaxCount.TabIndex = 6;
            this.txtPaxCount.TextChanged += new System.EventHandler(this.txtPaxCount_TextChanged);
            this.txtPaxCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaxCount_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1076, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 74);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radShip
            // 
            this.radShip.AutoSize = true;
            this.radShip.Location = new System.Drawing.Point(22, 30);
            this.radShip.Name = "radShip";
            this.radShip.Size = new System.Drawing.Size(72, 29);
            this.radShip.TabIndex = 8;
            this.radShip.TabStop = true;
            this.radShip.Text = "Ship";
            this.radShip.UseVisualStyleBackColor = true;
            this.radShip.CheckedChanged += new System.EventHandler(this.radShip_CheckedChanged);
            // 
            // radFlight
            // 
            this.radFlight.AutoSize = true;
            this.radFlight.Location = new System.Drawing.Point(22, 65);
            this.radFlight.Name = "radFlight";
            this.radFlight.Size = new System.Drawing.Size(81, 29);
            this.radFlight.TabIndex = 9;
            this.radFlight.TabStop = true;
            this.radFlight.Text = "Flight";
            this.radFlight.UseVisualStyleBackColor = true;
            this.radFlight.CheckedChanged += new System.EventHandler(this.radFlight_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Local Nationality";
            // 
            // txtLocalNat
            // 
            this.txtLocalNat.Location = new System.Drawing.Point(586, 63);
            this.txtLocalNat.Name = "txtLocalNat";
            this.txtLocalNat.Size = new System.Drawing.Size(150, 31);
            this.txtLocalNat.TabIndex = 11;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(22, 146);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(54, 25);
            this.lblRows.TabIndex = 12;
            this.lblRows.Text = "Rows";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 799);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.txtLocalNat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radFlight);
            this.Controls.Add(this.radShip);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPaxCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtShipFlight);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Pax Manifest Maker v1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtShipFlight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaxCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radShip;
        private System.Windows.Forms.RadioButton radFlight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalNat;
        private System.Windows.Forms.Label lblRows;
    }
}

