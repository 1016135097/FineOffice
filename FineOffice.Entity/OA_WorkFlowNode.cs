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
    [Table(Name = "dbo.OA_WorkFlowNode")]
    public partial class OA_WorkFlowNode : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _NodeNO;

        private string _NodeName;

        private string _PinyinCode;

        private System.Nullable<int> _WorkFlowID;

        private string _NodeXuHao;

        private System.Nullable<int> _NodeAttribute;

        private string _NextNodeXuHao;

        private System.Nullable<int> _VerifyModel;

        private System.Nullable<int> _ValidHours;

        private System.Nullable<int> _VerifierSetting;

        private string _Transactor;

        private string _SetLeft;

        private string _SetTop;

        private string _Remark;

        //private EntitySet<OA_Attachment> _OA_Attachment;

        private EntityRef<OA_WorkFlow> _OA_WorkFlow;

        private EntityRef<Sys_FixedData> _Sys_FixedData;

        private EntityRef<Sys_FixedData> _VerifyModelSys_FixedData;

        private EntityRef<Sys_FixedData> _VerifierSettingSys_FixedData;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnNodeNOChanging(string value);
        partial void OnNodeNOChanged();
        partial void OnNodeNameChanging(string value);
        partial void OnNodeNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnWorkFlowIDChanging(System.Nullable<int> value);
        partial void OnWorkFlowIDChanged();
        partial void OnNodeXuHaoChanging(string value);
        partial void OnNodeXuHaoChanged();
        partial void OnNodeAttributeChanging(System.Nullable<int> value);
        partial void OnNodeAttributeChanged();
        partial void OnNextNodeXuHaoChanging(string value);
        partial void OnNextNodeXuHaoChanged();
        partial void OnVerifyModelChanging(System.Nullable<int> value);
        partial void OnVerifyModelChanged();
        partial void OnValidHoursChanging(System.Nullable<int> value);
        partial void OnValidHoursChanged();
        partial void OnVerifierSettingChanging(System.Nullable<int> value);
        partial void OnVerifierSettingChanged();
        partial void OnTransactorChanging(string value);
        partial void OnTransactorChanged();
        partial void OnSetLeftChanged();
        partial void OnSetLeftChanging(string value);
        partial void OnSetTopChanged();
        partial void OnSetTopChanging(string value);
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_WorkFlowNode()
        {
            //this._OA_Attachment = new EntitySet<OA_Attachment>(new Action<OA_Attachment>(this.attach_OA_Attachment), new Action<OA_Attachment>(this.detach_OA_Attachment));
            this._OA_WorkFlow = default(EntityRef<OA_WorkFlow>);
            this._Sys_FixedData = default(EntityRef<Sys_FixedData>);
            this._VerifyModelSys_FixedData = default(EntityRef<Sys_FixedData>);
            this._VerifierSettingSys_FixedData = default(EntityRef<Sys_FixedData>);
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true,IsVersion=true)]
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

        [Column(Storage = "_NodeNO", DbType = "VarChar(50)")]
        public string NodeNO
        {
            get
            {
                return this._NodeNO;
            }
            set
            {
                if ((this._NodeNO != value))
                {
                    this.OnNodeNOChanging(value);
                    this.SendPropertyChanging();
                    this._NodeNO = value;
                    this.SendPropertyChanged("NodeNO");
                    this.OnNodeNOChanged();
                }
            }
        }

        [Column(Storage = "_NodeName", DbType = "VarChar(50)")]
        public string NodeName
        {
            get
            {
                return this._NodeName;
            }
            set
            {
                if ((this._NodeName != value))
                {
                    this.OnNodeNameChanging(value);
                    this.SendPropertyChanging();
                    this._NodeName = value;
                    this.SendPropertyChanged("NodeName");
                    this.OnNodeNameChanged();
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

        [Column(Storage = "_WorkFlowID", DbType = "Int")]
        public System.Nullable<int> WorkFlowID
        {
            get
            {
                return this._WorkFlowID;
            }
            set
            {
                if ((this._WorkFlowID != value))
                {
                    if (this._OA_WorkFlow.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnWorkFlowIDChanging(value);
                    this.SendPropertyChanging();
                    this._WorkFlowID = value;
                    this.SendPropertyChanged("WorkFlowID");
                    this.OnWorkFlowIDChanged();
                }
            }
        }

        [Column(Storage = "_NodeXuHao", DbType = "VarChar(50)")]
        public string NodeXuHao
        {
            get
            {
                return this._NodeXuHao;
            }
            set
            {
                if ((this._NodeXuHao != value))
                {
                    this.OnNodeXuHaoChanging(value);
                    this.SendPropertyChanging();
                    this._NodeXuHao = value;
                    this.SendPropertyChanged("NodeXuHao");
                    this.OnNodeXuHaoChanged();
                }
            }
        }

        [Column(Storage = "_NodeAttribute", DbType = "Int")]
        public System.Nullable<int> NodeAttribute
        {
            get
            {
                return this._NodeAttribute;
            }
            set
            {
                if ((this._NodeAttribute != value))
                {
                    if (this._Sys_FixedData.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnNodeAttributeChanging(value);
                    this.SendPropertyChanging();
                    this._NodeAttribute = value;
                    this.SendPropertyChanged("NodeAttribute");
                    this.OnNodeAttributeChanged();
                }
            }
        }

        [Column(Storage = "_NextNodeXuHao", DbType = "VarChar(50)")]
        public string NextNodeXuHao
        {
            get
            {
                return this._NextNodeXuHao;
            }
            set
            {
                if ((this._NextNodeXuHao != value))
                {
                    this.OnNextNodeXuHaoChanging(value);
                    this.SendPropertyChanging();
                    this._NextNodeXuHao = value;
                    this.SendPropertyChanged("NextNodeXuHao");
                    this.OnNextNodeXuHaoChanged();
                }
            }
        }

        [Column(Storage = "_VerifyModel", DbType = "Int")]
        public System.Nullable<int> VerifyModel
        {
            get
            {
                return this._VerifyModel;
            }
            set
            {
                if ((this._VerifyModel != value))
                {
                    if (this._VerifyModelSys_FixedData.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnVerifyModelChanging(value);
                    this.SendPropertyChanging();
                    this._VerifyModel = value;
                    this.SendPropertyChanged("VerifyModel");
                    this.OnVerifyModelChanged();
                }
            }
        }

        [Column(Storage = "_ValidHours", DbType = "Int")]
        public System.Nullable<int> ValidHours
        {
            get
            {
                return this._ValidHours;
            }
            set
            {
                if ((this._ValidHours != value))
                {
                    this.OnValidHoursChanging(value);
                    this.SendPropertyChanging();
                    this._ValidHours = value;
                    this.SendPropertyChanged("ValidHours");
                    this.OnValidHoursChanged();
                }
            }
        }

        [Column(Storage = "_VerifierSetting", DbType = "Int")]
        public System.Nullable<int> VerifierSetting
        {
            get
            {
                return this._VerifierSetting;
            }
            set
            {
                if ((this._VerifierSetting != value))
                {
                    if (this._VerifierSettingSys_FixedData.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnVerifierSettingChanging(value);
                    this.SendPropertyChanging();
                    this._VerifierSetting = value;
                    this.SendPropertyChanged("VerifierSetting");
                    this.OnVerifierSettingChanged();
                }
            }
        }

        [Column(Storage = "_Transactor", DbType = "VarChar(500)")]
        public string Transactor
        {
            get
            {
                return this._Transactor;
            }
            set
            {
                if ((this._Transactor != value))
                {
                    this.OnTransactorChanging(value);
                    this.SendPropertyChanging();
                    this._Transactor = value;
                    this.SendPropertyChanged("Transactor");
                    this.OnTransactorChanged();
                }
            }
        }

        [Column(Storage = "_SetLeft", DbType = "VarChar(50)")]
        public string SetLeft
        {
            get
            {
                return this._SetLeft;
            }
            set
            {
                if ((this._SetLeft != value))
                {
                    this.OnSetLeftChanging(value);
                    this.SendPropertyChanging();
                    this._SetLeft = value;
                    this.SendPropertyChanged("SetLeft");
                    this.OnSetLeftChanged();
                }
            }
        }

        [Column(Storage = "_SetTop", DbType = "VarChar(50)")]
        public string SetTop
        {
            get
            {
                return this._SetTop;
            }
            set
            {
                if ((this._SetTop != value))
                {
                    this.OnSetTopChanging(value);
                    this.SendPropertyChanging();
                    this._SetTop = value;
                    this.SendPropertyChanged("SetTop");
                    this.OnSetTopChanged();
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

        //[Association(Name = "FK_OA_ATTAC_REFERENCE_OA_WORKF", Storage = "_OA_Attachment", OtherKey = "WorkFlowNodeID", DeleteRule = "NO ACTION")]
        //public EntitySet<OA_Attachment> OA_Attachment
        //{
        //    get
        //    {
        //        return this._OA_Attachment;
        //    }
        //    set
        //    {
        //        this._OA_Attachment.Assign(value);
        //    }
        //}

        [Association(Name = "FK_OA_WORKF_REFERENCE_OA_WORKF", Storage = "_OA_WorkFlow", ThisKey = "WorkFlowID", IsForeignKey = true)]
        public OA_WorkFlow OA_WorkFlow
        {
            get
            {
                return this._OA_WorkFlow.Entity;
            }
            set
            {
                OA_WorkFlow previousValue = this._OA_WorkFlow.Entity;
                if (((previousValue != value)
                            || (this._OA_WorkFlow.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_WorkFlow.Entity = null;
                        previousValue.OA_WorkFlowNode.Remove(this);
                    }
                    this._OA_WorkFlow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_WorkFlowNode.Add(this);
                        this._WorkFlowID = value.ID;
                    }
                    else
                    {
                        this._WorkFlowID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_WorkFlow");
                }
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_SYS_FIXE1", Storage = "_Sys_FixedData", ThisKey = "NodeAttribute", IsForeignKey = true)]
        public Sys_FixedData Sys_FixedData
        {
            get
            {
                return this._Sys_FixedData.Entity;
            }
            set
            {
                Sys_FixedData previousValue = this._Sys_FixedData.Entity;
                if (((previousValue != value)
                            || (this._Sys_FixedData.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Sys_FixedData.Entity = null;
                        previousValue.OA_WorkFlowNode.Remove(this);
                    }
                    this._Sys_FixedData.Entity = value;
                    if ((value != null))
                    {
                        value.OA_WorkFlowNode.Add(this);
                        this._NodeAttribute = value.ID;
                    }
                    else
                    {
                        this._NodeAttribute = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("Sys_FixedData");
                }
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_SYS_FIXE2", Storage = "_VerifyModelSys_FixedData", ThisKey = "VerifyModel", IsForeignKey = true)]
        public Sys_FixedData VerifyModelSys_FixedData
        {
            get
            {
                return this._VerifyModelSys_FixedData.Entity;
            }
            set
            {
                Sys_FixedData previousValue = this._VerifyModelSys_FixedData.Entity;
                if (((previousValue != value)
                            || (this._VerifyModelSys_FixedData.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._VerifyModelSys_FixedData.Entity = null;
                        previousValue.OA_WORKF_REFERENCE_SYS_FIXE2.Remove(this);
                    }
                    this._VerifyModelSys_FixedData.Entity = value;
                    if ((value != null))
                    {
                        value.OA_WORKF_REFERENCE_SYS_FIXE2.Add(this);
                        this._VerifyModel = value.ID;
                    }
                    else
                    {
                        this._VerifyModel = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("VerifyModelSys_FixedData");
                }
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_SYS_FIXE3", Storage = "_VerifierSettingSys_FixedData", ThisKey = "VerifierSetting", IsForeignKey = true)]
        public Sys_FixedData VerifierSettingSys_FixedData
        {
            get
            {
                return this._VerifierSettingSys_FixedData.Entity;
            }
            set
            {
                Sys_FixedData previousValue = this._VerifierSettingSys_FixedData.Entity;
                if (((previousValue != value)
                            || (this._VerifierSettingSys_FixedData.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._VerifierSettingSys_FixedData.Entity = null;
                        previousValue.OA_WORKF_REFERENCE_SYS_FIXE3.Remove(this);
                    }
                    this._VerifierSettingSys_FixedData.Entity = value;
                    if ((value != null))
                    {
                        value.OA_WORKF_REFERENCE_SYS_FIXE3.Add(this);
                        this._VerifierSetting = value.ID;
                    }
                    else
                    {
                        this._VerifierSetting = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("VerifierSettingSys_FixedData");
                }
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

        //private void attach_OA_Attachment(OA_Attachment entity)
        //{
        //    this.SendPropertyChanging();
        //    entity.OA_WorkFlowNode = this;
        //}

        //private void detach_OA_Attachment(OA_Attachment entity)
        //{
        //    this.SendPropertyChanging();
        //    entity.OA_WorkFlowNode = null;
        //}
    }
}
