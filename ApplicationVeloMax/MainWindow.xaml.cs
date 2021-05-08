using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace ApplicationVeloMax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Basic Initialization
            MySqlConnection cnn = null;
            try
            {
                string cs = "SERVER=localhost;PORT=3306;DATABASE=velomax;UID=RemoteAdmin;PASSWORD=Password@123";
                cnn = new MySqlConnection(cs);
                cnn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection Error : " + e.ToString());
                return;
            }
            MessageBox.Show("Connected successfully");
            #endregion



            Console.ReadKey();
        }

        static void sqlRequest(MySqlConnection cnn, string request, List<MySqlParameter> parameters = null)
        {
            var cmd = new MySqlCommand(request, cnn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) // Récupère les données
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string data = "";
                    if (!reader.IsDBNull(i))
                    {
                        data = reader.GetString(i);
                    }
                    Console.WriteLine(data);
                    if (i != reader.FieldCount) Console.Write(" ; ");
                    else Console.WriteLine();
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine("Done");

            reader.Close();
            cmd.Dispose();
        }
    }
}
