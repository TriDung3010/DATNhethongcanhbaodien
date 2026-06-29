namespace WinformsDashboard.Forms
{
    partial class AIPredictionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblScoreTitle = new System.Windows.Forms.Label();
            this.lblRiskScore = new System.Windows.Forms.Label();
            this.lblLevelTitle = new System.Windows.Forms.Label();
            this.lblRiskLevel = new System.Windows.Forms.Label();
            this.lblPredictionTitle = new System.Windows.Forms.Label();
            this.txtPrediction = new System.Windows.Forms.TextBox();
            this.lblRecommendationTitle = new System.Windows.Forms.Label();
            this.txtRecommendation = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dự Đoán Rò Rỉ Điện AI";
            // 
            // lblScoreTitle
            // 
            this.lblScoreTitle.AutoSize = true;
            this.lblScoreTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScoreTitle.Location = new System.Drawing.Point(30, 80);
            this.lblScoreTitle.Name = "lblScoreTitle";
            this.lblScoreTitle.Size = new System.Drawing.Size(107, 21);
            this.lblScoreTitle.TabIndex = 1;
            this.lblScoreTitle.Text = "Điểm Rủi Ro AI:";
            // 
            // lblRiskScore
            // 
            this.lblRiskScore.AutoSize = true;
            this.lblRiskScore.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRiskScore.Location = new System.Drawing.Point(30, 110);
            this.lblRiskScore.Name = "lblRiskScore";
            this.lblRiskScore.Size = new System.Drawing.Size(73, 45);
            this.lblRiskScore.TabIndex = 2;
            this.lblRiskScore.Text = "0%";
            // 
            // lblLevelTitle
            // 
            this.lblLevelTitle.AutoSize = true;
            this.lblLevelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLevelTitle.Location = new System.Drawing.Point(200, 80);
            this.lblLevelTitle.Name = "lblLevelTitle";
            this.lblLevelTitle.Size = new System.Drawing.Size(81, 21);
            this.lblLevelTitle.TabIndex = 3;
            this.lblLevelTitle.Text = "Mức Độ:";
            // 
            // lblRiskLevel
            // 
            this.lblRiskLevel.AutoSize = true;
            this.lblRiskLevel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRiskLevel.Location = new System.Drawing.Point(200, 110);
            this.lblRiskLevel.Name = "lblRiskLevel";
            this.lblRiskLevel.Size = new System.Drawing.Size(161, 45);
            this.lblRiskLevel.TabIndex = 4;
            this.lblRiskLevel.Text = "CHƯA RÕ";
            // 
            // lblPredictionTitle
            // 
            this.lblPredictionTitle.AutoSize = true;
            this.lblPredictionTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPredictionTitle.Location = new System.Drawing.Point(30, 180);
            this.lblPredictionTitle.Name = "lblPredictionTitle";
            this.lblPredictionTitle.Size = new System.Drawing.Size(94, 21);
            this.lblPredictionTitle.TabIndex = 5;
            this.lblPredictionTitle.Text = "Dự Đoán:";
            // 
            // txtPrediction
            // 
            this.txtPrediction.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrediction.Location = new System.Drawing.Point(34, 210);
            this.txtPrediction.Multiline = true;
            this.txtPrediction.Name = "txtPrediction";
            this.txtPrediction.ReadOnly = true;
            this.txtPrediction.Size = new System.Drawing.Size(420, 60);
            this.txtPrediction.TabIndex = 6;
            // 
            // lblRecommendationTitle
            // 
            this.lblRecommendationTitle.AutoSize = true;
            this.lblRecommendationTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRecommendationTitle.Location = new System.Drawing.Point(30, 290);
            this.lblRecommendationTitle.Name = "lblRecommendationTitle";
            this.lblRecommendationTitle.Size = new System.Drawing.Size(150, 21);
            this.lblRecommendationTitle.TabIndex = 7;
            this.lblRecommendationTitle.Text = "Đề Xuất Hành Động:";
            // 
            // txtRecommendation
            // 
            this.txtRecommendation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRecommendation.Location = new System.Drawing.Point(34, 320);
            this.txtRecommendation.Multiline = true;
            this.txtRecommendation.Name = "txtRecommendation";
            this.txtRecommendation.ReadOnly = true;
            this.txtRecommendation.Size = new System.Drawing.Size(420, 60);
            this.txtRecommendation.TabIndex = 8;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnalyze.ForeColor = System.Drawing.Color.White;
            this.btnAnalyze.Location = new System.Drawing.Point(34, 400);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(420, 45);
            this.btnAnalyze.TabIndex = 9;
            this.btnAnalyze.Text = "Chạy Phân Tích AI";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // AIPredictionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 481);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtRecommendation);
            this.Controls.Add(this.lblRecommendationTitle);
            this.Controls.Add(this.txtPrediction);
            this.Controls.Add(this.lblPredictionTitle);
            this.Controls.Add(this.lblRiskLevel);
            this.Controls.Add(this.lblLevelTitle);
            this.Controls.Add(this.lblRiskScore);
            this.Controls.Add(this.lblScoreTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AIPredictionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Module Dự Đoán AI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblScoreTitle;
        private System.Windows.Forms.Label lblRiskScore;
        private System.Windows.Forms.Label lblLevelTitle;
        private System.Windows.Forms.Label lblRiskLevel;
        private System.Windows.Forms.Label lblPredictionTitle;
        private System.Windows.Forms.TextBox txtPrediction;
        private System.Windows.Forms.Label lblRecommendationTitle;
        private System.Windows.Forms.TextBox txtRecommendation;
        private System.Windows.Forms.Button btnAnalyze;
    }
}
