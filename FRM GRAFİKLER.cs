using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace secimProjesi
{
    public partial class FRM_GRAFİKLER : Form
    {
        public FRM_GRAFİKLER()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-H4P4VAC\SQLEXPRESS;Initial Catalog=DbSecimProje;Integrated Security=True;");
        private void FRM_GRAFİKLER_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCE from TBLILCE ", baglanti);
            SqlDataReader DR = komut.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE", baglanti);
            SqlDataReader DR2 = komut2.ExecuteReader();

            while (DR2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti",DR2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", DR2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", DR2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", DR2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", DR2[4]);

            }
            baglanti.Close() ;

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open () ;

            SqlCommand komut = new SqlCommand("Select * From TBLILCE where ILCE=@P1", baglanti);
            komut.Parameters.AddWithValue("@p1" , comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                label7.Text = dr[2].ToString();
                label8.Text = dr[3].ToString();
                label9.Text = dr[4].ToString();
                label10.Text = dr[5].ToString();
                label11.Text = dr[6].ToString();

            }
            baglanti.Close () ;
        }
    }
}
