using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BX.Entity
{
    [Table(Name = "dbo.OA_WorkFlow")]
    public partial class OA_WorkFlow : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _FormID;

        private System.Nullable<int> _ProjectTypeID;

        private string _WorkFlowNO;

        private string _WorkFlowName;

        private string _PinyinCode;

        private System.Nullable<int> _Maker;

        private System.Nullable<System.DateTime> _MakeDate;

        private string _UserList;

        private string _Describe;               

        private string _Remark;


        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_Form> _OA_Form;

        private EntityRef<OA_ProjectType> _OA_ProjectType;

        private EntitySet<OA_WorkFlowNode> _OA_WorkFlowNode;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnFormIDChanging(System.Nullable<int> value);
        partial void OnFormIDChanged();
        partial void OnProjectTypeIDChanging(System.Nullable<int> value);
        partial void OnProjectTypeIDChanged();
        partial void OnWorkFlowNOChanging(string value);
        partial void OnWorkFlowNOChanged();
        partial void OnWorkFlowNameChanging(string value);
        partial void OnWorkFlowNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnMakerChanging(System.Nullable<int> value);
        partial void OnMakerChanged();
        partial void OnMakeDateChanging(System.Nullable<System.DateTime> value);
        partial void OnMakeDateChanged();
        partial void OnUserListChanging(string value);
        partial void OnUserListChanged();
        partial void OnDescribeChanging(string value);
        partial void OnDescribeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_WorkFlow()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_Form = default(EntityRef<OA_Form>);
            this._OA_ProjectType = default(EntityRef<OA_ProjectType>);
            this._OA_WorkFlowNode = new EntitySet<OA_WorkFlowNode>(new Action<OA_WorkFlowNode>(this.attach_OA_WorkFlowNode), new Action<OA_WorkFlowNode>(this.detach_OA_WorkFlowNode));
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, IsVersion=true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_FormID", DbType = "Int")]
        public System.Nullable<int> FormID
        {
            get
            {
                return this._FormID;
            }
            set
            {
                if ((this._FormID != value))
                {
                    if (this._OA_Form.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFormIDChanging(value);
                    this.SendPropertyChanging();
                    this._FormID = value;
                    this.SendPropertyChanged("FormID");
                    this.OnFormIDChanged();
                }
            }
        }

        [Column(Storage = "_ProjectTypeID", DbType = "Int")]
        public System.Nullable<int> ProjectTypeID
        {
            get
            {
                return this._ProjectTypeID;
            }
            set
            {
                if ((this._ProjectTypeID != value))
                {
                    if (this._OA_ProjectType.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnProjectTypeIDChanging(value);
                    this.SendPropertyChanging();
                    this._ProjectTypeID = value;
                    this.SendPropertyChanged("ProjectTypeID");
                    this.OnProjectTypeIDChanged();
                }
            }
        }

        [Column(Storage = "_WorkFlowNO", DbType = "VarChar(50)")]
        public string WorkFlowNO
        {
            get
            {
                return this._WorkFlowNO;
            }
            set
            {
                if ((this._WorkFlowNO != value))
                {
                    this.OnWorkFlowNOChanging(value);
                    this.SendPropertyChanging();
                    this._WorkFlowNO = value;
                    this.SendPropertyChanged("WorkFlowNO");
                    this.OnWorkFlowNOChanged();
                }
            }
        }

        [Column(Storage = "_WorkFlowName", DbType = "VarChar(50)")]
        public string WorkFlowName
        {
            get
            {
                return this._WorkFlowName;
            }
            set
            {
                if ((this._WorkFlowName != value))
                {
                    this.OnWorkFlowNameChanging(value);
                    this.SendPropertyChanging();
                    this._WorkFlowName = value;
                    this.SendPropertyChanged("WorkFlowName");
                    this.OnWorkFlowNameChanged();
                }
            }
        }

        [Column(Storage = "_PinyinCode", DbType = "VarChar(30)")]
        public string PinyinCode
        {
            get
            {
                return this._PinyinCode;
            }
            set
            {
                if ((this._PinyinCode != value))
                {
                    this.OnPinyinCodeChanging(value);
                    this.SendPropertyChanging();
                    this._PinyinCode = value;
                    this.SendPropertyChanged("PinyinCode");
                    this.OnPinyinCodeChanged();
                }
            }
        }

        [Column(Storage = "_Maker", DbType = "Int")]
        public System.Nullable<int> Maker
        {
            get
            {
                return this._Maker;
            }
            set
            {
                if ((this._Maker != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMakerChanging(value);
                    this.SendPropertyChanging();
                    this._Maker = value;
                    this.SendPropertyChanged("Maker");
                    this.OnMakerChanged();
                }
            }
        }

        [Column(Storage = "_MakeDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> MakeDate
        {
            get
            {
                return this._MakeDate;
            }
            set
            {
                if ((this._MakeDate != value))
                {
                    this.OnMakeDateChanging(value);
                    this.SendPropertyChanging();
                    this._MakeDate = value;
                    this.SendPropertyChanged("MakeDate");
                    this.OnMakeDateChanged();
                }
            }
        }

        [Column(Storage = "_UserList", DbType = "VarChar(500)")]
        public string UserList
        {
            get
            {
                return this._UserList;
            }
            set
            {
                if ((this._UserList != value))
                {
                    this.OnUserListChanging(value);
                    this.SendPropertyChanging();
                    this._UserList = value;
                    this.SendPropertyChanged("UserList");
                    this.OnUserListChanged();
                }
            }
        }

        [Column(Storage = "_Describe", DbType = "VarChar(200)")]
        public string Describe
        {
            get
            {
                return this._Describe;
            }
            set
            {
                if ((this._Describe != value))
                {
                    this.OnDescribeChanging(value);
                    this.SendPropertyChanging();
                    this._Describe = value;
                    this.SendPropertyChanged("Describe");
                    this.OnDescribeChanged();
                }
            }
        }

        [Column(Storage = "_Remark", DbType = "VarChar(500)")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                if ((this._Remark != value))
                {
                    this.OnRemarkChanging(value);
                    this.SendPropertyChanging();
                    this._Remark = value;
                    this.SendPropertyChanged("Remark");
                    this.OnRemarkChanged();
                }
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_HR_PERSO", Storage = "_HR_Personnel", ThisKey = "Maker", IsForeignKey = true)]
        public HR_Personnel HR_Personnel
        {
            get
            {
                return this._HR_Personnel.Entity;
            }
            set
            {
                HR_Personnel previousValue = this._HR_Personnel.Entity;
                if (((previousValue != value)
                            || (this._HR_Personnel.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_Personnel.Entity = null;
                        previousValue.OA_WorkFlow.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_WorkFlow.Add(this);
                        this._Maker = value.ID;
                    }
                    else
                    {
                        this._Maker = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_OA_PROJE", Storage = "_OA_ProjectType", ThisKey = "ProjectTypeID", IsForeignKey = true)]
        public OA_ProjectType OA_ProjectType
        {
            get
            {
                return this._OA_ProjectType.Entity;
            }
            set
            {
                OA_ProjectType previousValue = this._OA_ProjectType.Entity;
                if (((previousValue != value)
                            || (this._OA_ProjectType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_ProjectType.Entity = null;
                        previousValue.OA_WorkFlow.Remove(this);
                    }
                    this._OA_ProjectType.Entity = value;
                    if ((value != null))
                    {
                        value.OA_WorkFlow.Add(this);
                        this._ProjectTypeID = value.ID;
                    }
                    else
                    {
                        this._ProjectTypeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_ProjectType");
                }
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_OA_WORKF", Storage = "_OA_WorkFlowNode", OtherKey = "WorkFlowID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_WorkFlowNode> OA_WorkFlowNode
        {
            get
            {
                return this._OA_WorkFlowNode;
            }
            set
            {
                this._OA_WorkFlowNode.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }
       
        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_OA_WorkFlowNode(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.OA_WorkFlow = this;
        }

        private void detach_OA_WorkFlowNode(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.OA_WorkFlow = null;
        }
    }
}
