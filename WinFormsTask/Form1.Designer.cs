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
            SuspendLayout();
            // 
            // btnSendRequest
            // 
            btnSendRequest.Location = new Point(12, 12);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.Size = new Size(776, 29);
            btnSendRequest.TabIndex = 0;
            btnSendRequest.Text = "Send Request";
            btnSendRequest.UseVisualStyleBackColor = true;
            btnSendRequest.Click += btnSendRequest_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(12, 47);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(776, 391);
            txtResult.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtResult);
            Controls.Add(btnSendRequest);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSendRequest;
        private TextBox txtResult;
    }
}
