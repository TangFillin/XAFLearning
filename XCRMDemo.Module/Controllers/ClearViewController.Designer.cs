
namespace XCRMDemo.Module.Controllers
{
    partial class ClearViewController
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
            this.ClearFieldAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ClearFieldAction
            // 
            this.ClearFieldAction.Caption = "清除数据";
            this.ClearFieldAction.Category = "View";
            this.ClearFieldAction.ConfirmationMessage = "确认清除？";
            this.ClearFieldAction.Id = "ClearFieldAction";
            this.ClearFieldAction.ToolTip = null;
            this.ClearFieldAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ClearFieldAction_Execute);
            // 
            // ClearViewController
            // 
            this.Actions.Add(this.ClearFieldAction);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.Activated += new System.EventHandler(this.ClearViewController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ClearFieldAction;
    }
}
