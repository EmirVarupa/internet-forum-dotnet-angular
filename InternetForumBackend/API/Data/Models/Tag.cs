using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Tag
    {
        /// <summary>
        /// Id of Tag
        /// </summary>
        public int TagId { get; set; }
        /// <summary>
        /// Tag name
        /// </summary>
        public string TagName { get; set; }
    }
}