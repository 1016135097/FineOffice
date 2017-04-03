using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.HD_Folder")]
    public partial class HD_Folder : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _FolderName;

        private System.Nullable<int> _ParentID;

        private System.Nullable<bool> _IsPublic;

        private System.Nullable<int> _PersonnelID;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntitySet<HD_Attachment> _HD_Attachment;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnFolderNameChanging(string value);
        partial void OnFolderNameChanged();
        partial void OnParentIDChanging(System.Nullable<int> value);
        partial void OnParentIDChanged();
        partial void OnIsPublicChanging(System.Nullable<bool> value);
        partial void OnIsPublicChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public HD_Folder()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._HD_Attachment = new EntitySet<HD_Attachment>(new Action<HD_Attachment>(this.attach_HD_Attachment), new Action<HD_Attachment>(this.detach_HD_Attachment));
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

        [Column(Storage = "_FolderName", DbType = "VarChar(50)")]
        public string FolderName
        {
            get
            {
                return this._FolderName;
            }
            set
            {
                if ((this._FolderName != value))
                {
                    this.OnFolderNameChanging(value);
                    this.SendPropertyChanging();
                    this._FolderName = value;
                    this.SendPropertyChanged("FolderName");
                    this.OnFolderNameChanged();
                }
            }
        }

        [Column(Storage = "_ParentID", DbType = "Int")]
        public System.Nullable<int> ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                if ((this._ParentID != value))
                {
                    this.OnParentIDChanging(value);
                    this.SendPropertyChanging();
                    this._ParentID = value;
                    this.SendPropertyChanged("ParentID");
                    this.OnParentIDChanged();
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

        [Association(Name = "FK_HD_Folder_HR_Personnel", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.HD_Folder.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.HD_Folder.Add(this);
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

        [Association(Name = "FK_OA_COM_Attachment_OA_Folder", Storage = "_HD_Attachment", OtherKey = "FolderID", DeleteRule = "NO ACTION")]
        public EntitySet<HD_Attachment> HD_Attachment
        {
            get
            {
                return this._HD_Attachment;
            }
            set
            {
                this._HD_Attachment.Assign(value);
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

        private void attach_HD_Attachment(HD_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.HD_Folder = this;
        }

        private void detach_HD_Attachment(HD_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.HD_Folder = null;
        }
    }
}
