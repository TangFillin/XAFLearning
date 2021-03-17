
namespace XCRMDemo.Module.Controllers
{
    partial class FindByCategoryViewController
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
            this.FindByCategory = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // FindByCategory
            // 
            this.FindByCategory.Caption = "分类查找";
            this.FindByCategory.ConfirmationMessage = null;
            this.FindByCategory.Id = "FindByCategory";
            this.FindByCategory.NullValuePrompt = null;
            this.FindByCategory.ShortCaption = null;
            this.FindByCategory.ToolTip = null;
            this.FindByCategory.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.FindByCategory_Execute);
            // 
            // FindByCategoryViewController
            // 
            this.Actions.Add(this.FindByCategory);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.Activated += new System.EventHandler(this.FindByCategoryViewController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.ParametrizedAction FindByCategory;
    }
}
