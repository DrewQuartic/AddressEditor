using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.ArcMap;
using ESRI.ArcGIS.Framework;

namespace AddressEditor
{
    /// <summary>
    /// AddressPointEditorExt class implementing custom ESRI Editor Extension functionalities.
    /// </summary>
    public class AddressPointEditorExt : ESRI.ArcGIS.Desktop.AddIns.Extension
    {
        public AddressPointEditorExt()
        {
        }

        protected override void OnStartup()
        {
            IEditor theEditor = ArcMap.Editor;
            Events.OnChangeFeature += new IEditEvents_OnChangeFeatureEventHandler(Events_OnChangeFeature);
            Events.OnStopEditing += new IEditEvents_OnStopEditingEventHandler(Events_OnStopEditing);
            Events.OnStartEditing += new IEditEvents_OnStartEditingEventHandler(Events_OnStartEditing);
            
        }

        void Events_OnStopEditing(bool save)
        {
            //throw new NotImplementedException();
        }

        protected override void OnShutdown()
        {
        }

        #region Editor Events

        #region Shortcut properties to the various editor event interfaces
        private IEditEvents_Event Events
        {
            get { return ArcMap.Editor as IEditEvents_Event; }
        }
        private IEditEvents2_Event Events2
        {
            get { return ArcMap.Editor as IEditEvents2_Event; }
        }
        private IEditEvents3_Event Events3
        {
            get { return ArcMap.Editor as IEditEvents3_Event; }
        }
        private IEditEvents4_Event Events4
        {
            get { return ArcMap.Editor as IEditEvents4_Event; }
        }
        #endregion

        void WireEditorEvents()
        {
            //
            //  TODO: Sample code demonstrating editor event wiring
            //
            Events.OnCurrentTaskChanged += delegate
            {
                if (ArcMap.Editor.CurrentTask != null)
                    System.Diagnostics.Debug.WriteLine(ArcMap.Editor.CurrentTask.Name);
            };
            Events2.BeforeStopEditing += delegate(bool save) { OnBeforeStopEditing(save); };

        }

        void Events_OnStartEditing()
        {
            
        }

        void Events_OnChangeFeature(ESRI.ArcGIS.Geodatabase.IObject obj)
        {
            frmOnChange frmOnChange = new frmOnChange();
            frmOnChange.obj = obj;
            frmOnChange.ShowDialog();
        }

        void OnBeforeStopEditing(bool save)
        {
        }
        #endregion

        #region"Set Tool Active in ToolBar"
        // ArcGIS Snippet Title:
        // Set Tool Active in ToolBar
        // 
        // Long Description:
        // Find a specific tool (or command) in a toolbar and set it to be active.
        // 
        // Add the following references to the project:
        // ESRI.ArcGIS.Framework
        // ESRI.ArcGIS.System
        // 
        // Intended ArcGIS Products for this snippet:
        // ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
        // 
        // Applicable ArcGIS Product Versions:
        // 9.2
        // 9.3
        // 9.3.1
        // 10.0
        // 
        // Required ArcGIS Extensions:
        // (NONE)
        // 
        // Notes:
        // This snippet is intended to be inserted at the base level of a Class.
        // It is not intended to be nested within an existing Method.
        // 

        ///<summary>Find a specific tool (or command) in a toolbar and set it to be active.</summary>
        ///  
        ///<param name="application">An IApplication interface.</param>
        ///<param name="toolName">A System.String that is the name of the command to return. Example: "esriFramework.HelpContentsCommand"</param>
        ///   
        ///<remarks>Refer to the EDN document http://edndoc.esri.com/arcobjects/9.1/default.asp?URL=/arcobjects/9.1/ArcGISDevHelp/TechnicalDocuments/Guids/ArcMapIds.htm for a listing of available CLSID's and ProgID's that can be used as the toolName parameter.</remarks>
        public void SetToolActiveInToolBar(ESRI.ArcGIS.Framework.IApplication application, System.String toolName)
        {
            ESRI.ArcGIS.Framework.ICommandBars commandBars = application.Document.CommandBars;
            ESRI.ArcGIS.esriSystem.UID commandID = new ESRI.ArcGIS.esriSystem.UIDClass();
            commandID.Value = toolName; // example: "esriArcMapUI.ZoomInTool";
            ESRI.ArcGIS.Framework.ICommandItem commandItem = commandBars.Find(commandID, false, false);

            if (commandItem != null)
                if (commandItem.Type == ESRI.ArcGIS.Framework.esriCommandTypes.esriCmdTypeUIButtonCtrl)
	            {
                    ESRI.ArcGIS.Framework.Button pContr = (Button)commandItem;

	            }
                
                application.CurrentTool = commandItem;
        }
        #endregion

    }

}
