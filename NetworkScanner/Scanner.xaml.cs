using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetworkScanner
{
    /// <summary>
    /// Interaction logic for Scanner.xaml
    /// </summary>
    public partial class Scanner : Window
    {
        List<Port> ports;
        public Scanner(int octet1, int octet2, int octet3min, int octet3max, int octet4min, int octet4max, List<Port> ports)
        {
            InitializeComponent();
            this.ports = ports; 
                
            Task task = new Task(delegate { Scan(octet1, octet2, octet3min, octet3max, octet4min, octet4max); });
            task.Start();
        }

        private void Scan(int octet1, int octet2, int octet3min, int octet3max, int octet4min, int octet4max)
        {
            JObject jObject = new JObject();

            foreach (Port portObj in ports)
            {
                int port = portObj.PortNumber;
                for (int octet3 = octet3min; octet3 <= octet3max; octet3++)
                {
                    Parallel.For(octet4min, octet4max, octet4 => {
                        string text = "";
                        string html = string.Empty;
                        string url = $"http://{octet1}.{octet2}.{octet3}.{octet4}:{port}/";

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Timeout = 3000;
                        request.AutomaticDecompression = DecompressionMethods.GZip;
                        bool caught = false;
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            using (Stream stream = response.GetResponseStream())
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                html = reader.ReadToEnd();
                            }
                        }
                        catch
                        {
                            caught = true;
                        }

                        if (!caught)
                        {
                            text = text + $"----------------------- {url} -----------------------------------\n";
                            text = text + html + "\n";

                            Dispatcher.BeginInvoke((Action)(() => scanOut.AppendText(text)));
                            Dispatcher.BeginInvoke((Action)(() => scanOut.Focus()));
                            Dispatcher.BeginInvoke((Action)(() => scanOut.SelectionStart = scanOut.Text.Length));
                            jObject.Add(url, html);
                        }

                        Thread.Sleep(10);
                    });
                }
            }
            

            string filename = "Analysis" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "") + ".json";
            File.WriteAllText(filename, jObject.ToString());
            MessageBox.Show($"Skanavimas baigtas.\nDuomenys surašyti {filename}");
        }
    }
}
