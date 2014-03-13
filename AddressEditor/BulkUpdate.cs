using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressEditor
{
    public class BulkUpdate : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public BulkUpdate()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            //ArcMap.Application.CurrentTool = null;
            frmBulkUpdate frmbulkupdate = new frmBulkUpdate();
            frmbulkupdate.ShowDialog();
            
            
        }



    }

}
