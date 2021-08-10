using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ontap03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-GBBCS2R;Initial Catalog=bech;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from tblOrder";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
        private void add() {
            string sqlInsert = "INSERT INTO tblOrder(Quantity ,Note, CustName, CustMobile, CustAddress) values (@Quantity,@Note,@CustName,@CustMobile, @CustAddress) ";
            SqlCommand com = new SqlCommand(sqlInsert, cnn);
            com.Parameters.AddWithValue("@Quantity", tbQuantity.Text);// dữ liệu 01
            com.Parameters.AddWithValue("@Note", tbNote.Text);
            com.Parameters.AddWithValue("@CustName", tbCustName.Text);
            com.Parameters.AddWithValue("@CustMobile", tbCustMobile.Text);
            com.Parameters.AddWithValue("@CustAddress", tbCustAddress.Text);
            cnn.Open();
            com.ExecuteNonQuery();
            cnn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ( Int32.Parse (tbQuantity.Text) < 0)
                MessageBox.Show("Quantity must be greater than 0 ");       
            if (tbCustName.Text == string.Empty)
                MessageBox.Show("TextBox is Empty");
            if (tbCustMobile.Text == string.Empty)
                MessageBox.Show("TextBox is Empty");
            if (tbCustAddress.Text == string.Empty)
                MessageBox.Show("TextBox is Empty");
            add();
            ketnoicsdl();
        }
    }
}
