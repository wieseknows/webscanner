namespace WebScanner {
    partial class WebScanner {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.scanned_label = new System.Windows.Forms.Label();
            this.detected_label = new System.Windows.Forms.Label();
            this.current_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.AutoSize = true;
            this.start_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.Location = new System.Drawing.Point(48, 126);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(39, 23);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.AutoSize = true;
            this.stop_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stop_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button.Location = new System.Drawing.Point(94, 126);
            this.stop_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(39, 23);
            this.stop_button.TabIndex = 1;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // scanned_label
            // 
            this.scanned_label.AutoSize = true;
            this.scanned_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.scanned_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scanned_label.Location = new System.Drawing.Point(36, 23);
            this.scanned_label.Name = "scanned_label";
            this.scanned_label.Size = new System.Drawing.Size(70, 18);
            this.scanned_label.TabIndex = 2;
            this.scanned_label.Text = "Scanned:";
            // 
            // detected_label
            // 
            this.detected_label.AutoSize = true;
            this.detected_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.detected_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.detected_label.Location = new System.Drawing.Point(35, 50);
            this.detected_label.Name = "detected_label";
            this.detected_label.Size = new System.Drawing.Size(71, 18);
            this.detected_label.TabIndex = 2;
            this.detected_label.Text = "Detected:";
            // 
            // current_label
            // 
            this.current_label.AutoSize = true;
            this.current_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.current_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.current_label.Location = new System.Drawing.Point(45, 78);
            this.current_label.Name = "current_label";
            this.current_label.Size = new System.Drawing.Size(61, 18);
            this.current_label.TabIndex = 2;
            this.current_label.Text = "Current:";
            // 
            // WebScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 183);
            this.Controls.Add(this.current_label);
            this.Controls.Add(this.detected_label);
            this.Controls.Add(this.scanned_label);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Name = "WebScanner";
            this.Text = "WebScanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Label scanned_label;
        private System.Windows.Forms.Label detected_label;
        private System.Windows.Forms.Label current_label;
    }
}

