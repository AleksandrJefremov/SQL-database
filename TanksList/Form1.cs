using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Ingen kod här, då metoden inte innehåller några specifika åtgärder när etiketten klickas.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ingen kod här, då metoden inte innehåller några specifika åtgärder när formuläret laddas.
        }

        // Knapp för att hämta alla pansarvagnar från databasen
        public void button1_Click(object sender, EventArgs e)
        {
            // Anslutningsstring till SQL Server-databasen
            string sSQLconnectionstring = "Server=DESKTOP-913P9K3\\SQLEXPRESS;Database=Tanks;Integrated Security=True";

            // SQL query för att hämta alla kolumner från tabellen "Tanks"
            string inputSQL = "SELECT * FROM Tanks";
            int iRows = 0; // Variabel för att räkna antalet rader hämtade från databasen

            SqlConnection conx; // Skapa en ny SQL Connection-objekt
            conx = new SqlConnection();
            conx.ConnectionString = sSQLconnectionstring; // Ange anslutningssträngen för objektet
            conx.Open(); // Öppna anslutningen till databasen

            SqlCommand comx = new SqlCommand(); // Skapa en SQL Command-objekt för att utföra SQL-kommandon
            comx.Connection = conx; // Koppla SQL Command-objektet till den öppna anslutningen
            comx.CommandType = CommandType.Text; // Ange att kommandot är av typen Text
            comx.CommandText = inputSQL; // Ange SQL-queryn för kommandot
            SqlDataReader reader = comx.ExecuteReader(); // Utför SQL-queryn och returnerar en SqlDataReader

            this.listBox1.Items.Clear(); // Rensa befintliga objekt i listboxen

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Lägg till varje tanks namn i listboxen
                    this.listBox1.Items.Add(reader.GetString(1));
                    iRows = iRows + 1; // Öka räknaren för varje rad i resultatsättet
                }
                this.Text = iRows.ToString(); // Uppdatera formulärets titel med antalet rader hämtade från databasen
            }
            else
            {
                this.Text = "No rows found."; // Om inga rader hittades, ange ett meddelande i formulärets titel
            }

            reader.Close(); // Stäng SqlDataReader för att frigöra resurser

        }

        // När ett objekt väljs i listboxen
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Anslutningsstring till SQL Server-databasen
                string sSQLconnectionstring = "Server=DESKTOP-913P9K3\\SQLEXPRESS;Database=Tanks;Integrated Security=True";

                // SQL query för att hämta en specifik tank baserat på namn
                string inputSQL = "SELECT * FROM Tanks WHERE TankName = @TankName";

                using (SqlConnection conx = new SqlConnection(sSQLconnectionstring))
                {
                    conx.Open(); // Öppna anslutningen till databasen

                    using (SqlCommand comx = new SqlCommand(inputSQL, conx))
                    {
                        comx.Parameters.AddWithValue("@TankName", listBox1.SelectedItem.ToString()); // Lägg till en parameter för att undvika SQL Injection

                        SqlDataReader reader = comx.ExecuteReader(); // Utför SQL-queryn och returnerar en SqlDataReader

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Fyll textboxarna med tankens information
                                this.tName.Text = reader.GetString(1); // Fyll textboxen med tankens namn
                                this.tCountry.Text = reader.GetString(5); // Fyll textboxen med tankens land
                                this.tCal.Text = reader.GetDouble(2).ToString(); // Fyll textboxen med tankens kaliber
                                this.tCrew.Text = reader.GetInt32(3).ToString(); // Fyll textboxen med besättningens antal
                                this.tPower.Text = reader.GetInt32(4).ToString(); // Fyll textboxen med motorns effekt
                                this.tAmount.Text = reader.GetInt32(6).ToString(); // Fyll textboxen med antalet byggda enheter
                                this.tProdStart.Text = reader.GetInt32(8).ToString(); // Fyll textboxen med produktionsstartåret

                                // Kontrollera om produktionsavslutningsåret är null, isf visa "Still in production", annars visa året
                                if (!reader.IsDBNull(9))
                                {
                                    this.tProdEnd.Text = reader.GetInt32(9).ToString();
                                }
                                else
                                {
                                    this.tProdEnd.Text = "Still in production";
                                }

                                this.tPrice.Text = reader.GetInt32(7).ToString(); // Fyll textboxen med tankens pris i USD
                                this.tID.Text = reader.GetInt32(0).ToString(); // Fyll textboxen med tankens ID
                            }
                        }
                        else
                        {
                            // Om ingen matchande tank hittas, rensa textboxarna och visa meddelande
                            this.ClearTextBoxes();
                            MessageBox.Show("No matching records found.");
                        }

                        reader.Close(); // Stäng SqlDataReader för att frigöra resurser
                    }
                }
            }
        }

        // Funktion för att rensa alla textboxar
        private void ClearTextBoxes()
        {
            this.tName.Text = "";
            this.tCountry.Text = "";
            this.tCal.Text = "";
            this.tCrew.Text = "";
            this.tPower.Text = "";
            this.tAmount.Text = "";
            this.tProdStart.Text = "";
            this.tProdEnd.Text = "";
            this.tPrice.Text = "";
            this.tID.Text = "";
        }

        // Knapp för att lägga till en ny tank i databasen
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Anslutningssträng till SQL Server-databasen
                string connectionString = "Server=DESKTOP-913P9K3\\SQLEXPRESS;Database=Tanks;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Öppna anslutningen till databasen

                    // Hämta värden från textboxarna och lägg till en ny tank i databasen
                    double mainGunCaliber = double.Parse(this.tCal.Text);
                    int crewCount = int.Parse(this.tCrew.Text);
                    int enginePower = int.Parse(this.tPower.Text);
                    int amountBuilt = int.Parse(this.tAmount.Text);
                    int priceUSD = int.Parse(this.tPrice.Text);
                    int productionStartYear = int.Parse(this.tProdStart.Text);
                    int? productionEndYear = this.tProdEnd.Text.ToLower() == "still in production" ? (int?)null : int.Parse(this.tProdEnd.Text);

                    string insertQuery = "INSERT INTO Tanks (TankName, MainGunCaliber, CrewCount, EnginePower, CountryOfOrigin, AmountBuilt, PriceUSD, ProductionStartYear, ProductionEndYear) " +
                                        "VALUES (@TankName, @MainGunCaliber, @CrewCount, @EnginePower, @CountryOfOrigin, @AmountBuilt, @PriceUSD, @ProductionStartYear, @ProductionEndYear)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Lägg till parametrar för att undvika SQL Injection
                        command.Parameters.AddWithValue("@TankName", this.tName.Text);
                        command.Parameters.AddWithValue("@MainGunCaliber", mainGunCaliber);
                        command.Parameters.AddWithValue("@CrewCount", crewCount);
                        command.Parameters.AddWithValue("@EnginePower", enginePower);
                        command.Parameters.AddWithValue("@CountryOfOrigin", this.tCountry.Text);
                        command.Parameters.AddWithValue("@AmountBuilt", amountBuilt);
                        command.Parameters.AddWithValue("@PriceUSD", priceUSD);
                        command.Parameters.AddWithValue("@ProductionStartYear", productionStartYear);
                        command.Parameters.AddWithValue("@ProductionEndYear", productionEndYear ?? (object)DBNull.Value);

                        command.ExecuteNonQuery(); // Utför SQL-kommandot för att lägga till en ny tank
                    }
                }

                MessageBox.Show("New tank inserted successfully!"); // Visa meddelande om att tanken har lagts till
                button1_Click(sender, e); // Uppdatera listan med tanks efter att en ny tank har lagts till
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting new tank: " + ex.Message); // Visa felmeddelande om något går fel
            }
        }

        // Knapp för att ta bort en tank från databasen
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Anslutningssträng till SQL Server-databasen
                string connectionString = "Server=DESKTOP-913P9K3\\SQLEXPRESS;Database=Tanks;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Om textboxen för Tank ID inte är tom
                    if (!string.IsNullOrEmpty(this.tID.Text))
                    {
                        int tankID = int.Parse(this.tID.Text);

                        // Om tanken med det angivna ID:t existerar, ta bort den
                        if (TankExists(connection, tankID))
                        {
                            DeleteTank(connection, tankID);
                            MessageBox.Show("Tank deleted successfully!");
                            button1_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Tank with ID " + tankID + " does not exist.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Tank ID to delete.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting tank: " + ex.Message);
            }
        }

        // Funktion för att kontrollera om en tank existerar baserat på ID
        public bool TankExists(SqlConnection connection, int tankID)
        {
            string checkQuery = "SELECT COUNT(*) FROM Tanks WHERE TankID = @TankID";

            using (SqlCommand command = new SqlCommand(checkQuery, connection))
            {
                command.Parameters.AddWithValue("@TankID", tankID);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        // Funktion för att ta bort en tank från databasen baserat på ID
        private void DeleteTank(SqlConnection connection, int tankID)
        {
            string deleteQuery = "DELETE FROM Tanks WHERE TankID = @TankID";

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@TankID", tankID);
                command.ExecuteNonQuery();
            }
        }

        // Knapp för att uppdatera eller lägga till en tank i databasen baserat på ID
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Anslutningssträng till SQL Server-databasen
                string connectionString = "Server=DESKTOP-913P9K3\\SQLEXPRESS;Database=Tanks;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Om textboxen för Tank ID inte är tom
                    if (!string.IsNullOrEmpty(this.tID.Text))
                    {
                        int tankID = int.Parse(this.tID.Text);

                        // Om tanken med det angivna ID:t existerar, uppdatera den
                        if (TankExists(connection, tankID))
                        {
                            UpdateTank(connection, tankID);
                            MessageBox.Show("Tank updated successfully!");
                        }
                        else
                        {
                            // Om tanken inte existerar, lägg till en ny
                            InsertTank(connection);
                            MessageBox.Show("New tank inserted successfully!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Tank ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating/inserting tank: " + ex.Message);
            }
        }

        // Funktion för att uppdatera en befintlig tank i databasen baserat på ID
        private void UpdateTank(SqlConnection connection, int tankID)
        {
            // Hämta värden från textboxarna för att använda i SQL-uppdateringsqueryn
            double mainGunCaliber = double.Parse(this.tCal.Text);
            int crewCount = int.Parse(this.tCrew.Text);
            int enginePower = int.Parse(this.tPower.Text);
            int amountBuilt = int.Parse(this.tAmount.Text);
            int priceUSD = int.Parse(this.tPrice.Text);
            int productionStartYear = int.Parse(this.tProdStart.Text);
            int? productionEndYear = this.tProdEnd.Text.ToLower() == "still in production" ? (int?)null : int.Parse(this.tProdEnd.Text);

            // SQL-query för att uppdatera en befintlig tank i databasen
            string updateQuery = "UPDATE Tanks " +
                                 "SET TankName = @TankName, MainGunCaliber = @MainGunCaliber, " +
                                 "CrewCount = @CrewCount, EnginePower = @EnginePower, " +
                                 "CountryOfOrigin = @CountryOfOrigin, AmountBuilt = @AmountBuilt, " +
                                 "PriceUSD = @PriceUSD, ProductionStartYear = @ProductionStartYear, " +
                                 "ProductionEndYear = @ProductionEndYear " +
                                 "WHERE TankID = @TankID";

            // Skapa en SqlCommand för att utföra SQL-uppdateringen
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                // Lägg till parametrar för att undvika SQL Injection och ange värden från textboxarna
                command.Parameters.AddWithValue("@TankID", tankID);
                command.Parameters.AddWithValue("@TankName", this.tName.Text);
                command.Parameters.AddWithValue("@MainGunCaliber", mainGunCaliber);
                command.Parameters.AddWithValue("@CrewCount", crewCount);
                command.Parameters.AddWithValue("@EnginePower", enginePower);
                command.Parameters.AddWithValue("@CountryOfOrigin", this.tCountry.Text);
                command.Parameters.AddWithValue("@AmountBuilt", amountBuilt);
                command.Parameters.AddWithValue("@PriceUSD", priceUSD);
                command.Parameters.AddWithValue("@ProductionStartYear", productionStartYear);
                command.Parameters.AddWithValue("@ProductionEndYear", productionEndYear ?? (object)DBNull.Value);

                command.ExecuteNonQuery(); // Utför SQL-kommandot för att uppdatera tanken
            }
        }

        // Funktion för att lägga till en ny tank i databasen
        private void InsertTank(SqlConnection connection)
        {
            // Hämta värden från textboxarna för att använda i SQL-insertqueryn
            double mainGunCaliber = double.Parse(this.tCal.Text);
            int crewCount = int.Parse(this.tCrew.Text);
            int enginePower = int.Parse(this.tPower.Text);
            int amountBuilt = int.Parse(this.tAmount.Text);
            int priceUSD = int.Parse(this.tPrice.Text);
            int productionStartYear = int.Parse(this.tProdStart.Text);
            int? productionEndYear = this.tProdEnd.Text.ToLower() == "still in production" ? (int?)null : int.Parse(this.tProdEnd.Text);

            // SQL-query för att lägga till en ny tank i databasen
            string insertQuery = "INSERT INTO Tanks (TankName, MainGunCaliber, CrewCount, EnginePower, CountryOfOrigin, AmountBuilt, PriceUSD, ProductionStartYear, ProductionEndYear) " +
                                 "VALUES (@TankName, @MainGunCaliber, @CrewCount, @EnginePower, @CountryOfOrigin, @AmountBuilt, @PriceUSD, @ProductionStartYear, @ProductionEndYear)";

            // Skapa en SqlCommand för att utföra SQL-insertionen
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Lägg till parametrar för att undvika SQL Injection och ange värden från textboxarna
                command.Parameters.AddWithValue("@TankName", this.tName.Text);
                command.Parameters.AddWithValue("@MainGunCaliber", mainGunCaliber);
                command.Parameters.AddWithValue("@CrewCount", crewCount);
                command.Parameters.AddWithValue("@EnginePower", enginePower);
                command.Parameters.AddWithValue("@CountryOfOrigin", this.tCountry.Text);
                command.Parameters.AddWithValue("@AmountBuilt", amountBuilt);
                command.Parameters.AddWithValue("@PriceUSD", priceUSD);
                command.Parameters.AddWithValue("@ProductionStartYear", productionStartYear);
                command.Parameters.AddWithValue("@ProductionEndYear", productionEndYear ?? (object)DBNull.Value);

                command.ExecuteNonQuery(); // Utför SQL-kommandot för att lägga till en ny tank
            }
        }




    }
}
