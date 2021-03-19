using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;

namespace XCRMDemo.Module.BusinessObjects
{
    //[NonPersistent]//不存储到数据库
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [XafDefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [XafDisplayName("客户")]
    [Appearance("红色禁用", "ViewItem", FontColor = "Red", Context = "ListView", TargetItems = "IsValid", Criteria = "!IsValid")]
    [Appearance("蓝色未审批", "ViewItem", FontColor = "Blue", TargetItems = "*", Criteria = "!IsChecked")]
    [RuleObjectExists("", DefaultContexts.Save, "")]
    public class Customer : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Customer(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}


        [Action(Caption = "生成档案", TargetObjectsCriteria = "DocumentInfos.Count=0")]
        public void GenerateDoc()
        {
            string infos = "1.入职申请表;2.登记信息;3.专业测试";
            foreach (var item in infos.Split(';'))
            {
                DocumentInfo d = new DocumentInfo(Session)
                {
                    DocType = item,
                    Customer = this
                };

            }
        }
        private string _id;
        [XafDisplayName("异常类型编号"), Size(100)]
        [RuleRequiredField]
        [Indexed]
        [Index(10)]
        [Appearance("", BackColor = "#FFE1E1", Context = "DetailView")]
        public string Id
        {
            get { return _id; }
            set
            {
                SetPropertyValue("Id", ref _id, value);
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        private string _name;

        [XafDisplayName("姓名")]
        [RuleRequiredField(CustomMessageTemplate = "姓名不能为空")]
        public string Name
        {
            get { return _name; }
            set
            {
                SetPropertyValue("Name", ref _name, value);
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        private Sex _sex;

        [XafDisplayName("性别")]
        public Sex Sex
        {
            get { return _sex; }
            set
            {
                SetPropertyValue("Sex", ref _sex, value);
            }
        }

        private string _sex1;
        [XafDisplayName("性别一")]
        [ModelDefault("PredefinedValues", "男;女")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Sex1
        {
            get { return _sex1; }

            set
            {
                SetPropertyValue("Sex1", ref _sex1, value);
            }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        private DateTime _birthday;

        [XafDisplayName("出生日期")]
        [RuleRequiredField("审核时必填出生日期", "IsChecked")]

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                SetPropertyValue("Birthday", ref _birthday, value);
            }
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        private string _phone;

        [XafDisplayName("手机号码")]
        public string Phone
        {
            get { return _phone; }
            set
            {
                SetPropertyValue("Phone", ref _phone, value);
            }
        }

        /// <summary>
        /// 地址
        /// </summary>
        private string _address;

        [XafDisplayName("地址")]
        [RuleRequiredField(ResultType = ValidationResultType.Warning, CustomMessageTemplate = "如果不填写地址奖品将无法寄出，确认不填写吗？")]
        [RuleStringComparison("地址必须以重庆市开头", DefaultContexts.Save, StringComparisonType.StartsWith, "重庆市", SkipNullOrEmptyValues = true)]//SkipNullOrEmptyValues=true可空,DefaultContexts.Save保存时生效规则
        public string Address
        {
            get { return _address; }
            set
            {
                SetPropertyValue("Address", ref _address, value);
            }
        }

        /// <summary>
        /// 年收入
        /// </summary>
        private decimal _income;

        [XafDisplayName("年收入")]
        [ModelDefault("Income", "0.1")]
        public decimal Income
        {
            get { return _income; }
            set
            {
                SetPropertyValue("Income", ref _income, value);
            }
        }

        //private DocumentInfo _documentInfo;
        [DevExpress.Xpo.Aggregated]
        [Association("Customer-DocumentInfos")]
        public XPCollection<DocumentInfo> DocumentInfos
        {
            get
            {
                return GetCollection<DocumentInfo>("DocumentInfos");
            }
        }


        /// <summary>
        /// 照片
        /// </summary>
        //private byte[] _photo;

        [XafDisplayName("照片")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit,
            DetailViewImageEditorMode = ImageEditorMode.PictureEdit,
            ListViewImageEditorCustomHeight = 40)]
        public byte[] Photo
        {
            get { return GetPropertyValue<byte[]>("Photo"); }
            set
            {
                SetPropertyValue<byte[]>("Photo", value);
            }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        private bool isValid;
        [XafDisplayName("是否启用")]
        public bool IsValid
        {
            get { return isValid; }
            set
            {
                SetPropertyValue("IsValid", ref isValid, value);
            }
        }

        private CustomerCategory _customerCategory;

        [XafDisplayName("客户类型")]
        public CustomerCategory CustomerCategory
        {
            get
            {
                return _customerCategory;
            }
            set
            {
                SetPropertyValue("CustomerCategory", ref _customerCategory, value);
            }
        }

        [XafDisplayName("联系人")]
        [Association]
        public XPCollection<Contact> Contacts
        {
            get { return GetCollection<Contact>("Contacts"); }
        }

        [XafDisplayName("销售区域")]
        [Association]
        public XPCollection<SalesRegion> SalesRegions
        {
            get { return GetCollection<SalesRegion>("SalesRegions"); }
        }

        private bool _isChecked;

        [XafDisplayName("是否审核")]
        [ModelDefault("AllowEdit", "False")]//使属性在界面上只读
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                SetPropertyValue("IsChecked", ref _isChecked, value);
            }
        }
        private Contact _contact;
        [IgnoreForAssociation]
        [XafDisplayName("直接联系人")]
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                SetPropertyValue("Contact", ref _contact, value);
            }
        }

        private DateSpan _dateSpan;

        [XafDisplayName("起止时间")]
        public DateSpan DateSpan
        {
            get
            {
                return _dateSpan;
            }
            set
            {
                SetPropertyValue("DateSpan", ref _dateSpan, value);
            }
        }



    }
    public class DateSpan //: BaseObject
    {
        private DateTime startDate;

        //[XafDisplayName("开始时间")]
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                //SetPropertyValue("StartDate", ref startDate, value);
                startDate = value;
            }
        }

        private DateTime endDate;
        //[XafDisplayName("截至时间")]
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                //SetPropertyValue("EndDate", ref endDate, value);
                endDate = value;
            }
        }
    }

    public enum Sex
    {
        [DisplayName("男")]
        MAN,
        [DisplayName("女")]
        FEMAN,
        [DisplayName("未知")]
        UNKNOW
    }
}