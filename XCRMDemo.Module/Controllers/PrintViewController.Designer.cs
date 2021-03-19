
namespace XCRMDemo.Module.Controllers
{
    partial class PrintViewController
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
            this.btn_print = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            this.btn_printPreview = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // btn_print
            // 
            this.btn_print.Caption = "打印";
            this.btn_print.ConfirmationMessage = null;
            this.btn_print.Id = "btn_print";
            this.btn_print.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.btn_print.ToolTip = null;
            // 
            // btn_printPreview
            // 
            this.btn_printPreview.Caption = null;
            this.btn_printPreview.ConfirmationMessage = null;
            this.btn_printPreview.Id = "599c9294-162e-4602-82a5-41c5969e793b";
            this.btn_printPreview.ToolTip = null;
            // 
            // PrintViewController
            // 
            this.Actions.Add(this.btn_print);
            this.Actions.Add(this.btn_printPreview);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction btn_print;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction btn_printPreview;
    }
}
