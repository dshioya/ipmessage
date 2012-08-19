namespace ipmessage
{
    partial class SendForm
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
            this.accountList = new System.Windows.Forms.ListBox();
            this.messageText = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountList
            // 
            this.accountList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.accountList.FormattingEnabled = true;
            this.accountList.Location = new System.Drawing.Point(13, 13);
            this.accountList.Name = "accountList";
            this.accountList.Size = new System.Drawing.Size(328, 121);
            this.accountList.TabIndex = 0;
            // 
            // messageText
            // 
            this.messageText.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.messageText.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.messageText.Location = new System.Drawing.Point(13, 167);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageText.Size = new System.Drawing.Size(328, 129);
            this.messageText.TabIndex = 1;
            this.messageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageText_KeyDown);
            this.messageText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageText_KeyPress);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.messageLabel.Location = new System.Drawing.Point(13, 149);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(62, 15);
            this.messageLabel.TabIndex = 2;
            this.messageLabel.Text = "メッセージ";
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(353, 320);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.accountList);
            this.Name = "SendForm";
            this.Text = "送信";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox accountList;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.Label messageLabel;
    }
}

