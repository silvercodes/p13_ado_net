
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace _03_provider_factory
{
    public partial class Form1 : Form
    {
        DbProviderFactory factory;
        DbConnection? conn;

        public Form1()
        {
            InitializeComponent();

            RegisterFactories();
            FillProvidersCombobox();
        }

        private void RegisterFactories()
        {
            DbProviderFactories.RegisterFactory("express", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("mysql", MySqlClientFactory.Instance);
            // DbProviderFactories.RegisterFactory("pg", NpgsqlFactory.Instance);
        }

        private void FillProvidersCombobox()
        {
            IEnumerable<string> providerNames = DbProviderFactories.GetProviderInvariantNames();

            foreach (string pn in providerNames)
                cbxProvider.Items.Add(pn);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DbDataAdapter? adapter = factory.CreateDataAdapter();

            DbCommand? selectCmd = factory.CreateCommand();
            selectCmd.Connection = conn;
            selectCmd.CommandText = txtQuery.Text;

            adapter.SelectCommand = selectCmd;

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dgwMain.DataSource = dt;
        }

        private void cbxProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? providerName = cbxProvider.SelectedItem.ToString();

            if (providerName is null)
                return;                 // TODO: throw

            factory = DbProviderFactories.GetFactory(providerName);

            conn = factory.CreateConnection();

            if (conn is null)
                return;                 // TODO: throw

            string connString = ConfigurationManager
                .ConnectionStrings[providerName]
                .ConnectionString;

            lblConnString.Text = connString;

            conn.ConnectionString = connString;
        }
    }
}