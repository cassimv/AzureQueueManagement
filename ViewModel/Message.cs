using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace AzureQueuesModel
{
    public class Message
    {
        [Required]
        [DisplayName("Message Details")]
        public string MessageDetails { get; set; }
    }
}
