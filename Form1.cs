using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string mdpfin = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void Selection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "D:\\Mes Documents\\cour\\master\\crypto\\Projet_crypto\\WindowsFormsApplication1\\bin\\Debug";
            openFileDialog.Filter = "Tous les fichiers|*.*";

            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
                progressBar1.Value = 0;
                textBox1.Text = (string)openFileDialog.FileName;

        }

       



        private void crypte_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Erreur, vous devez sélectionner un fichier", "Erreur de sélection de fichier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
                Cle Form_Cle = new Cle();
                if (Form_Cle.ShowDialog() == DialogResult.OK)
                {
                    // Récupérer le mot de passe
                    mdpfin = Form_Cle.Password;



                    // Arguments à passer à la fonction
						string [] arg = new string[3];

						// Fichier source
						arg[0] = @textBox1.Text;
                        arg[1] = Path.ChangeExtension(Path.GetFileName(@textBox1.Text.Replace('.', '_')), ".mps");
                        arg[2] = mdpfin;



                    // Si on choisit l'algo simple et On encrypte le fichier
                    if (radioButton1.Checked == true)
                    {
                        if (File.Exists(arg[1]))
                        {
                            File.Delete(arg[1]);
                        }

                        Encrypt_Simple(arg[0],arg[1],arg[2]);

                      
                        // On indique depuis quelle source on va lire les données
                        FileStream File_To_Read = new FileStream(textBox1.Text, FileMode.Open);

                        int donnees = 0;

                        // On récupèr la taille du fichier et on l'affecte à
                        // la valeur maximale de la progresse barre
                        FileInfo Taille_Fichier = new FileInfo(@textBox1.Text);
                        progressBar1.Maximum = (int)Taille_Fichier.Length;

                        // Tant que l'on peut lire des bytes dans le fichier
                        while ((donnees = File_To_Read.ReadByte()) != -1)
                        {
                            // On met un curseur en forme de sablier
                            this.Cursor = Cursors.WaitCursor;

                            // On fait avancer la progresse barre
                            progressBar1.PerformStep();
                        }
                        File_To_Read.Close();
                        this.Cursor = Cursors.Arrow;
                       
                        

                        MessageBox.Show("Le fichier a été crypté avec succès avec la fonction simple", "Crytage du fichier terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }

                    //si on choisit le chryptage complexe
                    else if (radioButton2.Checked == true)
                    {

                        if (File.Exists(arg[1]))
                        {
                            File.Delete(arg[1]);
                        }

                        Encrypt_Compl(arg[0], arg[1], arg[2]);


                        // On indique depuis quelle source on va lire les données
                        FileStream File_To_Read = new FileStream(textBox1.Text, FileMode.Open);

                        int donnees = 0;

                        // On récupèr la taille du fichier et on l'affecte à
                        // la valeur maximale de la progresse barre
                        FileInfo Taille_Fichier = new FileInfo(@textBox1.Text);
                        progressBar1.Maximum = (int)Taille_Fichier.Length;

                        // Tant que l'on peut lire des bytes dans le fichier
                        while ((donnees = File_To_Read.ReadByte()) != -1)
                        {
                            // On met un curseur en forme de sablier
                            this.Cursor = Cursors.WaitCursor;

                            // On fait avancer la progresse barre
                            progressBar1.PerformStep();
                        }
                        File_To_Read.Close();
                        this.Cursor = Cursors.Arrow;



                        MessageBox.Show("Le fichier a été crypté avec succès avec la fonction Complexe", "Crytage du fichier terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
            }

        }



        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Erreur, vous devez sélectionner un fichier", "Erreur de sélection de fichier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
                Cle Form_Cle = new Cle();
                if (Form_Cle.ShowDialog() == DialogResult.OK)
                {
                    // Récupérer le mot de passe
                    mdpfin = Form_Cle.Password;

                    //Arguments à passer à la fonction
						string [] arg = new string[3];

						// Fichier source
						arg[0] = @textBox1.Text;
                        arg[1] = Path.ChangeExtension(Path.GetFileName(@textBox1.Text.Replace('_', '.')), "");
                        arg[2] = mdpfin;



                    // Si on choisit l'algo simple et On encrypte le fichier
                    if (radioButton1.Checked == true)
                    {

                        if (File.Exists(arg[1]))
                        {
                            File.Delete(arg[1]);
                        }

                        Decrypt_Simple(arg[0], arg[1], arg[2]);


                        // On indique depuis quelle source on va lire les données
                        FileStream File_To_Read = new FileStream(textBox1.Text, FileMode.Open);

                        int donnees = 0;

                        // On récupèr la taille du fichier et on l'affecte à
                        // la valeur maximale de la progresse barre
                        FileInfo Taille_Fichier = new FileInfo(@textBox1.Text);
                        progressBar1.Maximum = (int)Taille_Fichier.Length;



                        // Tant que l'on peut lire des bytes dans le fichier
                        while ((donnees = File_To_Read.ReadByte()) != -1)
                        {
                            // On met un curseur en forme de sablier
                            this.Cursor = Cursors.WaitCursor;

                            // On fait avancer la progresse barre
                            progressBar1.PerformStep();
                        }
                        File_To_Read.Close();
                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show("Le fichier a été décrypté avec succès avec la fonction simple", "Decrytage du fichier terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //si on choisit le chryptage complexe
                    if (radioButton2.Checked == true)
                    {

                        if (File.Exists(arg[1]))
                        {
                            File.Delete(arg[1]);
                        }

                        Decrypt_Compl(arg[0], arg[1], arg[2]);


                        // On indique depuis quelle source on va lire les données
                        FileStream File_To_Read = new FileStream(textBox1.Text, FileMode.Open);

                        int donnees = 0;

                        // On récupèr la taille du fichier et on l'affecte à
                        // la valeur maximale de la progresse barre
                        FileInfo Taille_Fichier = new FileInfo(@textBox1.Text);
                        progressBar1.Maximum = (int)Taille_Fichier.Length;



                        // Tant que l'on peut lire des bytes dans le fichier
                        while ((donnees = File_To_Read.ReadByte()) != -1)
                        {
                            // On met un curseur en forme de sablier
                            this.Cursor = Cursors.WaitCursor;

                            // On fait avancer la progresse barre
                            progressBar1.PerformStep();
                        }
                        File_To_Read.Close();
                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show("Le fichier a été décrypté avec succès avec la fonction complexe", "Decrytage du fichier terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }


        private void Encrypt_Simple(string sourcefile, string resultfile, string mdp)
           {// Tableau de bytes
               byte[] buffer = new byte[2048];
                BitArray bit_fichier;
                
               largeur Scrambler = new largeur(mdp);
                
                
               try
               {
                   // Flux qui vont lire le fichier source et créer le fichier de destination
                   FileStream iStream = new FileStream(sourcefile, FileMode.Open);
                   FileStream oStream = new FileStream(resultfile, FileMode.CreateNew);

                   int read;
                   while ((read = iStream.Read(buffer, 0, 2048)) > 0)
                   {
                        bit_fichier = new BitArray(buffer);
                       
                       //oStream.Write(Scrambler.crypteS(bit_fichier), 0, read);
                   }
                   new BitArray(new byte[] { bit_fichier });
                   iStream.Close();
                   oStream.Flush();
                   oStream.Close();

                   buffer = null;
               }
               catch (Exception Ex)
               {
                   MessageBox.Show("Erreur lors du cryptage du fichier avec la fonction XOR!\nErreur : " + Ex.Message, "Erreur de cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           
        }


        private void Encrypt_Compl(string sourcefile, string resultfile, string mdp)
        {// Tableau de bytes
            byte[] buffer = new byte[2048];


            largeur Scrambler = new largeur(mdp);
           

            try
            {
                // Flux qui vont lire le fichier source et créer le fichier de destination
                FileStream iStream = new FileStream(sourcefile, FileMode.Open);
                FileStream oStream = new FileStream(resultfile, FileMode.CreateNew);

                int read;
                while ((read = iStream.Read(buffer, 0, 2048)) > 0)
                {   BitArray bit_fichier = new BitArray(buffer);
                    oStream.Write(Scrambler.crypteC(bit_fichier), 0, read);
                }
                
                iStream.Close();
                oStream.Flush();
                oStream.Close();

                buffer = null;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erreur lors du cryptage du fichier avec la fonction XOR!\nErreur : " + Ex.Message, "Erreur de cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       



        private void Decrypt_Simple(string sourcefile, string resultfile, string mdp)
        { 
        // Tableau de bytes
			byte[] buffer = new byte[2048];

			largeur Scrambler = new largeur(mdp);

			try
			{
				// Flux qui vont lire le fichier source et créer le fichier de destination
				FileStream iStream = new FileStream(sourcefile, FileMode.Open);
				FileStream oStream = new FileStream(resultfile, FileMode.CreateNew);

                int read;
              
				while( (read = iStream.Read(buffer, 0, 2048)) > 0 )
				{
					oStream.Write(Scrambler.crypteS(buffer), 0, read);
				}
				iStream.Close();
				oStream.Flush();
				oStream.Close();

				buffer = null;
			}
			catch(Exception Ex)
			{
				MessageBox.Show("Erreur lors du decryptage du fichier avec la fonction XOR!\nErreur : " + Ex.Message, "Erreur de cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void Decrypt_Compl(string sourcefile, string resultfile, string key)
        {
            // Tableau de bytes
            byte[] buffer = new byte[2048];

            largeur Scrambler = new largeur(key);

            try
            {
                // Flux qui vont lire le fichier source et créer le fichier de destination
                FileStream iStream = new FileStream(sourcefile, FileMode.Open);
                FileStream oStream = new FileStream(resultfile, FileMode.CreateNew);

                int read;

                while ((read = iStream.Read(buffer, 0, 2048)) > 0)
                {
                    oStream.Write(Scrambler.crypteS(buffer), 0, read);
                }
                iStream.Close();
                oStream.Flush();
                oStream.Close();

                buffer = null;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erreur lors du decryptage du fichier avec la fonction XOR!\nErreur : " + Ex.Message, "Erreur de cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        public class largeur
        {
            byte[] key;

            // On prend la clé passée en paramètre
            public largeur(string keystring)
            {
                System.Text.ASCIIEncoding encodedData = new System.Text.ASCIIEncoding();
                // Et on la stocke dans un table de bytes
                key = encodedData.GetBytes(keystring);
            }


            
            // Pour "mélanger" les bytes des fichiers
            /*public byte[] crypte(byte[] b)
            {
                
                byte[] r = new byte[b.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    r[i] = (byte)(b[i] ^ key[i % key.Length]);
                }
                return r;
            }*/

            public byte[] cle(byte[] b, byte[] key)
            {
                byte[] r = new byte[b.Length];
                
                int code=0;
                for (int i = 0; i < b.Length; i++)
                {
                    if (i < key.Length)
                    { r[i] = key[i]; }
                    else
                        code = b[i - 1] ^ b[i - 2] ^ b[i - 4];
                    r[i] = (byte)code;
                }
                return r;
            }



            // Pour "mélanger" les bytes des fichiers
            public BitArray crypteS(BitArray b)
            {
                BitArray cle_bit = new BitArray(key);
                //byte[] Kcle = cle(b, key);
                BitArray r = new BitArray(b.Length);
                for (int i = 0; i < b.Length; i++)
                {
                    r = cle_bit.Xor(b);
                }
                return r;
            }



            public byte[] cleC(byte[] b, byte[] key)
            {
                byte[] r = new byte[b.Length];

                 int code1 = 0; int code2 = 0; int code3 = 0; int code4 = 0;
                 int codeF = 0;
                for (int i = 0; i < b.Length; i++)
                {
                    if (i < key.Length)
                    { r[i] = key[i]; }
                    else
                        code1 = b[i - 5] ^ b[i - 13] ^ b[i - 17] ^ b[i -25];
                        code2 = b[i - 7] ^ b[i - 15] ^ b[i - 19] ^ b[i - 31];
                        code3 = b[i - 5] ^ b[i - 9] ^ b[i - 29] ^ b[i - 33];
                        code4 = b[i - 3] ^ b[i - 11] ^ b[i - 35] ^ b[i - 39];
                        codeF = code1 + code2 + code3 + code4;
                    r[i] = (byte)codeF;
                }
                return r;
            }



            // Pour "mélanger" les bytes des fichiers
            public byte[] crypteC(byte[] b)
            {
                byte[] Kcle = cleC(b, key);
                byte[] r = new byte[b.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    r[i] = (byte)(b[i] ^ Kcle[i]);
                }
                return r;
            }

        }

		
      
}
}

