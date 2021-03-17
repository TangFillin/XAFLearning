using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRMDemo.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ClearViewController : ViewController
    {
        public ClearViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ClearFieldAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (PropertyEditor item in ((DetailView)View).GetItems<PropertyEditor>())
            {
                if (item.AllowEdit)
                {
                    try
                    {
                        item.PropertyValue = null;
                    }
                    catch (IntermediateMemberIsNullException)
                    {
                        item.Refresh();
                    }

                }
            }
        }

        private void ClearViewController_Activated(object sender, EventArgs e)
        {
            ClearFieldAction.Enabled.SetItemValue("EditMode", ((DetailView)View).ViewEditMode == ViewEditMode.Edit);
            ((DetailView)View).ViewEditModeChanged +=
               new EventHandler<EventArgs>(ClearFieldController_ViewEditModeChanged);

        }
        void ClearFieldController_ViewEditModeChanged(object sender, EventArgs e)
        {
            ClearFieldAction.Enabled.SetItemValue("EditMode",
               ((DetailView)View).ViewEditMode == ViewEditMode.Edit);

        }
    }
}
