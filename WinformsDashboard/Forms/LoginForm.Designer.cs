namespace WinformsDashboard.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnlLeft = new Panel();
            lblBrandDesc = new Label();
            lblBrandSub = new Label();
            lblBrand = new Label();
            pnlRight = new Panel();
            lblError = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblPasswordHint = new Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            lblUsernameHint = new Label();
            lblLoginSub = new Label();
            lblLoginTitle = new Label();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 16;
            guna2Elipse1.TargetControl = this;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(255, 255, 255);
            pnlLeft.Controls.Add(lblBrandDesc);
            pnlLeft.Controls.Add(lblBrandSub);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(340, 500);
            pnlLeft.TabIndex = 1;
            // 
            // lblBrandDesc
            // 
            lblBrandDesc.Font = new Font("Segoe UI", 10F);
            lblBrandDesc.ForeColor = Color.FromArgb(120, 144, 156);
            lblBrandDesc.Location = new Point(50, 240);
            lblBrandDesc.Name = "lblBrandDesc";
            lblBrandDesc.Size = new Size(250, 80);
            lblBrandDesc.TabIndex = 0;
            lblBrandDesc.Text = "Hệ thống phát hiện và cảnh báo rò rỉ điện năng thời gian thực.";
            // 
            // lblBrandSub
            // 
            lblBrandSub.AutoSize = true;
            lblBrandSub.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBrandSub.ForeColor = Color.FromArgb(33, 37, 41);
            lblBrandSub.Location = new Point(50, 195);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(180, 37);
            lblBrandSub.TabIndex = 1;
            lblBrandSub.Text = "AI GRID PRO";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI Emoji", 36F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(0, 176, 255);
            lblBrand.Location = new Point(50, 120);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(116, 80);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "⚡";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(240, 242, 245);
            pnlRight.Controls.Add(lblError);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(lblPasswordHint);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblUsernameHint);
            pnlRight.Controls.Add(lblLoginSub);
            pnlRight.Controls.Add(lblLoginTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(340, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(400, 500);
            pnlRight.TabIndex = 0;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(255, 23, 68);
            lblError.Location = new Point(50, 400);
            lblError.Name = "lblError";
            lblError.Size = new Size(280, 20);
            lblError.TabIndex = 0;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 8;
            btnLogin.CustomizableEdges = customizableEdges7;
            btnLogin.FillColor = Color.FromArgb(0, 145, 234);
            btnLogin.FillColor2 = Color.FromArgb(0, 176, 255);
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 345);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLogin.Size = new Size(280, 48);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "⚡  ĐĂNG NHẬP";
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(0, 176, 255);
            txtPassword.BorderRadius = 8;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.CustomizableEdges = customizableEdges9;
            txtPassword.DefaultText = "";
            txtPassword.FillColor = Color.FromArgb(255, 255, 255);
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(33, 37, 41);
            txtPassword.Location = new Point(50, 281);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtPassword.Size = new Size(280, 44);
            txtPassword.TabIndex = 1;
            // 
            // lblPasswordHint
            // 
            lblPasswordHint.AutoSize = true;
            lblPasswordHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPasswordHint.ForeColor = Color.FromArgb(0, 176, 255);
            lblPasswordHint.Location = new Point(50, 258);
            lblPasswordHint.Name = "lblPasswordHint";
            lblPasswordHint.Size = new Size(90, 20);
            lblPasswordHint.TabIndex = 3;
            lblPasswordHint.Text = "MẬT KHẨU";
            // 
            // txtUsername
            // 
            txtUsername.BorderColor = Color.FromArgb(0, 176, 255);
            txtUsername.BorderRadius = 8;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.CustomizableEdges = customizableEdges11;
            txtUsername.DefaultText = "";
            txtUsername.FillColor = Color.FromArgb(255, 255, 255);
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.FromArgb(33, 37, 41);
            txtUsername.Location = new Point(50, 198);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtUsername.Size = new Size(280, 44);
            txtUsername.TabIndex = 0;
            // 
            // lblUsernameHint
            // 
            lblUsernameHint.AutoSize = true;
            lblUsernameHint.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsernameHint.ForeColor = Color.FromArgb(0, 176, 255);
            lblUsernameHint.Location = new Point(50, 175);
            lblUsernameHint.Name = "lblUsernameHint";
            lblUsernameHint.Size = new Size(92, 20);
            lblUsernameHint.TabIndex = 4;
            lblUsernameHint.Text = "TÀI KHOẢN";
            // 
            // lblLoginSub
            // 
            lblLoginSub.AutoSize = true;
            lblLoginSub.Font = new Font("Segoe UI", 10F);
            lblLoginSub.ForeColor = Color.FromArgb(120, 144, 156);
            lblLoginSub.Location = new Point(50, 120);
            lblLoginSub.Name = "lblLoginSub";
            lblLoginSub.Size = new Size(293, 23);
            lblLoginSub.TabIndex = 5;
            lblLoginSub.Text = "Vui lòng nhập tài khoản và mật khẩu";
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblLoginTitle.Location = new Point(50, 74);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(200, 46);
            lblLoginTitle.TabIndex = 6;
            lblLoginTitle.Text = "Đăng Nhập";
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(740, 500);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Elipse      guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Panel         pnlLeft;
        private System.Windows.Forms.Label         lblBrand;
        private System.Windows.Forms.Label         lblBrandSub;
        private System.Windows.Forms.Label         lblBrandDesc;
        private System.Windows.Forms.Panel         pnlRight;
        private System.Windows.Forms.Label         lblLoginTitle;
        private System.Windows.Forms.Label         lblLoginSub;
        private System.Windows.Forms.Label         lblUsernameHint;
        private Guna.UI2.WinForms.Guna2TextBox     txtUsername;
        private System.Windows.Forms.Label         lblPasswordHint;
        private Guna.UI2.WinForms.Guna2TextBox     txtPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private System.Windows.Forms.Label         lblError;
    }
}

