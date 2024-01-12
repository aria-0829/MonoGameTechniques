using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoGameTechniques
{
    public partial class Toolbar : Form
    {
        // Space Fighter Maps
        public bool SFM { get; set; }
        public bool Diffuse { get; set; }
        public bool Specular { get; set; }
        public bool Normal { get; set; }
        public bool Wireframe { get; set; }

        // Space Scene
        public bool SS { get; set; }
        public bool AddSF { get; set; }

        // Post Processing
        public bool PP { get; set; }
        public bool BlankWhite { get; set; }

        // Under Water Scene
        public bool UnderWater { get; set; }
        public bool Tint { get; set; }
        public float Amplitude { get; set; }
        public float Frequency { get; set; }

        public Toolbar()
        {
            InitializeComponent();

            rbtn_SFM.Checked = true;
            rbtn_BlankWhite.Checked = true;
        }

        private void rbtn_SFM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_SFM.Checked)
            {
                SFM = true;
            }
            else
            {
                SFM = false;
            }
        }

        private void cb_Diffuse_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Diffuse.Checked)
            {
                Diffuse = true;
            }
            else
            {
                Diffuse = false;
            }
        }

        private void cb_Specular_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Specular.Checked)
            {
                Specular = true;
            }
            else
            {
                Specular = false;
            }
        }

        private void cb_Normal_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Normal.Checked)
            {
                Normal = true;
            }
            else
            {
                Normal = false;
            }
        }

        private void cb_Wireframe_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Wireframe.Checked)
            {
                Wireframe = true;
            }
            else
            {
                Wireframe = false;
            }
        }

        private void rbtn_SS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_SS.Checked)
            {
                SS = true;
            }
            else
            {
                SS = false;
            }
        }

        private void btn_AddSF_Click(object sender, EventArgs e)
        {
            AddSF = true;
        }

        private void rbtn_PP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_PP.Checked)
            {
                PP = true;
            }
            else
            {
                PP = false;
            }
        }

        private void rbtn_BlankWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_BlankWhite.Checked)
            {
                BlankWhite = true;
            }
            else
            {
                BlankWhite = false;
            }
        }

        private void rbtn_UnderWater_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_UnderWater.Checked)
            {
                UnderWater = true;
            }
            else
            {
                UnderWater = false;
            }
        }

        private void cb_Tint_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Tint.Checked)
            {
                Tint = true;
            }
            else
            {
                Tint = false;
            }
        }

        private void tb_A_Scroll(object sender, EventArgs e)
        {
            Amplitude = tb_A.Value / 100.0f;
            lb_A.Text = Amplitude.ToString();
        }

        private void tb_F_Scroll(object sender, EventArgs e)
        {
            Frequency = tb_F.Value / 10.0f;
            lb_F.Text = Frequency.ToString();
        }
    }
}
