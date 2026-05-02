namespace WinFormsTask
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
            txtResult = new TextBox();
            txtHost = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSendRequest
            // 
            btnSendRequest.Location = new Point(10, 9);
            btnSendRequest.Margin = new Padding(3, 2, 3, 2);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.Size = new Size(679, 22);
            btnSendRequest.TabIndex = 0;
            btnSendRequest.Text = "Send Request";
            btnSendRequest.UseVisualStyleBackColor = true;
            btnSendRequest.Click += btnSendRequest_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(9, 64);
            txtResult.Margin = new Padding(3, 2, 3, 2);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(680, 332);
            txtResult.TabIndex = 1;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(56, 36);
            txtHost.Name = "txtHost";
            txtHost.PlaceholderText = "Адреса сайта";
            txtHost.Size = new Size(632, 23);
            txtHost.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Host";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 407);
            Controls.Add(label1);
            Controls.Add(txtHost);
            Controls.Add(txtResult);
            Controls.Add(btnSendRequest);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSendRequest;
        private TextBox txtResult;
        private TextBox txtHost;
        private Label label1;
    }
}
