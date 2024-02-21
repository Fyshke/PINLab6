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
    public partial class Registracija : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string korisnik = TbKorisnik.Text;
            string punoime = TbIme.Text;
            string lozinka = TbLozinka.Text;
            string plozinka = TbPLozinka.Text;

            //provjera lozinki
            if (lozinka != plozinka)
            {
                lblErrorPoruka.Text = "Lozinke nisu jednake.";
                return;
            }

            //provjera postoji li korisnik
            if (!PostojeciKorisnik(korisnik))
            {
                if (RegistracijaKorisnika(korisnik, punoime, lozinka)) 
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblErrorPoruka.Text = "Neuspješna registracija, pokušajte ponovno.";
                }
            }
            else
            {
                lblErrorPoruka.Text = "Unijeli ste postojeće korisičko ime.";
            }
        }

        private bool PostojeciKorisnik(string korisnik)
        {
            using (SqlConnection _connection = new
                SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", korisnik);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool RegistracijaKorisnika(string korisnik, string punoime, string lozinka) 
        {
            using (SqlConnection _connection = new
                SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsConnectionString"].ToString()))
            {
                _connection.Open();
                string query = "INSERT INTO Users (UserName, Password,FullName) VALUES (@UserName, @Password, @FullName)";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", korisnik);
                    cmd.Parameters.AddWithValue("@Password", lozinka);
                    cmd.Parameters.AddWithValue("@FullName", punoime);
                    int redovi = cmd.ExecuteNonQuery();
                    return redovi > 0;
                }
            } 
        }

        
    }
}