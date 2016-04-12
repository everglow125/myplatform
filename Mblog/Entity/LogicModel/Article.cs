using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Entity
{
    /// <summary>
    /// 类dt_Article。
    /// </summary>
    [Serializable]
    public partial class Article
    {
        #region Model
        private long _id;
        private string _title;
        private string _content;
        private int _createby;
        private DateTime _createtime;
        private int _status;
        private int _readcount;
        private int _viewenable;
        private int _replycount;
        private string _lastreadtime;
        /// <summary>
        /// 
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReadCount
        {
            set { _readcount = value; }
            get { return _readcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ViewEnable
        {
            set { _viewenable = value; }
            get { return _viewenable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReplyCount
        {
            set { _replycount = value; }
            get { return _replycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastReadTime
        {
            set { _lastreadtime = value; }
            get { return _lastreadtime; }
        }
        #endregion Model

    }
}

