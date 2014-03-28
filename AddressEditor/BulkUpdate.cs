using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;

namespace AddressEditor 
{
    public class BulkUpdate : ESRI.ArcGIS.Desktop.AddIns.Button 
    {
        public BulkUpdate()
        {
            this.Enabled = false;
        }


        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            //ArcMap.Application.CurrentTool = null;
            if (ArcMap.Editor.EditState == ESRI.ArcGIS.Editor.esriEditState.esriStateEditing)
            {
                if (ArcMap.Editor.SelectionCount > 0)
                {
                    IEnumFeature pEnumFeat = ArcMap.Editor.EditSelection;
                    IFeature pFeat = pEnumFeat.Next();
                    while ((pFeat != null))
                    {
                        if (pFeat.Class.AliasName == "T.AddressPoint")
                        {
                            frmBulkUpdate frmbulkupdate = new frmBulkUpdate();
                            frmbulkupdate.ShowDialog();
                            break;   

                        }
                        pFeat = pEnumFeat.Next();
                    }
                }
            }

        }

        //protected override bool Enabled()
        //{
            
        //    bool state = false;
        //    if (ArcMap.Editor.EditState == ESRI.ArcGIS.Editor.esriEditState.esriStateEditing)
        //    {
        //        if (ArcMap.Editor.SelectionCount > 0)
        //        {
        //            IEnumFeature pEnumFeat = ArcMap.Editor.EditSelection;
        //            IFeature pFeat = pEnumFeat.Next();
        //            while ((pFeat != null))
        //            {
        //                if (pFeat.Class.AliasName == "T.AddressPoint")
        //                {
        //                    state = true;

        //                }
        //                pFeat = pEnumFeat.Next();
        //            }
        //        }
        //    }
        //    return state;

        //}

        protected override void OnUpdate()
        {
            //Enabled();
            this.Enabled = false;
            if (ArcMap.Editor.EditState == ESRI.ArcGIS.Editor.esriEditState.esriStateEditing)
            {
                if (ArcMap.Editor.SelectionCount > 0)
                {
                    IEnumFeature pEnumFeat = ArcMap.Editor.EditSelection;
                    IFeature pFeat = pEnumFeat.Next();
                    while ((pFeat != null))
                    {
                        if (pFeat.Class.AliasName == "T.AddressPoint")
                        {
                            this.Enabled = true;

                        }
                        pFeat = pEnumFeat.Next();
                    }
                }
            }
        }
    }

}
