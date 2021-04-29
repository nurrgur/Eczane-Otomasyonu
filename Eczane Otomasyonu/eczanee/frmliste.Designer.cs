namespace eczanee
{
    partial class frmliste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmliste));
            this.btnilc = new System.Windows.Forms.Button();
            this.btnsatis = new System.Windows.Forms.Button();
            this.btnpersonel = new System.Windows.Forms.Button();
            this.btnkayit = new System.Windows.Forms.Button();
            this.btnbolum = new System.Windows.Forms.Button();
            this.btncikis = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnilc
            // 
            this.btnilc.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnilc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnilc.Location = new System.Drawing.Point(91, 73);
            this.btnilc.Name = "btnilc";
            this.btnilc.Size = new System.Drawing.Size(196, 41);
            this.btnilc.TabIndex = 0;
            this.btnilc.Text = "İlaç Listesi";
            this.btnilc.UseVisualStyleBackColor = false;
            this.btnilc.Click += new System.EventHandler(this.btnilc_Click_1);
            // 
            // btnsatis
            // 
            this.btnsatis.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnsatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsatis.Location = new System.Drawing.Point(91, 288);
            this.btnsatis.Name = "btnsatis";
            this.btnsatis.Size = new System.Drawing.Size(196, 41);
            this.btnsatis.TabIndex = 1;
            this.btnsatis.Text = "Satış Listesi";
            this.btnsatis.UseVisualStyleBackColor = false;
            this.btnsatis.Click += new System.EventHandler(this.btnsatis_Click_1);
            // 
            // btnpersonel
            // 
            this.btnpersonel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnpersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnpersonel.Location = new System.Drawing.Point(91, 363);
            this.btnpersonel.Name = "btnpersonel";
            this.btnpersonel.Size = new System.Drawing.Size(196, 41);
            this.btnpersonel.TabIndex = 2;
            this.btnpersonel.Text = "Personel Listesi";
            this.btnpersonel.UseVisualStyleBackColor = false;
            this.btnpersonel.Click += new System.EventHandler(this.btnpersonel_Click);
            // 
            // btnkayit
            // 
            this.btnkayit.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnkayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkayit.Location = new System.Drawing.Point(91, 215);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(196, 41);
            this.btnkayit.TabIndex = 3;
            this.btnkayit.Text = "Kayıt Listesi";
            this.btnkayit.UseVisualStyleBackColor = false;
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click_1);
            // 
            // btnbolum
            // 
            this.btnbolum.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnbolum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbolum.Location = new System.Drawing.Point(91, 145);
            this.btnbolum.Name = "btnbolum";
            this.btnbolum.Size = new System.Drawing.Size(196, 43);
            this.btnbolum.TabIndex = 4;
            this.btnbolum.Text = "Bölüm Listesi";
            this.btnbolum.UseVisualStyleBackColor = false;
            this.btnbolum.Click += new System.EventHandler(this.btnbolum_Click);
            // 
            // btncikis
            // 
            this.btncikis.AutoSize = true;
            this.btncikis.Location = new System.Drawing.Point(311, 12);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(76, 24);
            this.btncikis.TabIndex = 5;
            this.btncikis.TabStop = true;
            this.btncikis.Text = "ÇIKIŞ";
            this.btncikis.UseVisualStyleBackColor = true;
            this.btncikis.CheckedChanged += new System.EventHandler(this.btncikis_CheckedChanged);
            // 
            // frmliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(399, 451);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.btnbolum);
            this.Controls.Add(this.btnkayit);
            this.Controls.Add(this.btnpersonel);
            this.Controls.Add(this.btnsatis);
            this.Controls.Add(this.btnilc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmliste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ECZANE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnilc;
        private System.Windows.Forms.Button btnsatis;
        private System.Windows.Forms.Button btnpersonel;
        private System.Windows.Forms.Button btnkayit;
        private System.Windows.Forms.Button btnbolum;
        private System.Windows.Forms.RadioButton btncikis;
    }
}