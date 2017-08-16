using System;
using System.Linq;
using System.Windows.Forms;
using BookStoreApp.Model;

namespace BookStoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetBooks_Click(object sender, EventArgs e)
        {
            var bookClient = new BookStoreClient();
            var bookResult = bookClient.GetBook("programming");
            if (bookResult == null)
            {
                MessageBox.Show(@"Cannot found");
            }
            else
            {
                var bookInfos = bookResult.Items.Select(b => new BookInfo()
                {
                    ID = b.Id,
                    Title = b.VolumeInfo.Title,
                    Publisher = b.VolumeInfo.Publisher,
                    PublishDate = b.VolumeInfo.PublishedDate,
                    Description = b.VolumeInfo.Description
                }).ToList();

                dataGridView1.DataSource = bookInfos;

            }
        }
    }
}
