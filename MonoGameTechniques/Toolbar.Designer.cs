namespace MonoGameTechniques
{
    partial class Toolbar
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
            rbtn_SFM = new System.Windows.Forms.RadioButton();
            cb_Diffuse = new System.Windows.Forms.CheckBox();
            cb_Specular = new System.Windows.Forms.CheckBox();
            cb_Normal = new System.Windows.Forms.CheckBox();
            cb_Wireframe = new System.Windows.Forms.CheckBox();
            rbtn_SS = new System.Windows.Forms.RadioButton();
            btn_AddSF = new System.Windows.Forms.Button();
            rbtn_PP = new System.Windows.Forms.RadioButton();
            panel1 = new System.Windows.Forms.Panel();
            tb_F = new System.Windows.Forms.TrackBar();
            tb_A = new System.Windows.Forms.TrackBar();
            lb_F = new System.Windows.Forms.Label();
            lb_A = new System.Windows.Forms.Label();
            lb_Frequency = new System.Windows.Forms.Label();
            lb_Amplitude = new System.Windows.Forms.Label();
            cb_Tint = new System.Windows.Forms.CheckBox();
            rbtn_UnderWater = new System.Windows.Forms.RadioButton();
            rbtn_BlankWhite = new System.Windows.Forms.RadioButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_F).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_A).BeginInit();
            SuspendLayout();
            // 
            // rbtn_SFM
            // 
            rbtn_SFM.AutoSize = true;
            rbtn_SFM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rbtn_SFM.Location = new System.Drawing.Point(28, 21);
            rbtn_SFM.Name = "rbtn_SFM";
            rbtn_SFM.Size = new System.Drawing.Size(164, 25);
            rbtn_SFM.TabIndex = 0;
            rbtn_SFM.TabStop = true;
            rbtn_SFM.Text = "Space Fighter Maps";
            rbtn_SFM.UseVisualStyleBackColor = true;
            rbtn_SFM.CheckedChanged += rbtn_SFM_CheckedChanged;
            // 
            // cb_Diffuse
            // 
            cb_Diffuse.AutoSize = true;
            cb_Diffuse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cb_Diffuse.Location = new System.Drawing.Point(45, 52);
            cb_Diffuse.Name = "cb_Diffuse";
            cb_Diffuse.Size = new System.Drawing.Size(78, 25);
            cb_Diffuse.TabIndex = 1;
            cb_Diffuse.Text = "Diffuse";
            cb_Diffuse.UseVisualStyleBackColor = true;
            cb_Diffuse.CheckedChanged += cb_Diffuse_CheckedChanged;
            // 
            // cb_Specular
            // 
            cb_Specular.AutoSize = true;
            cb_Specular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cb_Specular.Location = new System.Drawing.Point(45, 83);
            cb_Specular.Name = "cb_Specular";
            cb_Specular.Size = new System.Drawing.Size(89, 25);
            cb_Specular.TabIndex = 2;
            cb_Specular.Text = "Specular";
            cb_Specular.UseVisualStyleBackColor = true;
            cb_Specular.CheckedChanged += cb_Specular_CheckedChanged;
            // 
            // cb_Normal
            // 
            cb_Normal.AutoSize = true;
            cb_Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cb_Normal.Location = new System.Drawing.Point(45, 114);
            cb_Normal.Name = "cb_Normal";
            cb_Normal.Size = new System.Drawing.Size(82, 25);
            cb_Normal.TabIndex = 3;
            cb_Normal.Text = "Normal";
            cb_Normal.UseVisualStyleBackColor = true;
            cb_Normal.CheckedChanged += cb_Normal_CheckedChanged;
            // 
            // cb_Wireframe
            // 
            cb_Wireframe.AutoSize = true;
            cb_Wireframe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cb_Wireframe.Location = new System.Drawing.Point(45, 145);
            cb_Wireframe.Name = "cb_Wireframe";
            cb_Wireframe.Size = new System.Drawing.Size(103, 25);
            cb_Wireframe.TabIndex = 4;
            cb_Wireframe.Text = "Wireframe";
            cb_Wireframe.UseVisualStyleBackColor = true;
            cb_Wireframe.CheckedChanged += cb_Wireframe_CheckedChanged;
            // 
            // rbtn_SS
            // 
            rbtn_SS.AutoSize = true;
            rbtn_SS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rbtn_SS.Location = new System.Drawing.Point(28, 176);
            rbtn_SS.Name = "rbtn_SS";
            rbtn_SS.Size = new System.Drawing.Size(114, 25);
            rbtn_SS.TabIndex = 5;
            rbtn_SS.TabStop = true;
            rbtn_SS.Text = "Space Scene";
            rbtn_SS.UseVisualStyleBackColor = true;
            rbtn_SS.CheckedChanged += rbtn_SS_CheckedChanged;
            // 
            // btn_AddSF
            // 
            btn_AddSF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn_AddSF.Location = new System.Drawing.Point(45, 207);
            btn_AddSF.Name = "btn_AddSF";
            btn_AddSF.Size = new System.Drawing.Size(176, 33);
            btn_AddSF.TabIndex = 6;
            btn_AddSF.Text = "Add Space Fighter";
            btn_AddSF.UseVisualStyleBackColor = true;
            btn_AddSF.Click += btn_AddSF_Click;
            // 
            // rbtn_PP
            // 
            rbtn_PP.AutoSize = true;
            rbtn_PP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rbtn_PP.Location = new System.Drawing.Point(28, 255);
            rbtn_PP.Name = "rbtn_PP";
            rbtn_PP.Size = new System.Drawing.Size(136, 25);
            rbtn_PP.TabIndex = 7;
            rbtn_PP.TabStop = true;
            rbtn_PP.Text = "Post Processing";
            rbtn_PP.UseVisualStyleBackColor = true;
            rbtn_PP.CheckedChanged += rbtn_PP_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(tb_F);
            panel1.Controls.Add(tb_A);
            panel1.Controls.Add(lb_F);
            panel1.Controls.Add(lb_A);
            panel1.Controls.Add(lb_Frequency);
            panel1.Controls.Add(lb_Amplitude);
            panel1.Controls.Add(cb_Tint);
            panel1.Controls.Add(rbtn_UnderWater);
            panel1.Controls.Add(rbtn_BlankWhite);
            panel1.Location = new System.Drawing.Point(45, 286);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(351, 213);
            panel1.TabIndex = 8;
            // 
            // tb_F
            // 
            tb_F.Location = new System.Drawing.Point(118, 153);
            tb_F.Maximum = 50;
            tb_F.Name = "tb_F";
            tb_F.Size = new System.Drawing.Size(189, 45);
            tb_F.TabIndex = 16;
            tb_F.Scroll += tb_F_Scroll;
            // 
            // tb_A
            // 
            tb_A.Location = new System.Drawing.Point(118, 102);
            tb_A.Maximum = 100;
            tb_A.Name = "tb_A";
            tb_A.Size = new System.Drawing.Size(189, 45);
            tb_A.SmallChange = 5;
            tb_A.TabIndex = 15;
            tb_A.Scroll += tb_A_Scroll;
            // 
            // lb_F
            // 
            lb_F.AutoSize = true;
            lb_F.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_F.Location = new System.Drawing.Point(313, 152);
            lb_F.Name = "lb_F";
            lb_F.Size = new System.Drawing.Size(18, 21);
            lb_F.TabIndex = 14;
            lb_F.Text = "F";
            // 
            // lb_A
            // 
            lb_A.AutoSize = true;
            lb_A.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_A.Location = new System.Drawing.Point(313, 102);
            lb_A.Name = "lb_A";
            lb_A.Size = new System.Drawing.Size(20, 21);
            lb_A.TabIndex = 13;
            lb_A.Text = "A";
            // 
            // lb_Frequency
            // 
            lb_Frequency.AutoSize = true;
            lb_Frequency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Frequency.Location = new System.Drawing.Point(30, 152);
            lb_Frequency.Name = "lb_Frequency";
            lb_Frequency.Size = new System.Drawing.Size(82, 21);
            lb_Frequency.TabIndex = 12;
            lb_Frequency.Text = "Frequency";
            // 
            // lb_Amplitude
            // 
            lb_Amplitude.AutoSize = true;
            lb_Amplitude.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Amplitude.Location = new System.Drawing.Point(30, 102);
            lb_Amplitude.Name = "lb_Amplitude";
            lb_Amplitude.Size = new System.Drawing.Size(82, 21);
            lb_Amplitude.TabIndex = 11;
            lb_Amplitude.Text = "Amplitude";
            // 
            // cb_Tint
            // 
            cb_Tint.AutoSize = true;
            cb_Tint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cb_Tint.Location = new System.Drawing.Point(30, 74);
            cb_Tint.Name = "cb_Tint";
            cb_Tint.Size = new System.Drawing.Size(89, 25);
            cb_Tint.TabIndex = 9;
            cb_Tint.Text = "Tint Blue";
            cb_Tint.UseVisualStyleBackColor = true;
            cb_Tint.CheckedChanged += cb_Tint_CheckedChanged;
            // 
            // rbtn_UnderWater
            // 
            rbtn_UnderWater.AutoSize = true;
            rbtn_UnderWater.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rbtn_UnderWater.Location = new System.Drawing.Point(11, 43);
            rbtn_UnderWater.Name = "rbtn_UnderWater";
            rbtn_UnderWater.Size = new System.Drawing.Size(161, 25);
            rbtn_UnderWater.TabIndex = 10;
            rbtn_UnderWater.TabStop = true;
            rbtn_UnderWater.Text = "Under Water Scene";
            rbtn_UnderWater.UseVisualStyleBackColor = true;
            rbtn_UnderWater.CheckedChanged += rbtn_UnderWater_CheckedChanged;
            // 
            // rbtn_BlankWhite
            // 
            rbtn_BlankWhite.AutoSize = true;
            rbtn_BlankWhite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rbtn_BlankWhite.Location = new System.Drawing.Point(11, 12);
            rbtn_BlankWhite.Name = "rbtn_BlankWhite";
            rbtn_BlankWhite.Size = new System.Drawing.Size(141, 25);
            rbtn_BlankWhite.TabIndex = 9;
            rbtn_BlankWhite.TabStop = true;
            rbtn_BlankWhite.Text = "Blank and White";
            rbtn_BlankWhite.UseVisualStyleBackColor = true;
            rbtn_BlankWhite.CheckedChanged += rbtn_BlankWhite_CheckedChanged;
            // 
            // Toolbar
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(446, 540);
            Controls.Add(panel1);
            Controls.Add(rbtn_PP);
            Controls.Add(btn_AddSF);
            Controls.Add(rbtn_SS);
            Controls.Add(cb_Wireframe);
            Controls.Add(cb_Normal);
            Controls.Add(cb_Specular);
            Controls.Add(cb_Diffuse);
            Controls.Add(rbtn_SFM);
            Name = "Toolbar";
            Text = "Toolbar";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_F).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_A).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_SFM;
        private System.Windows.Forms.CheckBox cb_Diffuse;
        private System.Windows.Forms.CheckBox cb_Specular;
        private System.Windows.Forms.CheckBox cb_Normal;
        private System.Windows.Forms.CheckBox cb_Wireframe;
        private System.Windows.Forms.RadioButton rbtn_SS;
        private System.Windows.Forms.Button btn_AddSF;
        private System.Windows.Forms.RadioButton rbtn_PP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cb_Tint;
        private System.Windows.Forms.RadioButton rbtn_UnderWater;
        private System.Windows.Forms.RadioButton rbtn_BlankWhite;
        private System.Windows.Forms.TrackBar tb_F;
        private System.Windows.Forms.TrackBar tb_A;
        private System.Windows.Forms.Label lb_F;
        private System.Windows.Forms.Label lb_A;
        private System.Windows.Forms.Label lb_Frequency;
        private System.Windows.Forms.Label lb_Amplitude;
    }
}