using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public class Cle : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;

		private System.ComponentModel.Container components = null;
		private	string pass = "";


		public Cle()
		{

			InitializeComponent();


		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saisissez la clé :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Valider";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Annuler";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 90);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(264, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirmez la clé :";
            // 
            // Cle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 197);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Cle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saisie de la clé";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if ( textBox1.Text == String.Empty )
			{
				MessageBox.Show("Erreur, vous devez saisir une clé valide", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox1.Focus();
				this.DialogResult = DialogResult.None;
			}
			else if ( textBox1.Text != textBox2.Text )
			{
				MessageBox.Show("Erreur, les deux clés ne correspondent pas", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox1.Text = String.Empty;
				textBox2.Text = String.Empty;

				textBox1.Focus();

				this.DialogResult=DialogResult.None;
			}
			// La clé doit être de 16 bytes (8 caractères) donc on fait
			// des tests dessus

			// Si la taille de la clé saisie est supérieure à 8 caractères
			else if ( textBox1.Text.Length > 8 )
			{
				// On prend les 8 premiers caractères de la clé choisit
				pass = textBox1.Text.Substring(0, 8);

				this.DialogResult = DialogResult.OK;
			}
			else if ( textBox1.Text.Length < 8 )
			{
				// Si la taille de la clé saisie est inférieure à 8 caractères

				// On cherche combien de catacères sont manquant
				int Caracteres_manquant = 8 - textBox1.Text.Length;

				// On complète ensuite le nombre de caractères manquants
				for ( int i = 0; i < Caracteres_manquant; i++ )
				{
					textBox1.Text = textBox1.Text + i;
				}

				pass = textBox1.Text;
				
				this.DialogResult=DialogResult.OK;
			}
			else
			{
				pass = textBox1.Text;

				this.DialogResult = DialogResult.OK;
			}
		}

		public string Password
		{
			get
			{
				return pass;
			}
		}

       
    }
}
