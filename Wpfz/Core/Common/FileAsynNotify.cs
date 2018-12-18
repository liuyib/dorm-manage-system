using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfz
{
    /// <summary>
    /// 文件数据操作异步消息，增加了数据处理速度消息处理
    /// </summary>
    public class FileAsynNotify : DefaultAsynNotify
    {
        /// <summary>
        /// 消息格式
        /// </summary>
        public string MessageFormat = "总大小{0}，已完成{1}，平均速度{2}/s";

        private string _totalDesc;

        private double _total;
        /// <summary>
        /// 总任务刻度
        /// </summary>
        public override double Total
        {
            get { return this._total; }
            protected set
            {
                this._total = value;
                //this._TotalDesc = System.Utility.Helper.File.GetFileSize((long)value);
                var speed = "0KB";
                if(this.UsedSecond>0)
                {
                    this._totalDesc = string.Format(MessageFormat,
                        _total,
                        Completed,
                        ((long)(this.Completed) / this.UsedSecond));
                }
                else
                {
                    this._totalDesc = string.Format(MessageFormat, _total, Completed, speed);
                }
                base.OnPropertyChanged("Total");
            }
        }

        protected override void SetMessage(string mes)
        {
            var time = this.UsedSecond;

            //var comsize = System.Utility.Helper.File.GetFileSize((long)this.Completed, "F4");
            var comsize = ((long)this.Completed).ToString("F4");

            string speed = "0KB";
            if (time > 0)
            {
                //speed = System.Utility.Helper.File.GetFileSize((long)(this.Completed / time));
                speed = string.Format("{0}KB", (long)this.Completed / time);
            }
            this.Message = string.Format(this.MessageFormat, this._totalDesc, comsize, speed);
        }
    }
}
