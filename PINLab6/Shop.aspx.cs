using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PINLab6
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSpremi_Click(object sender, EventArgs e)
        {
            string naziv = TbNaziv.Text;
            string opis = TbOpis.Text;

            if (ProizvodPostoji(naziv))
            {
                lblErrorPoruka.Text = "Proizvod sa tim nazivom već postoji.";
            }
            else
            {
                SpremiProizvod(naziv, opis);

                OsvjeziGrid();

                ObrisiInput();
            }
        }

        protected void GridView1_ObrisiRed(object sender, GridViewDeleteEventArgs e)
        {
            int proizvodId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"]);
            ObrisiProizvodId(proizvodId);

            OsvjeziGrid();
        }

        private bool ProizvodPostoji (string proizvodIme)
        {
            using (SqlConnection _connection = new
                SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE Name = @ProductName";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@ProductName", proizvodIme);

                    //vraća broj podudarajućih query redova
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool SpremiProizvod(string naziv, string opis)
        {
            using (SqlConnection _connection = new
                SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "INSERT INTO Products (Name, Description) VALUES (@Name, @Description)";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Name", naziv);
                    cmd.Parameters.AddWithValue("@Description", opis);

                    int count = cmd.ExecuteNonQuery();

                    return count > 0;
                }
            }
        }
        private void ObrisiProizvod(string naziv)
        {
            using (SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "DELETE FROM Products WHERE Name = @Naziv";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Naziv", naziv);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ObrisiProizvodId(int proizvodId)
        {
            using (SqlConnection _connection = new
                SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "DELETE FROM Products WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Id", proizvodId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void OsvjeziGrid()
        {
            using (SqlConnection _connection = new
                SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "SELECT Id, Name, Description FROM Products";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, _connection))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    GridView1.DataBind();
                }
            }
        }

        private void ObrisiInput()
        {
            TbNaziv.Text = string.Empty;
            TbOpis.Text = string.Empty;
            lblErrorPoruka.Text = string.Empty;
        }

        protected void BtnUkloni_Click(object sender, EventArgs e)
        {
            string naziv = TbNaziv.Text;
            string opis = TbOpis.Text;

            if (ProizvodPostoji(naziv))
            {
                ObrisiProizvod(naziv);
                OsvjeziGrid();
                ObrisiInput();
                lblErrorPoruka.Text = "Proizvod uspješno obrisan.";
            }
            else
            {
                lblErrorPoruka.Text = "Proizvod s tim nazivom ne postoji.";
            }


        }
    }
}