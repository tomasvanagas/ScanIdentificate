using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace NetworkScanner
{
    /// <summary>
    /// Interaction logic for Analyzer.xaml
    /// </summary>
    public partial class Analyzer : Window
    {
        public List<Result> results = new List<Result>();
        //MainWindow mainWindow;

        public Analyzer(MainWindow mainWindow)
        {
            //this.mainWindow = mainWindow;
            InitializeComponent();



            JObject JsonAnalysis = JObject.Parse(File.ReadAllText("Analysis20181107155050.json"));

            results.Clear();

            foreach(var key in JsonAnalysis)
            {
                bool found = false;
                foreach(Identifier identificator in mainWindow.value)
                {
                    if(key.Value.ToString().Contains(identificator.Identificator))
                    {
                        results.Add(new Result {
                            IpAddress = key.Key.Split('/')[2].Split(':')[0],
                            Port = key.Key.Split('/')[2].Split(':')[1],
                            Name = identificator.Name
                        });
                        found = true;
                        break;
                    }
                }

                if(!found)
                {
                    results.Add(new Result { IpAddress = key.Key, Name = "Not Found." });
                }
            }

            analysisDataGrid.ItemsSource = results;
        }
    }

    public class Result
    {
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string Name { get; set; }
    }

}
