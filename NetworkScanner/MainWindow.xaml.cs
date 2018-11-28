using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetworkScanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum protocolEnum
        {
            HTTP_HTTPS,
            SSH
        };


        public List<Identifier> value = new List<Identifier>();
        readonly string IdentifiersPath = "Identifiers.json";
        List<Port> ports;

        public MainWindow()
        {
            if (File.Exists(IdentifiersPath))
            {
                value = JsonConvert.DeserializeObject<List<Identifier>>(File.ReadAllText(IdentifiersPath));
            }

            InitializeComponent();
            ports = new List<Port>
            {
                new Port { PortNumber = 80 },
                new Port { PortNumber = 443 },
                new Port { PortNumber = 8080 }
            };
            portsToScanDataGrid.ItemsSource = ports;



            itemsDataGrid.ItemsSource = value;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllText(IdentifiersPath, JsonConvert.SerializeObject(value, Formatting.None));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Scanner scanner = new Scanner(Convert.ToInt32(octet1.Text), 
                Convert.ToInt32(octet2.Text), 
                Convert.ToInt32(octet3min.Text), 
                Convert.ToInt32(octet3max.Text), 
                Convert.ToInt32(octet4min.Text), 
                Convert.ToInt32(octet4max.Text),
                ports);
            scanner.ShowDialog();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Analyzer analyzer = new Analyzer(this);
            analyzer.ShowDialog();
        }
    }


    public class Identifier
    {
        public string Name { get; set; }
        public string Identificator { get; set; }
    }

    public class Port
    {
        public int PortNumber { get; set; }
    }
}
