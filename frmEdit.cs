using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6_code
{
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;

        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenre.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtISBN.Text = myBook.isbn;
                txtCover.Text = myBook.cover;
                txtLength.Text = myBook.length.ToString();

                pbCover.Load(myBook.cover);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenre.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.isbn = txtISBN.Text;
            myBook.cover = txtCover.Text;
            myBook.length = int.Parse(txtLength.Text);

            BookFile.SaveBook(myBook, cwid, mode);
            MessageBox.Show("Content was saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
