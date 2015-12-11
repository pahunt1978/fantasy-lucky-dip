using System;
using System.Windows.Forms;
using NodaTime;

namespace FantasyLuckyDip.Testbed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var test = new ZonedDateTime(Instant.FromDateTimeOffset(this.dateTimePicker1.Value), DateTimeZoneProviders.Tzdb["Europe/London"]);
            var a = test.WithZone(DateTimeZoneProviders.Tzdb["Asia/Shanghai"]);
            this.textBox1.Text = a.ToInstant().Ticks.ToString();
        }
    }
}
