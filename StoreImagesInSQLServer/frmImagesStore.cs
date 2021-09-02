using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace StoreImagesInSQLServer
{
    public partial class frmImagesStore : Form
    {
        public frmImagesStore()
        {
            InitializeComponent();
        }

        //Get table rows from sql server to be displayed in Datagrid.
        void GetImagesFromDatabase()
        {
            try
            {
                //Initialize SQL Server connection.
                SqlConnection CN = new SqlConnection(txtConnectionString.Text);

                //Initialize SQL adapter.
                SqlDataAdapter ADAP = new SqlDataAdapter("Select * from ImagesStore", CN);

                //Initialize Dataset.
                DataSet DS = new DataSet();

                //Fill dataset with ImagesStore table.
                ADAP.Fill(DS, "ImagesStore");

                //Fill Grid with dataset.
                dataGridView1.DataSource = DS.Tables["ImagesStore"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            //Fill datagrid with table rows.
            GetImagesFromDatabase();
        }

        //Open form to get new image file.
        private void cmdStoreNewImage_Click(object sender, EventArgs e)
        {
            frmNewImage fNew = new frmNewImage();
            //Supply connection string from this form to frmNewImage form.
            fNew.txtConnectionString.Text = txtConnectionString.Text;
            fNew.ShowDialog();

            //Refresh Image
            cmdConnect_Click(null, null);
        }

        //When user changes row selection, display image of selected row in picture box.
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Get image data from gridview column.
                byte[] imageData = (byte[])dataGridView1.Rows[e.RowIndex].Cells["ImageData"].Value;

                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                pictureBox1.Image = newImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmImagesStore_Load(object sender, EventArgs e)
        {

        }
        
    }
}