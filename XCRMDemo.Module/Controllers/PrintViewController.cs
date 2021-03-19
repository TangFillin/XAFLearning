using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static XCRMDemo.Module.Utils.CustomEnums;

namespace XCRMDemo.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public abstract partial class PrintViewController : ViewController
    {
        public PrintViewController()
        {
            InitializeComponent();
            this.TargetViewType = ViewType.ListView;
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            btn_print.Items.Clear();
            btn_printPreview.Items.Clear();
            try
            {
                IList<ReportDataV2> reportDatas = ObjectSpace.GetObjects<ReportDataV2>(new BinaryOperator("DataTypeName", View.ObjectTypeInfo.FullName), false);

                if (reportDatas != null)
                {
                    foreach (ReportDataV2 reportdata in reportDatas)
                    {
                        string name = reportdata.DisplayName;
                        ChoiceActionItem item = new ChoiceActionItem(name, reportdata);

                        btn_print.Items.Add(item);
                        btn_printPreview.Items.Add(item);

                    }

                    btn_print.Execute += Btn_print_Execute;
                    btn_printPreview.Execute += Btn_printPreview_Execute;
                }

            }
            catch (Exception)
            {

                throw;
            }

            // Perform various tasks depending on the target View.
        }

        private void Btn_printPreview_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {

        }

        private void Btn_print_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            ReportDataV2 rd = (ReportDataV2)e.SelectedChoiceActionItem.Data;
            PrintReport(rd, e.SelectedChoiceActionItem);
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

        protected abstract void PrintReport(IReportDataV2 reportData, BillPrintType billPrintType = BillPrintType.打印);


        protected abstract void PrintReport(IReportDataV2 reportData, ChoiceActionItem dataItem, BillPrintType billPrintType = BillPrintType.打印);
    }
}
