using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;

namespace AddressEditor
{
    public partial class frmOnChange : Form
    {
        IObject m_pFeat ;
        public frmOnChange()
        {
            InitializeComponent();
        }


        public IObject obj { get {return m_pFeat;}  set{m_pFeat = value;}  }

        private void btnApply_Click(object sender, EventArgs e)
        {
            m_pFeat.set_Value(m_pFeat.Fields.FindField("Position"), ucPosition1.cboLocation.SelectedValue);
            this.Close();
        }

        private void frmOnChange_Load(object sender, EventArgs e)
        {

        }

        
    }
}
