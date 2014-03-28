using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Editor;

namespace AddressEditor
{
    public partial class frmBulkUpdate : Form
    {
        public frmBulkUpdate()
        {
            InitializeComponent();
        }

        private void frmBulkUpdate_Load(object sender, EventArgs e)
        {


        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IMxDocument pMxd = ArcMap.Document;
                IMap pMap = pMxd.FocusMap;
                IEnumLayer pELay = pMap.Layers;
                ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
                uid.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}"; // Example: "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}" = IGeoFeatureLayer

                IEnumLayer enumLayer = pMap.get_Layers(((ESRI.ArcGIS.esriSystem.UID)(uid)), true); // Explicit Cast 
                enumLayer.Reset();
                ILayer layer = enumLayer.Next();
                while (!(layer == null))
                {
                  // TODO - Implement your code here...
                    if (layer.Name=="AddressPoints")
                    {
                        IFeatureLayer pFL = (IFeatureLayer)layer;
                        IFeatureSelection pFSel = (IFeatureSelection)pFL;
                        ISelectionSet pSSelSet = pFSel.SelectionSet;
                        //ICursor pCur;
                        IEnumIDs pEnumIDs = pSSelSet.IDs;
                        int ID = pEnumIDs.Next();
                        string strIDs = "";
                        while (ID != -1 )
                        {
                            strIDs += ID + ",";
                            ID = pEnumIDs.Next();
                        }
                        char[] charsToTrim = {','};
                        strIDs.TrimEnd(',');
                        string ids = strIDs.Substring(0, strIDs.LastIndexOf(","));
                        IQueryFilter pQF = new QueryFilter();
                        pQF.WhereClause = "OBJECTID in (" + ids + ")";
                        //IObjectClassInfo2 pObjCI = (IObjectClassInfo2)pFL.FeatureClass;
                        IEditor theEditor = ArcMap.Editor;
                        theEditor.StartOperation();
                        IFeatureCursor pUCur = pFL.FeatureClass.Update(pQF, true);
                        
                        
                        IFeature pFeat = pUCur.NextFeature();
                        while (pFeat != null)
                        {
                            pFeat.set_Value(pFeat.Fields.FindField("Position"), ucPosition1.cboLocation.SelectedValue);
                            pUCur.UpdateFeature(pFeat);
                            pFeat = pUCur.NextFeature();
 
                        }
                        theEditor.StopOperation("Selected point update");
                        IEditor3 pedit = (IEditor3)theEditor;
                    }
                  layer = enumLayer.Next();
                }
                this.Close();

            }
            catch (Exception ex)
            {           
                MessageBox.Show(ex.Message);
            }
        }
    }
}
