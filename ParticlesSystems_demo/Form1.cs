using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

[assembly:CLSCompliant(true)]
namespace Particles
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private static readonly Vector MIDDLE_OF_VIEW = new Vector(200,200,200);
		private ParticlesSystem ps = null;

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button butExplosion;
		private System.Windows.Forms.Button butFountain;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.PictureBox picDisplay;
		private System.Windows.Forms.Button butFirework;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Environment.GetInstance().Gravity = new Vector(0.0f, -0.02f, 0.0f);
			Environment.GetInstance().Wind = new Vector(0.002f, 0.0f, 0.0f);

			if (Environment.GetInstance().Gravity == Environment.GetInstance().Wind)
				return ;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.butExplosion = new System.Windows.Forms.Button();
			this.butFountain = new System.Windows.Forms.Button();
			this.butStop = new System.Windows.Forms.Button();
			this.picDisplay = new System.Windows.Forms.PictureBox();
			this.butFirework = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// butExplosion
			// 
			this.butExplosion.Location = new System.Drawing.Point(8, 8);
			this.butExplosion.Name = "butExplosion";
			this.butExplosion.TabIndex = 0;
			this.butExplosion.Text = "Explosion";
			this.butExplosion.Click += new System.EventHandler(this.butExplosion_Click);
			// 
			// butFountain
			// 
			this.butFountain.Location = new System.Drawing.Point(8, 40);
			this.butFountain.Name = "butFountain";
			this.butFountain.TabIndex = 0;
			this.butFountain.Text = "Fountain";
			this.butFountain.Click += new System.EventHandler(this.butFountain_Click);
			// 
			// butStop
			// 
			this.butStop.Location = new System.Drawing.Point(8, 264);
			this.butStop.Name = "butStop";
			this.butStop.TabIndex = 0;
			this.butStop.Text = "Stop";
			this.butStop.Click += new System.EventHandler(this.butStop_Click);
			// 
			// picDisplay
			// 
			this.picDisplay.BackColor = System.Drawing.SystemColors.Control;
			this.picDisplay.Location = new System.Drawing.Point(96, 8);
			this.picDisplay.Name = "picDisplay";
			this.picDisplay.Size = new System.Drawing.Size(368, 280);
			this.picDisplay.TabIndex = 1;
			this.picDisplay.TabStop = false;
			this.picDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.picDisplay_Paint);
			// 
			// butFirework
			// 
			this.butFirework.Location = new System.Drawing.Point(8, 72);
			this.butFirework.Name = "butFirework";
			this.butFirework.TabIndex = 2;
			this.butFirework.Text = "Firework";
			this.butFirework.Click += new System.EventHandler(this.butFirework_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(472, 294);
			this.Controls.Add(this.butFirework);
			this.Controls.Add(this.picDisplay);
			this.Controls.Add(this.butExplosion);
			this.Controls.Add(this.butFountain);
			this.Controls.Add(this.butStop);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (!ps.Update())
			{
				picDisplay.Refresh();
				ps = null;
				timer1.Enabled = false;
			}
			else
			{
				picDisplay.Refresh();
			}
		}

		private void butExplosion_Click(object sender, System.EventArgs e)
		{
			ps = new PSExplosion(MIDDLE_OF_VIEW, Color.FromArgb(255,0,0));
			timer1.Enabled = true;
		}

		private void butFountain_Click(object sender, System.EventArgs e)
		{
			ps = new PSFountain(MIDDLE_OF_VIEW, Color.FromArgb(0,0,255));
			timer1.Enabled = true;
		}

		private void butFirework_Click(object sender, System.EventArgs e)
		{
			ps = new PSFirework(MIDDLE_OF_VIEW, Color.FromArgb(200,0,255));
			timer1.Enabled = true;
		}

		private void butStop_Click(object sender, System.EventArgs e)
		{
			ps = null;
			timer1.Enabled = false;
			this.Refresh();
		}

		private void picDisplay_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (ps == null)
				return;
			ps.Draw(e.Graphics);
		}


	}
}
