
namespace ye
{
    partial class Widget
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.img_pr = new System.Windows.Forms.PictureBox();
            this.button_add_to_cart = new System.Windows.Forms.Button();
            this.label_count = new System.Windows.Forms.Label();
            this.button_minus = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.tb_details = new System.Windows.Forms.TextBox();
            this.price_pr = new System.Windows.Forms.Label();
            this.name_pr = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_pr)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.img_pr);
            this.panel1.Controls.Add(this.button_add_to_cart);
            this.panel1.Controls.Add(this.label_count);
            this.panel1.Controls.Add(this.button_minus);
            this.panel1.Controls.Add(this.button_add);
            this.panel1.Controls.Add(this.tb_details);
            this.panel1.Controls.Add(this.price_pr);
            this.panel1.Controls.Add(this.name_pr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 247);
            this.panel1.TabIndex = 1;
            // 
            // img_pr
            // 
            this.img_pr.Location = new System.Drawing.Point(4, 4);
            this.img_pr.Name = "img_pr";
            this.img_pr.Size = new System.Drawing.Size(115, 126);
            this.img_pr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_pr.TabIndex = 6;
            this.img_pr.TabStop = false;
            // 
            // button_add_to_cart
            // 
            this.button_add_to_cart.FlatAppearance.BorderSize = 0;
            this.button_add_to_cart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_add_to_cart.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.button_add_to_cart.ForeColor = System.Drawing.Color.Orange;
            this.button_add_to_cart.Location = new System.Drawing.Point(52, 217);
            this.button_add_to_cart.Margin = new System.Windows.Forms.Padding(0);
            this.button_add_to_cart.Name = "button_add_to_cart";
            this.button_add_to_cart.Size = new System.Drawing.Size(145, 30);
            this.button_add_to_cart.TabIndex = 5;
            this.button_add_to_cart.Text = "Thêm Vào Giỏ Hàng";
            this.button_add_to_cart.UseVisualStyleBackColor = true;
            this.button_add_to_cart.Click += new System.EventHandler(this.btn_add_to_cart_Click);
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Enabled = false;
            this.label_count.Location = new System.Drawing.Point(48, 149);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(19, 21);
            this.label_count.TabIndex = 4;
            this.label_count.Text = "0";
            // 
            // button_minus
            // 
            this.button_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_minus.AutoSize = true;
            this.button_minus.FlatAppearance.BorderSize = 0;
            this.button_minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minus.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_minus.Location = new System.Drawing.Point(16, 145);
            this.button_minus.Margin = new System.Windows.Forms.Padding(0);
            this.button_minus.Name = "button_minus";
            this.button_minus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_minus.Size = new System.Drawing.Size(30, 30);
            this.button_minus.TabIndex = 3;
            this.button_minus.Text = "-";
            this.button_minus.UseVisualStyleBackColor = true;
            this.button_minus.Click += new System.EventHandler(this.button_minus_Click);
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.AutoSize = true;
            this.button_add.FlatAppearance.BorderSize = 0;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_add.Location = new System.Drawing.Point(70, 145);
            this.button_add.Margin = new System.Windows.Forms.Padding(0);
            this.button_add.Name = "button_add";
            this.button_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_add.Size = new System.Drawing.Size(30, 30);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "+";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // tb_details
            // 
            this.tb_details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_details.Enabled = false;
            this.tb_details.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_details.Location = new System.Drawing.Point(122, 65);
            this.tb_details.Multiline = true;
            this.tb_details.Name = "tb_details";
            this.tb_details.Size = new System.Drawing.Size(105, 139);
            this.tb_details.TabIndex = 2;
            // 
            // price_pr
            // 
            this.price_pr.AutoSize = true;
            this.price_pr.Enabled = false;
            this.price_pr.Location = new System.Drawing.Point(12, 183);
            this.price_pr.Name = "price_pr";
            this.price_pr.Size = new System.Drawing.Size(53, 21);
            this.price_pr.TabIndex = 0;
            this.price_pr.Text = "label1";
            // 
            // name_pr
            // 
            this.name_pr.AllowDrop = true;
            this.name_pr.Location = new System.Drawing.Point(125, 4);
            this.name_pr.Margin = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.name_pr.Name = "name_pr";
            this.name_pr.Size = new System.Drawing.Size(105, 53);
            this.name_pr.TabIndex = 0;
            this.name_pr.Text = "label1";
            // 
            // Widget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(8, 0, 5, 10);
            this.Name = "Widget";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(240, 257);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_pr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label price_pr;
        private System.Windows.Forms.Label name_pr;
        private System.Windows.Forms.TextBox tb_details;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Button button_add_to_cart;
        private System.Windows.Forms.PictureBox img_pr;
    }
}
