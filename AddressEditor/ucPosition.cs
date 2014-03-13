using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AddressEditor
{
    public partial class ucPosition : UserControl
    {
        public ucPosition()
        {
            InitializeComponent();
        }

        protected void ucPosition_Load(object sender, EventArgs e)
        {
            try
            {
                #region set the location key/value pairs
                NameURLPair[] urls = new NameURLPair[5];
                urls[0] = new NameURLPair();
                urls[0].Name = "Structure";
                urls[0].URL = "S";

                urls[1] = new NameURLPair();
                urls[1].Name = "Entrance";
                urls[1].URL = "E";

                urls[2] = new NameURLPair();
                urls[2].Name = "Centroid";
                urls[2].URL = "C";

                urls[3] = new NameURLPair();
                urls[3].Name = "Unknown";
                urls[3].URL = "U";

                urls[4] = new NameURLPair();
                urls[4].Name = "Review";
                urls[4].URL = "R";

                #endregion
                cboLocation.DisplayMember = "Name";
                cboLocation.ValueMember = "URL";

                cboLocation.DataSource = urls;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private class NameURLPair
        {
            private string m_name;
            private string m_url;
            public NameURLPair() { }
            public string Name
            {
                get { return m_name; }
                set { m_name = value; }
            }
            public string URL
            {
                get { return m_url; }
                set { m_url = value; }
            }
        }
    }
}
