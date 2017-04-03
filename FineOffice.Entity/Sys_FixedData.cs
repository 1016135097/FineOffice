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
    [Table(Name = "dbo.Sys_FixedData")]
    public partial class Sys_FixedData : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _DataContent;

        private string _Sign;

        private string _Remark;

        private EntitySet<OA_WorkFlowNode> _OA_WorkFlowNode;

        private EntitySet<OA_WorkFlowNode> _OA_WORKF_REFERENCE_SYS_FIXE2;

        private EntitySet<OA_WorkFlowNode> _OA_WORKF_REFERENCE_SYS_FIXE3;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnDataContentChanging(string value);
        partial void OnDataContentChanged();
        partial void OnSignChanging(string value);
        partial void OnSignChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public Sys_FixedData()
        {
            this._OA_WorkFlowNode = new EntitySet<OA_WorkFlowNode>(new Action<OA_WorkFlowNode>(this.attach_OA_WorkFlowNode), new Action<OA_WorkFlowNode>(this.detach_OA_WorkFlowNode));
            this._OA_WORKF_REFERENCE_SYS_FIXE2 = new EntitySet<OA_WorkFlowNode>(new Action<OA_WorkFlowNode>(this.attach_OA_WORKF_REFERENCE_SYS_FIXE2), new Action<OA_WorkFlowNode>(this.detach_OA_WORKF_REFERENCE_SYS_FIXE2));
            this._OA_WORKF_REFERENCE_SYS_FIXE3 = new EntitySet<OA_WorkFlowNode>(new Action<OA_WorkFlowNode>(this.attach_OA_WORKF_REFERENCE_SYS_FIXE3), new Action<OA_WorkFlowNode>(this.detach_OA_WORKF_REFERENCE_SYS_FIXE3));
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_DataContent", DbType = "VarChar(500)")]
        public string DataContent
        {
            get
            {
                return this._DataContent;
            }
            set
            {
                if ((this._DataContent != value))
                {
                    this.OnDataContentChanging(value);
                    this.SendPropertyChanging();
                    this._DataContent = value;
                    this.SendPropertyChanged("DataContent");
                    this.OnDataContentChanged();
                }
            }
        }

        [Column(Storage = "_Sign", DbType = "VarChar(50)")]
        public string Sign
        {
            get
            {
                return this._Sign;
            }
            set
            {
                if ((this._Sign != value))
                {
                    this.OnSignChanging(value);
                    this.SendPropertyChanging();
                    this._Sign = value;
                    this.SendPropertyChanged("Sign");
                    this.OnSignChanged();
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

        [Association(Name = "FK_OA_WORKF_REFERENCE_SYS_FIXE1", Storage = "_OA_WorkFlowNode", OtherKey = "NodeAttribute", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_WORKF_REFERENCE_SYS_FIXE2", Storage = "_OA_WORKF_REFERENCE_SYS_FIXE2", OtherKey = "VerifyModel", DeleteRule = "NO ACTION")]
        public EntitySet<OA_WorkFlowNode> OA_WORKF_REFERENCE_SYS_FIXE2
        {
            get
            {
                return this._OA_WORKF_REFERENCE_SYS_FIXE2;
            }
            set
            {
                this._OA_WORKF_REFERENCE_SYS_FIXE2.Assign(value);
            }
        }

        [Association(Name = "FK_OA_WORKF_REFERENCE_SYS_FIXE3", Storage = "_OA_WORKF_REFERENCE_SYS_FIXE3", OtherKey = "VerifierSetting", DeleteRule = "NO ACTION")]
        public EntitySet<OA_WorkFlowNode> OA_WORKF_REFERENCE_SYS_FIXE3
        {
            get
            {
                return this._OA_WORKF_REFERENCE_SYS_FIXE3;
            }
            set
            {
                this._OA_WORKF_REFERENCE_SYS_FIXE3.Assign(value);
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
            entity.Sys_FixedData = this;
        }

        private void detach_OA_WorkFlowNode(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.Sys_FixedData = null;
        }

        private void attach_OA_WORKF_REFERENCE_SYS_FIXE2(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.VerifyModelSys_FixedData = this;
        }

        private void detach_OA_WORKF_REFERENCE_SYS_FIXE2(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.VerifyModelSys_FixedData = null;
        }

        private void attach_OA_WORKF_REFERENCE_SYS_FIXE3(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.VerifierSettingSys_FixedData = this;
        }

        private void detach_OA_WORKF_REFERENCE_SYS_FIXE3(OA_WorkFlowNode entity)
        {
            this.SendPropertyChanging();
            entity.VerifierSettingSys_FixedData = null;
        }
    }
}
