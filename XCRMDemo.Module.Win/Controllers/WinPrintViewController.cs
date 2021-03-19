using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Linq;
using XCRMDemo.Module.BusinessObjects;
using XCRMDemo.Module.Controllers;
using XCRMDemo.Module.Utils;

namespace XCRMDemo.Module.Win.Controllers
{
    public class WinPrintViewController : PrintViewController
    {



        protected override void PrintReport(IReportDataV2 reportData, CustomEnums.BillPrintType billPrintType = CustomEnums.BillPrintType.打印)
        {
            XtraReport report = ReportDataProvider.ReportsStorage.LoadReport(reportData);

            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);

            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
            {
                CriteriaOperator criteriaOperator = ((BaseObjectSpace)ObjectSpace).GetObjectsCriteria(((ObjectView)View).ObjectTypeInfo, View.SelectedObjects);
                reportsModule.ReportsDataSourceHelper.SetupReportDataSource(report, criteriaOperator, true, null, false);

                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report);
                if (billPrintType == CustomEnums.BillPrintType.预览)
                {
                    report.ShowPreview();
                }
                else
                {
                    report.PrintingSystem.ShowMarginsWarning = false;
                    report.PrintDialog();
                }
            }
        }

        ListView lv;
        DetailView dv;
        private IObjectSpace ios = null;

        private string PrintObjectFullName;
        private string PrintObjectName;

        protected override void PrintReport(IReportDataV2 reportData, ChoiceActionItem dataItem, CustomEnums.BillPrintType billPrintType = CustomEnums.BillPrintType.打印)
        {
            XtraReport report = ReportDataProvider.ReportsStorage.LoadReport(reportData);
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);

            PrintObjectName = reportData.DataType.Name;
            PrintObjectFullName = reportData.DataType.FullName;
            report.PrintingSystem.ShowMarginsWarning = false;
            if (View is ListView)
            {
                lv = (DevExpress.ExpressApp.ListView)View;
                if (lv.SelectedObjects.Count > 2000)
                {
                    throw new Exception("最多支持打印2000张单据,请分批次打印!");
                }
            }
            //Printaction=reportData.ParametersObjectType.
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
            {
                //过滤选中的行，设in place 可取消过滤
                CriteriaOperator objectsCriteria = ((BaseObjectSpace)ObjectSpace).GetObjectsCriteria(((ObjectView)View).ObjectTypeInfo,
                    View.SelectedObjects);
                reportsModule.ReportsDataSourceHelper.SetupReportDataSource(report, objectsCriteria, true, null, false);
                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report);
                //report.PrintProgress += Report_PrintProgress;
                if (billPrintType == CustomEnums.BillPrintType.预览)
                    report.ShowPreview();
                else
                {
                    report.PrintingSystem.ShowMarginsWarning = false;
                    report.PrintDialog();
                }
            }
            //switch (PrintObjectFullName)
            //{
            //    case "JGSoft.MES.Module.BusinessObjects.Manufacture.pm_manubill_requirementbills":
            //        {

            //            if (View is ListView)
            //            {
            //                lv = (DevExpress.ExpressApp.ListView)View;
            //                if (lv != null)
            //                {
            //                    ios = ObjectSpace;
            //                    Guid guid = Guid.NewGuid();
            //                    string printbillno = "L" + GuidToLongID(guid).ToString();
            //                    foreach (var item in lv.SelectedObjects.Cast<Customer>().ToList())
            //                    {
            //                        if (item.PrintCount == 0)
            //                        {
            //                            item.printbillno = printbillno;
            //                        }
            //                        item.PrintCount++;
            //                        item.Save();
            //                    }
            //                    ios.CommitChanges();
            //                }
            //            }
            //            if (View is DetailView)
            //            {
            //                dv = (DevExpress.ExpressApp.DetailView)View;
            //                if (dv != null)
            //                {
            //                    ios = ObjectSpace;
            //                    Guid guid = Guid.NewGuid();
            //                    string printbillno = "L" + GuidToLongID(guid).ToString();
            //                    var item = (Contact)dv.CurrentObject;
            //                    if ((item != null) && (item.PrintCount == 0))
            //                    {
            //                        item.printbillno = printbillno;
            //                    }
            //                    item.PrintCount++;
            //                    item.Save();
            //                    ios.CommitChanges();
            //                }
            //            }
            //        }
            //        break;
            //    case "JGSoft.MES.Module.BusinessObjects.Base.Public.Pm_Rpt_StationComplete":
            //        {

            //            if (View is ListView)
            //            {
            //                lv = (DevExpress.ExpressApp.ListView)View;
            //                if (lv != null)
            //                {
            //                    ios = ObjectSpace;
            //                    Guid guid = Guid.NewGuid();
            //                    string printbillno = "L" + GuidToLongID(guid).ToString();
            //                    foreach (var item in lv.SelectedObjects.Cast<SalesRegion>().ToList())
            //                    {
            //                        item.PrintCount++;
            //                        item.Save();
            //                    }
            //                    ios.CommitChanges();
            //                }
            //            }
            //            if (View is DetailView)
            //            {
            //                dv = (DevExpress.ExpressApp.DetailView)View;
            //                if (dv != null)
            //                {
            //                    ios = ObjectSpace;
            //                    Guid guid = Guid.NewGuid();
            //                    string printbillno = "L" + GuidToLongID(guid).ToString();
            //                    var item = (Pm_Rpt_StationComplete)dv.CurrentObject;
            //                    item.PrintCount++;
            //                    item.Save();
            //                    ios.CommitChanges();
            //                }
            //            }
            //        }
            //        break;
            //}
        }

        //public long GuidToLongID(Guid guid, bool isimport = false)
        //{
        //    if (guid != null)
        //    {
        //        //byte[] buffer = guid.ToByteArray();
        //        //return BitConverter.ToInt64(buffer, 0);
        //        DateTime dt = CommonTools.GetDBSysDateTime();
        //        string datestr = dt.ToString("yyyyMMddHHmm");
        //        datestr = datestr.Substring(0, 12);
        //        //Thread.Sleep(5);//暂时取消，导入的话，用一个流水号的异或和；
        //        //Random d = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
        //        //int step = 1000 + new Random().Next(100, 999);
        //        byte[] buffer = guid.ToByteArray();
        //        Random d = new Random(BitConverter.ToInt32(buffer, 0));
        //        int step = 10000 + d.Next(1000, 9999);
        //        string rs = step.ToString();
        //        rs = rs.Substring(1, 4);
        //        uint FormNumber = 0;
        //        if ((isimport) || (typeof(IReportData).IsAssignableFrom(this.GetType())))//假如是导入，那么从数据库去随机号，或者用个这个重算的流水号；
        //        {
        //            FormNumber = BitConverter.ToUInt32(buffer, 0) ^
        //               BitConverter.ToUInt32(buffer, 4) ^
        //               BitConverter.ToUInt32(buffer, 8) ^
        //               BitConverter.ToUInt32(buffer, 12);
        //        }
        //        long iRtl = long.Parse(datestr + rs);
        //        iRtl = iRtl + FormNumber;
        //        return iRtl;
        //    }
        //    return 0;
        //}

        /// <summary>
        /// 打印输出到打印机的事件发 添加人：米俊 2018/05/07
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        //private void Report_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        //{
        //    switch (PrintObjectFullName)
        //    {
        //        case "JGSoft.MES.Module.BusinessObjects.WMS.StockOut.inv_issue_from_pm_main":
        //            if (View is ListView)
        //            {
        //                lv = (DevExpress.ExpressApp.ListView)View;
        //                ios = ObjectSpace;
        //                foreach (var item in lv.SelectedObjects.Cast<inv_issue_from_pm_main>().ToList())
        //                {
        //                    item.PrintCount++;
        //                    item.Save();
        //                }
        //                ios.CommitChanges();
        //            }
        //            if (View is DetailView)
        //            {
        //                dv = (DevExpress.ExpressApp.DetailView)View;
        //                if (dv != null)
        //                {
        //                    ios = ObjectSpace;
        //                    var item = (inv_issue_from_pm_main)dv.CurrentObject;
        //                    if ((item != null))
        //                    {
        //                        item.PrintCount++;
        //                        item.Save();
        //                    }
        //                    ios.CommitChanges();
        //                }
        //            }
        //            break;
        //    }

        //    //写到基类里暂时无法实现，必须指定一个实际的类别，作为反身的转换
        //    //string path = fullName + "," + assemblyName;//程序集名.类型名,程序集
        //    //Type o = Type.GetType(path);//加载类型
        //    //object obj = Activator.CreateInstance(o, true);//根据类型创建实例

        //}
    }

}