using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _05_async_app
{
    public partial class Form1 : Form
    {
        private string connString = string.Empty;
        private SqlConnection? conn;
        private DataTable dt;


        public Form1()
        {
            InitializeComponent();

            connString = ConfigurationManager
                .ConnectionStrings["localdb"]
                .ConnectionString;

            conn = new SqlConnection(connString);

            dt = new DataTable();
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn is null)
                    throw new Exception("Invalid connection...");

                // conn.Open();                                        // Blocking call
                await conn.OpenAsync();

                string query = $"WAITFOR DELAY '00:00:05'; {txtQuery.Text}";

                SqlCommand cmd = new SqlCommand(query, conn);

                // using SqlDataReader reader = cmd.ExecuteReader();   // Blocking call
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                // dt.Load(reader);                                    // Blocking call
                await LoadToTableAsync(reader);

                dgwMain.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn is not null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private Task LoadToTableAsync(SqlDataReader reader)
        {
            return Task.Run(() => dt.Load(reader));
        }
    }
}