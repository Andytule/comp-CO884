using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment1
{
    public partial class Register : System.Web.UI.Page
    {
        /// <summary>
        /// Sets focus to first name text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            firstTextBox.Focus();
            outputLiteral.Text = "";
        }

        /// <summary>
        /// If inputs are valid including age, add new person to database.
        /// Reset inputs.
        /// </summary>
        /// <param name="sender">submitButton</param>
        /// <param name="e">Event data</param>
        protected void submitButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            Boolean test = false;
            if (IsValid)
            {
                DateTime.TryParse(dateTextBox.Text, out DateTime date);
                if ((18 < DateTime.Today.Year - date.Date.Year) || ((18 == DateTime.Today.Year - date.Date.Year) && (date.Date.Month < DateTime.Today.Month)) || ((18 == DateTime.Today.Year - date.Date.Year) && (date.Date.Month == DateTime.Today.Month) && (date.Date.Day <= DateTime.Today.Day)))
                {
                    try
                    {
                        var connectionString = WebConfigurationManager.ConnectionStrings["HASCConnectionString"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string queryString = "SELECT person_id FROM persons ORDER BY person_id ASC;";
                            SqlCommand command = new SqlCommand(queryString, connection);
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                id = (int)reader["person_id"];
                                test = true;
                            }
                            reader.Close();
                        }

                        if (test)
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                var command = new SqlCommand("INSERT INTO persons(person_id, first_name, last_name, division_id, email, birth_date, player) VALUES(@person_id, @first_name, @last_name, @division_id, @email, @birth_date, @player)", connection);
                                command.Parameters.Add("@person_id", SqlDbType.Int);
                                command.Parameters["@person_id"].Value = id + 1;
                                command.Parameters.Add("@first_name", SqlDbType.VarChar);
                                command.Parameters["@first_name"].Value = firstTextBox.Text;
                                command.Parameters.Add("@last_name", SqlDbType.VarChar);
                                command.Parameters["@last_name"].Value = lastTextBox.Text;
                                command.Parameters.Add("@division_id", SqlDbType.Int);
                                command.Parameters["@division_id"].Value = divisionDropDownList.SelectedValue;
                                command.Parameters.Add("@email", SqlDbType.VarChar);
                                command.Parameters["@email"].Value = emailTextBox.Text;
                                command.Parameters.Add("@birth_date", SqlDbType.Date);
                                command.Parameters["@birth_date"].Value = dateTextBox.Text;
                                command.Parameters.Add("@player", SqlDbType.Bit);
                                command.Parameters["@player"].Value = true;
                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {

                        outputLiteral.Text += $"<div class='alert alert-danger' role='alert'>{ex.Message}</ div >";
                    }
                    firstTextBox.Text = "";
                    lastTextBox.Text = "";
                    divisionDropDownList.SelectedIndex = 0;
                    emailTextBox.Text = "";
                    dateTextBox.Text = "";
                    outputLiteral.Text += $"<div class='alert alert-success' role='alert'>Thank you for your interest. The club will be in touch shortly.</ div >";
                }
                else
                {
                    outputLiteral.Text += $"<div class='alert alert-danger' role='alert'>You must be at least 18 years of age to join the club.</ div >";
                    dateTextBox.Focus();
                }
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}