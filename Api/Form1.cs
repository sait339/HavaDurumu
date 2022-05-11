using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;

namespace Api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://weatherapi-com.p.rapidapi.com/current.json?q="+sehir);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "weatherapi-com.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "2fe732f7f7msheb14c799a0a6ac5p14554cjsnf6d25b5654ab");
            IRestResponse response = client.Execute(request);
            dynamic js = JsonConvert.DeserializeObject(response.Content);
            string durum = js.current.condition["text"];
            string derece = js.current["temp_c"];
            string nem = js.current["humidity"];
            string ruzgaryon = js.current["wind_dir"];
            string ruzgarhiz = js.current["wind_kph"];
            label2.Text = sehir;
            label5.Text = "NEM : %" + nem;
            if (ruzgaryon == "N") { label6.Text = "RÜZGAR YÖNÜ : Kuzey"; }
            else if (ruzgaryon == "E") { label6.Text = "RÜZGAR YÖNÜ : Doğu"; }
            else if (ruzgaryon == "S") { label6.Text = "RÜZGAR YÖNÜ : Güney"; }
            else if (ruzgaryon == "W") { label6.Text = "RÜZGAR YÖNÜ : Batı"; }
            else if (ruzgaryon == "NE") { label6.Text = "RÜZGAR YÖNÜ : Kuzeydoğu"; }
            else if (ruzgaryon == "SE") { label6.Text = "RÜZGAR YÖNÜ : Güneydoğu"; }
            else if (ruzgaryon == "SW") { label6.Text = "RÜZGAR YÖNÜ : Güneybatı"; }
            else if (ruzgaryon == "NW") { label6.Text = "RÜZGAR YÖNÜ : Kuzeybatı"; }
            else if (ruzgaryon == "NNE") { label6.Text = "RÜZGAR : Yıldız-Poyraz"; }
            else if (ruzgaryon == "ENE") { label6.Text = "RÜZGAR : Gündoğusu-Poyraz"; }
            else if (ruzgaryon == "ESE") { label6.Text = "RÜZGAR : Gündoğusu-Keşişleme"; }
            else if (ruzgaryon == "SSE") { label6.Text = "RÜZGAR : Kıble-Keşişleme"; }
            else if (ruzgaryon == "SSW") { label6.Text = "RÜZGAR : Kıble-Lodos"; }
            else if (ruzgaryon == "WSW") { label6.Text = "RÜZGAR : Batı-Lodos"; }
            else if (ruzgaryon == "WNW") { label6.Text = "RÜZGAR : Batı-Karayel"; }
            else if (ruzgaryon == "NNW") { label6.Text = "RÜZGAR : Yıldız-Karayel"; }
            else { }
            label7.Text = "RÜZGAR HIZI : " + ruzgarhiz+ " km/s";
            if (durum == "Sunny") { label3.Text = "Güneşli " + derece + "°"; pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\havadrm\\sunny.png"); }
            else if (durum == "Rain") { label3.Text = "Yağmurlu " + derece + "°"; pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\havadrm\\rain_light.png"); }
            else if (durum == "Partly cloudy") { label3.Text = "Parçalı Bulutlu " + derece + "°"; pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\havadrm\\sunny_s_cloudy.png"); }
            else if (durum == "Cloudy") { label3.Text = "Bulutlu " + derece + "°"; pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\havadrm\\partly_cloudy.png"); }
            else if (durum == "Mist" || durum == "Fog") { label3.Text = "Sisli " + derece + "°"; pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\havadrm\\mist.png"); }
            else if (durum == "Overcast") { label3.Text = "Çok Bulutlu " + derece + "°"; pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\havadrm\\cloudy.png"); }
            else { label3.Text = durum; }


        }
        string sehir;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehir = comboBox1.Text;
            button1.Text = sehir + " Hava Durumu Öğren";
        }
    }
}
