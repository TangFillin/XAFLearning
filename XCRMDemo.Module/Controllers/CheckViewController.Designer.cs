
namespace XCRMDemo.Module.Controllers
{
    partial class CheckViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Checked = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // btn_Checked
            // 
            this.btn_Checked.Caption = "审核";
            this.btn_Checked.ConfirmationMessage = null;
            this.btn_Checked.Id = "btn_Checked";
            this.btn_Checked.TargetObjectType = typeof(XCRMDemo.Module.BusinessObjects.Customer);
            this.btn_Checked.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.btn_Checked.ToolTip = null;
            this.btn_Checked.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.btn_Checked.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.btn_Checked_Execute);
            // 
            // CheckViewController
            // 
            this.Actions.Add(this.btn_Checked);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction btn_Checked;
    }
}
