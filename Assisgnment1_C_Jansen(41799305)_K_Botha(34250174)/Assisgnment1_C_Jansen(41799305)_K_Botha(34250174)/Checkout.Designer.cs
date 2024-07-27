
namespace Assisgnment1_C_Jansen_41799305__K_Botha_34250174_
{
    partial class Checkout
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lstCheckout = new System.Windows.Forms.ListBox();
            this.lblRemoveItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(774, 93);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(183, 44);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(774, 293);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(183, 44);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Finish Order";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lstCheckout
            // 
            this.lstCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCheckout.FormattingEnabled = true;
            this.lstCheckout.ItemHeight = 26;
            this.lstCheckout.Items.AddRange(new object[] {
            " "});
            this.lstCheckout.Location = new System.Drawing.Point(42, 93);
            this.lstCheckout.Name = "lstCheckout";
            this.lstCheckout.Size = new System.Drawing.Size(669, 576);
            this.lstCheckout.TabIndex = 3;
            // 
            // lblRemoveItem
            // 
            this.lblRemoveItem.AutoSize = true;
            this.lblRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveItem.Location = new System.Drawing.Point(50, 25);
            this.lblRemoveItem.Name = "lblRemoveItem";
            this.lblRemoveItem.Size = new System.Drawing.Size(644, 29);
            this.lblRemoveItem.TabIndex = 133;
            this.lblRemoveItem.Text = "Please Select The Item You Would Like To Remove";
            // 
            // Checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1770, 965);
            this.Controls.Add(this.lblRemoveItem);
            this.Controls.Add(this.lstCheckout);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRemove);
            this.Name = "Checkout";
            this.Text = "Checkout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Checkout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblRemoveItem;
        public System.Windows.Forms.ListBox lstCheckout;
    }
}