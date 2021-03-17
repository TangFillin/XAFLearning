using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
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
using XCRMDemo.Module.BusinessObjects;

namespace XCRMDemo.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FindByCategoryViewController : ViewController
    {
        public FindByCategoryViewController()
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

        private void FindByCategoryViewController_Activated(object sender, EventArgs e)
        {
            FindByCategory.Active.SetItemValue("ObjectType", View.ObjectTypeInfo.Type == typeof(Customer));
        }

        private void FindByCategory_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {

            IObjectSpace objectSpace = Application.CreateObjectSpace();
            string paramValue = e.ParameterCurrentValue as string;
            if (!string.IsNullOrEmpty(paramValue))
            {
                paramValue = "%" + paramValue + "%";
            }

            object obj = objectSpace.FindObject(View.ObjectTypeInfo.Type, new BinaryOperator("Name", paramValue, BinaryOperatorType.Like));

            if (obj != null)
            {
                e.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpace, obj);
            }
        }
    }
}
