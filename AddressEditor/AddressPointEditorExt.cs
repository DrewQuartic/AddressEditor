using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.ArcMap;

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

    }

}
