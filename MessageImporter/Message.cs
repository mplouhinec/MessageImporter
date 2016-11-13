using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageImporter
{
    /// <summary>
    /// Base Class for a message
    /// </summary>
    public class Message
    {
        #region Properties

        public DateTime Date { get; set; }

        public string Recipient { get; set; }

        public string Sender { get; set; }

        public string Content { get; set; }

        #endregion
    }
}
