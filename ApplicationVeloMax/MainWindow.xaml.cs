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
using System.Data;
using ApplicationVeloMax.Models;
using ApplicationVeloMax.Communication;

namespace ApplicationVeloMax
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataAccess cs = new DataAccess("SERVER=84.102.235.128;PORT=3306;DATABASE=velomax;UID=RemoteAdmin;PASSWORD=Password@123");
            DataAccess.GetAllGrandeurs();
            DataAccess.GetAllLigneProduits();
            DataAccess.GetAllModels();
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
                }
            }

            Console.WriteLine("Done");

            reader.Close();
            cmd.Dispose();
        }
    }
}
