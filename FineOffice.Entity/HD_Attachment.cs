using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.HD_Attachment")]
    public partial class HD_Attachment : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _FileName;

        private string _XType;

        private string _XTypeName;

        private System.Data.Linq.Binary _AttachmentData;

        private string _Size;

        private System.Nullable<int> _FolderID;

        private System.Nullable<System.DateTime> _CreateTime;

        private System.Nullable<int> _PersonnelID;

        private System.Nullable<int> _Owner;

        private System.Nullable<int> _SendID;

        private System.Nullable<System.DateTime> _SendTime;

        private System.Nullable<bool> _IsPublic;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<HD_Folder> _HD_Folder;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
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
        partial void OnFolderIDChanging(System.Nullable<int> value);
        partial void OnFolderIDChanged();
        partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateTimeChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnOwnerChanging(System.Nullable<int> value);
        partial void OnOwnerChanged();
        partial void OnSendIDChanging(System.Nullable<int> value);
        partial void OnSendIDChanged();
        partial void OnSendTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnSendTimeChanged();
        partial void OnIsPublicChanging(System.Nullable<bool> value);
        partial void OnIsPublicChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public HD_Attachment()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._HD_Folder = default(EntityRef<HD_Folder>);
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

        [Column(Storage = "_FolderID", DbType = "Int")]
        public System.Nullable<int> FolderID
        {
            get
            {
                return this._FolderID;
            }
            set
            {
                if ((this._FolderID != value))
                {
                    if (this._HD_Folder.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFolderIDChanging(value);
                    this.SendPropertyChanging();
                    this._FolderID = value;
                    this.SendPropertyChanged("FolderID");
                    this.OnFolderIDChanged();
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

        [Column(Storage = "_Owner", DbType = "Int")]
        public System.Nullable<int> Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                if ((this._Owner != value))
                {
                    this.OnOwnerChanging(value);
                    this.SendPropertyChanging();
                    this._Owner = value;
                    this.SendPropertyChanged("Owner");
                    this.OnOwnerChanged();
                }
            }
        }

        [Column(Storage = "_SendID", DbType = "Int")]
        public System.Nullable<int> SendID
        {
            get
            {
                return this._SendID;
            }
            set
            {
                if ((this._SendID != value))
                {
                    this.OnSendIDChanging(value);
                    this.SendPropertyChanging();
                    this._SendID = value;
                    this.SendPropertyChanged("SendID");
                    this.OnSendIDChanged();
                }
            }
        }

        [Column(Storage = "_SendTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> SendTime
        {
            get
            {
                return this._SendTime;
            }
            set
            {
                if ((this._SendTime != value))
                {
                    this.OnSendTimeChanging(value);
                    this.SendPropertyChanging();
                    this._SendTime = value;
                    this.SendPropertyChanged("SendTime");
                    this.OnSendTimeChanged();
                }
            }
        }

        [Column(Storage = "_IsPublic", DbType = "Bit")]
        public System.Nullable<bool> IsPublic
        {
            get
            {
                return this._IsPublic;
            }
            set
            {
                if ((this._IsPublic != value))
                {
                    this.OnIsPublicChanging(value);
                    this.SendPropertyChanging();
                    this._IsPublic = value;
                    this.SendPropertyChanged("IsPublic");
                    this.OnIsPublicChanged();
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

        [Association(Name = "FK_OA_Com_Attachment_HR_Personnel", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.HD_Attachment.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.HD_Attachment.Add(this);
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

        [Association(Name = "FK_OA_COM_Attachment_OA_Folder", Storage = "_HD_Folder", ThisKey = "FolderID", IsForeignKey = true)]
        public HD_Folder HD_Folder
        {
            get
            {
                return this._HD_Folder.Entity;
            }
            set
            {
                HD_Folder previousValue = this._HD_Folder.Entity;
                if (((previousValue != value)
                            || (this._HD_Folder.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HD_Folder.Entity = null;
                        previousValue.HD_Attachment.Remove(this);
                    }
                    this._HD_Folder.Entity = value;
                    if ((value != null))
                    {
                        value.HD_Attachment.Add(this);
                        this._FolderID = value.ID;
                    }
                    else
                    {
                        this._FolderID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HD_Folder");
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
