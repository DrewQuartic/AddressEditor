using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressEditor
{
    public class AddressEdit : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        public AddressEdit()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
