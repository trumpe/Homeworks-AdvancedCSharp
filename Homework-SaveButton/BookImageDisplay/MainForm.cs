using BooksProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookImageDisplay
{
    public partial class MainForm : Form
    {
        public IEnumerable<Author> authors;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // authors are gotten from http://www.worldswithoutend.com
            BooksLoader booksLoader = new BooksLoader();
            authors = booksLoader.GetAllAuthors();
            lbxAuthors.DataSource = authors;
            lbxAuthors.DisplayMember = "Name";
        }

        private void lbxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            var author = lbxAuthors.SelectedItem as Author;
            lbxBooks.DataSource = author.Books;
            lbxBooks.DisplayMember = "Title";
        }

        private void lbxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var author = lbxAuthors.SelectedItem as Author;
            var book = lbxBooks.SelectedItem as Book;

            var bookOneOrMoreAuthors = authors
                .SelectMany(a => a.Books.Where(b => b.ID == book.ID)
                .Select(b => new
                {
                    a.Name,
                    b.Title
                })).GroupBy(b => b.Name)
                .Select(g => string.Join("", g.Key.Split(' ').Select(part => part[0])).ToLower());

            var authorInitials = string.Join("", bookOneOrMoreAuthors);

            //var authorInitials = string.Join("", author.Name.Split(' ').Select(part => part[0])).ToLower();

            var bookName = string.Join("", book.Title.Split(' '));
            bookName = Regex.Replace(bookName, "[']", "");
            bookName = Regex.Replace(bookName, "[,]", "");
            bookName = bookName.Substring(0, Math.Min(8, bookName.Length));

            var imageName = $"http://www.worldswithoutend.com/covers/{authorInitials}_{bookName}.jpg";

            try
            {
                pbxCover.Load(imageName);
            }
            catch (WebException wex)
            {
                var response = wex.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    pbxCover.Load("https://via.placeholder.com/235x375.png?text=No+image+found");
                }
                else
                {
                    throw;
                }
            }
        }

        private void lnkNovelPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var book = lbxBooks.SelectedItem as Book;
            var url = $"http://www.worldswithoutend.com/novel.asp?ID={book.ID}";
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Save an Image";
            saveFileDialog.Filter = "JPeg Image|*.jpg|Png Image|*.png|Bmp Image|*.bmp";
            saveFileDialog.FileName = Path.GetFileName(pbxCover.ImageLocation).ToLower(); // To fill the filename box with image filename

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbxCover.Image.Save(saveFileDialog.FileName);
            }
        }
    }
}
