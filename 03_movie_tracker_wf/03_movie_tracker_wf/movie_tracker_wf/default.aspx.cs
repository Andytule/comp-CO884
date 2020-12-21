using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movie_tracker_wf
{
    public partial class _default : System.Web.UI.Page
    {
        /// <summary>
        /// Set input focus to title1 text box and clear output literal.
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e">Event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            titleTextBox.Focus();
            outputLiteral.Text = "";
        }

        /// <summary>
        /// If the date isn't in the future, instantiate a new movie and add it to the list of movies.
        /// Reset inputs.
        /// </summary>
        /// <param name="sender">addButton</param>
        /// <param name="e">Event data</param>
        protected void addButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                DateTime.TryParse(dateTextBox.Text, out DateTime date);
                int.TryParse(ratingTextBox.Text, out int rating);

                if (date.Date <= DateTime.Today)
                {
                    try
                    {
                        var connectionString = WebConfigurationManager.ConnectionStrings["movie_trackerConnectionString"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            var command = new SqlCommand("INSERT INTO movies VALUES(@title, @date, @genre, @rating)", connection);
                            command.Parameters.Add("@title", System.Data.SqlDbType.VarChar);
                            command.Parameters["@title"].Value = titleTextBox.Text;
                            command.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = date.ToShortDateString();
                            command.Parameters.AddWithValue("@genre", genreDropDownList.SelectedValue); // Sloppy, because data type isn't specified
                            command.Parameters.Add("@rating", System.Data.SqlDbType.Int).Value = rating;
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        outputLiteral.Text += $"<p style=\"color:red;\">{ex.Message}</p>";
                    }

                    titleTextBox.Text = "";
                    dateTextBox.Text = "";
                    genreDropDownList.SelectedIndex = 0;
                    ratingTextBox.Text = "";
                } // (date.Date <= DateTime.Today)
                else
                {
                    outputLiteral.Text += "<p style=\"color:red;\">Date can't be in future.</p>";
                    dateTextBox.Focus();
                }

            } // (IsValid)
        }

        /// <summary>
        /// Retrieve the existing movies from the database.
        /// Loop through them and build a table with one row per movie.
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e">Event data</param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            outputLiteral.Text += @"<table class=""striped"">
                                          <tr>
                                            <th>Title</th>
                                            <th>Date Seen</th>
                                            <th>Genre</th>
                                            <th>Rating</th>
                                          <tr>";

            try
            {
                var connectionString = WebConfigurationManager.ConnectionStrings["movie_trackerConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(@"SELECT title, date_seen, genre_description, rating
                                                   FROM movies m
                                                   JOIN genres g
                                                   ON m.genre_id = g.genre_id",
                                                   connection);
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        outputLiteral.Text += $@"<tr>
                                               <td>{reader["title"].ToString()}</td>
                                               <td>{reader.GetDateTime(1).ToShortDateString()}</td>
                                               <td>{reader["genre_description"].ToString()}</td>
                                               <td style=""text-align:center;"">{(int)reader["rating"]}</td>
                                             </tr>";
                    } // (reader.Read())
                }
            }
            catch (Exception ex)
            {
                outputLiteral.Text += $"<p style=\"color:red;\">{ex.Message}</p>";
            }

            outputLiteral.Text += "</table>";
        }
    }
}