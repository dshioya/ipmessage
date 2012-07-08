namespace ipmessage
{
    partial class ReceiveForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.infoLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.ReplyButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 12);
            this.infoLabel.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 33);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 12);
            this.messageLabel.TabIndex = 1;
            // 
            // ReplyButton
            // 
            this.ReplyButton.Location = new System.Drawing.Point(222, 155);
            this.ReplyButton.Name = "ReplyButton";
            this.ReplyButton.Size = new System.Drawing.Size(75, 23);
            this.ReplyButton.TabIndex = 2;
            this.ReplyButton.Text = "返信";
            this.ReplyButton.UseVisualStyleBackColor = true;
            this.ReplyButton.Click += new System.EventHandler(this.ReplyButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(13, 49);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(284, 100);
            this.messageBox.TabIndex = 3;
            // 
            // ReceiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(309, 190);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.ReplyButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.infoLabel);
            this.Name = "ReceiveForm";
            this.Text = "受信フォーム";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button ReplyButton;
        private System.Windows.Forms.TextBox messageBox;

    }
}