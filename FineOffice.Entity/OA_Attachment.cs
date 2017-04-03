using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_Attachment")]
    public partial class OA_Attachment : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _LetterFollowID;

        private System.Nullable<int> _ContractID;

        private System.Nullable<int> _PersonnelID;

        private System.Nullable<int> _RunProcessID;

        private string _FileName;

        private string _XType;

        private string _XTypeName;

        private System.Data.Linq.Binary _AttachmentData;

        private string _Size;

        private System.Nullable<System.DateTime> _CreateTime;

        private string _Remark;

        private EntityRef<OA_Contract> _OA_Contract;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<ADM_LetterFollow> _ADM_LetterFollow;

        private EntityRef<OA_FlowRunProcess> _OA_FlowRunProcess;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnLetterFollowIDChanging(System.Nullable<int> value);
        partial void OnLetterFollowIDChanged();
        partial void OnContractIDChanging(System.Nullable<int> value);
        partial void OnContractIDChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnRunProcessIDChanging(System.Nullable<int> value);
        partial void OnRunProcessIDChanged();
        partial void OnFileNameChanging(string value);
        partial void OnFileNameChanged();
        partial void OnXTypeChanging(string value);
        partial void OnXTypeChanged();
        partial void OnXTypeNameChanging(string value);
        partial void OnXTypeNameChanged();
        partial void OnAttachmentDataChanging(System.Data.Linq.Binary value);
        partial void OnAttachmentDataChanged();
        partial void OnSizeChanging(string value);
        partial void OnSizeChanged();
        partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateTimeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_Attachment()
        {
            this._OA_Contract = default(EntityRef<OA_Contract>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._ADM_LetterFollow = default(EntityRef<ADM_LetterFollow>);
            this._OA_FlowRunProcess = default(EntityRef<OA_FlowRunProcess>);
            OnCreated();
        }

        [Column(Storage = "_ID", IsVersion = true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_LetterFollowID", DbType = "Int")]
        public System.Nullable<int> LetterFollowID
        {
            get
            {
                return this._LetterFollowID;
            }
            set
            {
                if ((this._LetterFollowID != value))
                {
                    if (this._ADM_LetterFollow.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnLetterFollowIDChanging(value);
                    this.SendPropertyChanging();
                    this._LetterFollowID = value;
                    this.SendPropertyChanged("LetterFollowID");
                    this.OnLetterFollowIDChanged();
                }
            }
        }

        [Column(Storage = "_ContractID", DbType = "Int")]
        public System.Nullable<int> ContractID
        {
            get
            {
                return this._ContractID;
            }
            set
            {
                if ((this._ContractID != value))
                {
                    if (this._OA_Contract.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnContractIDChanging(value);
                    this.SendPropertyChanging();
                    this._ContractID = value;
                    this.SendPropertyChanged("ContractID");
                    this.OnContractIDChanged();
                }
            }
        }

        [Column(Storage = "_PersonnelID", DbType = "Int")]
        public System.Nullable<int> PersonnelID
        {
            get
            {
                return this._PersonnelID;
            }
            set
            {
                if ((this._PersonnelID != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPersonnelIDChanging(value);
                    this.SendPropertyChanging();
                    this._PersonnelID = value;
                    this.SendPropertyChanged("PersonnelID");
                    this.OnPersonnelIDChanged();
                }
            }
        }

        [Column(Storage = "_RunProcessID", DbType = "Int")]
        public System.Nullable<int> RunProcessID
        {
            get
            {
                return this._RunProcessID;
            }
            set
            {
                if ((this._RunProcessID != value))
                {
                    if (this._OA_FlowRunProcess.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRunProcessIDChanging(value);
                    this.SendPropertyChanging();
                    this._RunProcessID = value;
                    this.SendPropertyChanged("RunProcessID");
                    this.OnRunProcessIDChanged();
                }
            }
        }

        [Column(Storage = "_FileName", DbType = "VarChar(500)")]
        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                if ((this._FileName != value))
                {
                    this.OnFileNameChanging(value);
                    this.SendPropertyChanging();
                    this._FileName = value;
                    this.SendPropertyChanged("FileName");
                    this.OnFileNameChanged();
                }
            }
        }

        [Column(Storage = "_XType", DbType = "VarChar(50)")]
        public string XType
        {
            get
            {
                return this._XType;
            }
            set
            {
                if ((this._XType != value))
                {
                    this.OnXTypeChanging(value);
                    this.SendPropertyChanging();
                    this._XType = value;
                    this.SendPropertyChanged("XType");
                    this.OnXTypeChanged();
                }
            }
        }

        [Column(Storage = "_XTypeName", DbType = "VarChar(50)")]
        public string XTypeName
        {
            get
            {
                return this._XTypeName;
            }
            set
            {
                if ((this._XTypeName != value))
                {
                    this.OnXTypeNameChanging(value);
                    this.SendPropertyChanging();
                    this._XTypeName = value;
                    this.SendPropertyChanged("XTypeName");
                    this.OnXTypeNameChanged();
                }
            }
        }

        [Column(Storage = "_AttachmentData", DbType = "Image", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary AttachmentData
        {
            get
            {
                return this._AttachmentData;
            }
            set
            {
                if ((this._AttachmentData != value))
                {
                    this.OnAttachmentDataChanging(value);
                    this.SendPropertyChanging();
                    this._AttachmentData = value;
                    this.SendPropertyChanged("AttachmentData");
                    this.OnAttachmentDataChanged();
                }
            }
        }

        [Column(Storage = "_Size", DbType = "VarChar(50)")]
        public string Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                if ((this._Size != value))
                {
                    this.OnSizeChanging(value);
                    this.SendPropertyChanging();
                    this._Size = value;
                    this.SendPropertyChanged("Size");
                    this.OnSizeChanged();
                }
            }
        }

        [Column(Storage = "_CreateTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if ((this._CreateTime != value))
                {
                    this.OnCreateTimeChanging(value);
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                    this.OnCreateTimeChanged();
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

        [Association(Name = "FK_ATTACHME_REFERENCE_CONTRACT", Storage = "_OA_Contract", ThisKey = "ContractID", IsForeignKey = true)]
        public OA_Contract OA_Contract
        {
            get
            {
                return this._OA_Contract.Entity;
            }
            set
            {
                OA_Contract previousValue = this._OA_Contract.Entity;
                if (((previousValue != value)
                            || (this._OA_Contract.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_Contract.Entity = null;
                        previousValue.OA_Attachment.Remove(this);
                    }
                    this._OA_Contract.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Attachment.Add(this);
                        this._ContractID = value.ID;
                    }
                    else
                    {
                        this._ContractID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_Contract");
                }
            }
        }

        [Association(Name = "FK_BNS_ATT_HR_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.OA_Attachment.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Attachment.Add(this);
                        this._PersonnelID = value.ID;
                    }
                    else
                    {
                        this._PersonnelID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_Attachment_ADM_LetterFollow", Storage = "_ADM_LetterFollow", ThisKey = "LetterFollowID", IsForeignKey = true)]
        public ADM_LetterFollow ADM_LetterFollow
        {
            get
            {
                return this._ADM_LetterFollow.Entity;
            }
            set
            {
                ADM_LetterFollow previousValue = this._ADM_LetterFollow.Entity;
                if (((previousValue != value)
                            || (this._ADM_LetterFollow.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._ADM_LetterFollow.Entity = null;
                        previousValue.OA_Attachment.Remove(this);
                    }
                    this._ADM_LetterFollow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Attachment.Add(this);
                        this._LetterFollowID = value.ID;
                    }
                    else
                    {
                        this._LetterFollowID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("ADM_LetterFollow");
                }
            }
        }

        [Association(Name = "FK_OA_Attachment_OA_FlowRunProcess", Storage = "_OA_FlowRunProcess", ThisKey = "RunProcessID", IsForeignKey = true)]
        public OA_FlowRunProcess OA_FlowRunProcess
        {
            get
            {
                return this._OA_FlowRunProcess.Entity;
            }
            set
            {
                OA_FlowRunProcess previousValue = this._OA_FlowRunProcess.Entity;
                if (((previousValue != value)
                            || (this._OA_FlowRunProcess.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FlowRunProcess.Entity = null;
                        previousValue.OA_Attachment.Remove(this);
                    }
                    this._OA_FlowRunProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Attachment.Add(this);
                        this._RunProcessID = value.ID;
                    }
                    else
                    {
                        this._RunProcessID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_FlowRunProcess");
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
    }
}
