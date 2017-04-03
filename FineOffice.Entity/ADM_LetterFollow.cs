using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.ADM_LetterFollow")]
    public partial class ADM_LetterFollow : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _LetterID;

        private string _Linkman;

        private string _Mobile;

        private string _Matter;

        private string _Result;

        private System.Nullable<int> _Handler;

        private System.Nullable<System.DateTime> _HandleTime;

        private string _Remark;

        private EntityRef<ADM_Letter> _ADM_Letter;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntitySet<OA_Attachment> _OA_Attachment;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnLetterIDChanging(System.Nullable<int> value);
        partial void OnLetterIDChanged();
        partial void OnLinkmanChanging(string value);
        partial void OnLinkmanChanged();
        partial void OnMobileChanging(string value);
        partial void OnMobileChanged();
        partial void OnMatterChanging(string value);
        partial void OnMatterChanged();
        partial void OnResultChanging(string value);
        partial void OnResultChanged();
        partial void OnHandlerChanging(System.Nullable<int> value);
        partial void OnHandlerChanged();
        partial void OnHandleTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnHandleTimeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public ADM_LetterFollow()
        {
            this._ADM_Letter = default(EntityRef<ADM_Letter>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_Attachment = new EntitySet<OA_Attachment>(new Action<OA_Attachment>(this.attach_OA_Attachment), new Action<OA_Attachment>(this.detach_OA_Attachment));
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

        [Column(Storage = "_LetterID", DbType = "Int")]
        public System.Nullable<int> LetterID
        {
            get
            {
                return this._LetterID;
            }
            set
            {
                if ((this._LetterID != value))
                {
                    if (this._ADM_Letter.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnLetterIDChanging(value);
                    this.SendPropertyChanging();
                    this._LetterID = value;
                    this.SendPropertyChanged("LetterID");
                    this.OnLetterIDChanged();
                }
            }
        }

        [Column(Storage = "_Linkman", DbType = "VarChar(50)")]
        public string Linkman
        {
            get
            {
                return this._Linkman;
            }
            set
            {
                if ((this._Linkman != value))
                {
                    this.OnLinkmanChanging(value);
                    this.SendPropertyChanging();
                    this._Linkman = value;
                    this.SendPropertyChanged("Linkman");
                    this.OnLinkmanChanged();
                }
            }
        }

        [Column(Storage = "_Mobile", DbType = "VarChar(50)")]
        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                if ((this._Mobile != value))
                {
                    this.OnMobileChanging(value);
                    this.SendPropertyChanging();
                    this._Mobile = value;
                    this.SendPropertyChanged("Mobile");
                    this.OnMobileChanged();
                }
            }
        }

        [Column(Storage = "_Matter", DbType = "VarChar(50)")]
        public string Matter
        {
            get
            {
                return this._Matter;
            }
            set
            {
                if ((this._Matter != value))
                {
                    this.OnMatterChanging(value);
                    this.SendPropertyChanging();
                    this._Matter = value;
                    this.SendPropertyChanged("Matter");
                    this.OnMatterChanged();
                }
            }
        }

        [Column(Storage = "_Result", DbType = "VarChar(500)")]
        public string Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                if ((this._Result != value))
                {
                    this.OnResultChanging(value);
                    this.SendPropertyChanging();
                    this._Result = value;
                    this.SendPropertyChanged("Result");
                    this.OnResultChanged();
                }
            }
        }

        [Column(Storage = "_Handler", DbType = "Int")]
        public System.Nullable<int> Handler
        {
            get
            {
                return this._Handler;
            }
            set
            {
                if ((this._Handler != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnHandlerChanging(value);
                    this.SendPropertyChanging();
                    this._Handler = value;
                    this.SendPropertyChanged("Handler");
                    this.OnHandlerChanged();
                }
            }
        }

        [Column(Storage = "_HandleTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> HandleTime
        {
            get
            {
                return this._HandleTime;
            }
            set
            {
                if ((this._HandleTime != value))
                {
                    this.OnHandleTimeChanging(value);
                    this.SendPropertyChanging();
                    this._HandleTime = value;
                    this.SendPropertyChanged("HandleTime");
                    this.OnHandleTimeChanged();
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

        [Association(Name = "FK_ADM_LetterFollow_ADM_Letter", Storage = "_ADM_Letter", ThisKey = "LetterID", IsForeignKey = true)]
        public ADM_Letter ADM_Letter
        {
            get
            {
                return this._ADM_Letter.Entity;
            }
            set
            {
                ADM_Letter previousValue = this._ADM_Letter.Entity;
                if (((previousValue != value)
                            || (this._ADM_Letter.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._ADM_Letter.Entity = null;
                        previousValue.ADM_LetterFollow.Remove(this);
                    }
                    this._ADM_Letter.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_LetterFollow.Add(this);
                        this._LetterID = value.ID;
                    }
                    else
                    {
                        this._LetterID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("ADM_Letter");
                }
            }
        }

        [Association(Name = "FK_ADM_LetterFollow_Handler", Storage = "_HR_Personnel", ThisKey = "Handler", IsForeignKey = true)]
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
                        previousValue.ADM_LetterFollow.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_LetterFollow.Add(this);
                        this._Handler = value.ID;
                    }
                    else
                    {
                        this._Handler = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_Attachment_ADM_LetterFollow", Storage = "_OA_Attachment", OtherKey = "LetterFollowID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Attachment> OA_Attachment
        {
            get
            {
                return this._OA_Attachment;
            }
            set
            {
                this._OA_Attachment.Assign(value);
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

        private void attach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.ADM_LetterFollow = this;
        }

        private void detach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.ADM_LetterFollow = null;
        }
    }
}
