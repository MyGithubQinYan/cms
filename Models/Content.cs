using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.Models
{
    /// <summary>
    /// 内容实体
    /// </summary>
    public class Content
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int status { get; set; }
        public DateTime? addTime { get; set; }
        public DateTime? modifyTime { get; set; }
    }
}
