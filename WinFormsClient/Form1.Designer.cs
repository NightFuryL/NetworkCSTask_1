namespace WinFormsClient
{
    partial class Form1
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
            btnSendRequest = new Button();
            rtbResult = new RichTextBox();
            label1 = new Label();
            txtUri = new TextBox();
            SuspendLayout();
            // 
            // btnSendRequest
            // 
            btnSendRequest.BackColor = Color.FromArgb(13, 0, 72);
            btnSendRequest.ForeColor = Color.Yellow;
            btnSendRequest.Location = new Point(14, 45);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.Size = new Size(873, 29);
            btnSendRequest.TabIndex = 0;
            btnSendRequest.Text = "Send Request";
            btnSendRequest.UseVisualStyleBackColor = false;
            btnSendRequest.Click += btnSendRequest_Click;
            // 
            // rtbResult
            // 
            rtbResult.BackColor = Color.FromArgb(13, 0, 72);
            rtbResult.ForeColor = Color.Yellow;
            rtbResult.Location = new Point(14, 80);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(872, 358);
            rtbResult.TabIndex = 1;
            rtbResult.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(13, 0, 72);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(14, 19);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 2;
            label1.Text = "URI:";
            // 
            // txtUri
            // 
            txtUri.BackColor = Color.FromArgb(13, 0, 72);
            txtUri.ForeColor = Color.Yellow;
            txtUri.Location = new Point(76, 12);
            txtUri.Name = "txtUri";
            txtUri.Size = new Size(810, 27);
            txtUri.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 0, 72);
            ClientSize = new Size(900, 450);
            Controls.Add(txtUri);
            Controls.Add(label1);
            Controls.Add(rtbResult);
            Controls.Add(btnSendRequest);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Yellow;
            Name = "Form1";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSendRequest;
        private RichTextBox rtbResult;
        private Label label1;
        private TextBox txtUri;
    }
}
