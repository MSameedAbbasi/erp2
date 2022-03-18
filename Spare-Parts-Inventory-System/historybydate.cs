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
using System.Configuration;
/*using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
*/

namespace TwenstyFirstJan
{
    public partial class historybydate : Form
    {
        public historybydate()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Navigation n3 = new Navigation();
            this.Hide();
            n3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = "Server = tcp:masamual.database.windows.net,1433; Initial Catalog = alidb; Persist Security Info = False; User ID = ali; Password = Adminaccount@101; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand();


                if (String.IsNullOrEmpty(textBox4.Text))
                {
                    cmd = new SqlCommand("select p.companyName as 'Company' , p.partName as 'Part Name', p.modelName as 'Model Name' , p.price*s.tquantity as [total price] , s.tquantity from [dbo].[product_table] as p   join (select sum(sold_quantity) as [tquantity], Id ,sold_date from [dbo].[log_table] group by Id , sold_date ) as s on p.productId = s.Id  where p.partName like '%" + textBox2.Text.ToString() + "%' and p.companyName like '%" + textBox1.Text.ToString() + "%' and p.modelName like '%" + textBox3.Text.ToString() + "%' and s.sold_date between '" + dateTimePicker1.Value.Date.ToString() + "' and '" + dateTimePicker2.Value.Date.ToString() + "';", cnn);

                }
                else
                {
                    cmd = new SqlCommand("select p.companyName as 'Company' , p.partName as 'Part Name', p.modelName as 'Model Name' , p.price*s.tquantity as [total price] , s.tquantity from [dbo].[product_table] as p   join (select sum(sold_quantity) as [tquantity], Id ,invoice from [dbo].[log_table] group by Id ,invoice ) as s on p.productId = s.Id  where p.partName like '%" + textBox2.Text.ToString() + "%' and p.companyName like '%" + textBox1.Text.ToString() + "%' and p.modelName like '%" + textBox3.Text.ToString() + "%' and s.invoice = @inv ;", cnn);
                    int invvalue = int.Parse(textBox4.Text);
                    cmd.Parameters.AddWithValue("@inv", invvalue);

                }
                SqlDataAdapter sqd = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sqd.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Retry");
            }
        }

        private void historybydate_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = dateTimePicker1.MinDate;

            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        /*
        private void populate_Table(object sender, RoutedEventArgs e)
        {   // This function on_click populates the datagrid named JumpTable
            // this.JumpTable.ItemsSource = null; // Clears the current datagrid before getting new data
            // Pulls in the 2d table from the client sheet
            IList<IList<Object>> client_sheet = Get(SetCredentials(), "$spreadsheetIdPlaceholder", "Client!A2:AY");
            // List to set the properties that will be populated in the datagrid
            List<Object> entries = new List<Object>();


            // [Status] [Functional]
            for (int i = 0; i < 30; i++) // Using 30 as the count for testing
            {
                entries.Add(new
                {
                    A = client_sheet[i][0],
                    B = client_sheet[i][1],
                    C = client_sheet[i][2],
                    D = client_sheet[i][3],
                    E = client_sheet[i][4],
                    F = client_sheet[i][5],
                    G = client_sheet[i][6],
                    H = client_sheet[i][7],
                    I = client_sheet[i][8],
                    J = client_sheet[i][9],
                    K = client_sheet[i][10],
                    L = client_sheet[i][11],
                    M = client_sheet[i][12],
                    N = client_sheet[i][13],
                    O = client_sheet[i][14],
                    P = client_sheet[i][15],
                    Q = client_sheet[i][16],
                    R = client_sheet[i][17],
                    S = client_sheet[i][18],
                    T = client_sheet[i][19],
                    U = client_sheet[i][20],
                    V = client_sheet[i][21],
                    W = client_sheet[i][22],
                    X = client_sheet[i][22],
                    Y = client_sheet[i][23],
                    Z = client_sheet[i][24],
                    AA = client_sheet[i][25],
                    AB = client_sheet[i][26],
                });
            }
            // MessageBox.Show(string.Format("{0}", client_sheet[0].Count));

            this.JumpTable.ItemsSource = entries; // Binds the entries to the datagrid
        }
        */
    }
}
