#region Usos
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
#endregion

namespace BlocDeNotas
{
    public partial class NoteBook : Form
    {
        #region Inicializar componente NoteBook
        public NoteBook()
        {
            InitializeComponent();
        }
        #endregion

        #region Botones Editar
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbInformation.Copy();
        }
        private void pasteçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbInformation.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbInformation.SelectAll();
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbInformation.Clear();
        }
        #endregion

        #region Botones de Archivo
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbInformation.Clear();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Proceso1();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proceso2();
        }
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proceso3();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #endregion

        #region Metodo
        public void Proceso1()
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "All Filter (*.txt) | *.txt";

            if(open.ShowDialog() == DialogResult.OK)
            {
                rtbInformation.Text = File.ReadAllText(open.FileName); 
            }
        }

        public void Proceso2()
        {
           
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Text Files (*.txt) | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                rtbInformation.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
            }


        }

        public void Proceso3()
        {
            SaveFileDialog saveas = new SaveFileDialog();
            StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);

            
            saveas.Filter = "Text files (*.txt) | *.txt ";
            saveas.CheckFileExists = true;
            saveas.Title = "Guardar Como";
            saveas.ShowDialog(this);


            try
            {
                streamWriter = File.AppendText(saveas.Filter);
                streamWriter.Write(rtbInformation.Text);
                streamWriter.Flush();

            }
            catch
            {

            }
        }
        #endregion

        #region Extras
        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
