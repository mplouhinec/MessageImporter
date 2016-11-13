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

        #region Operators

        public static bool operator ==(Message msg1, Message msg2)
        {
            bool isEqual = false;
            if (msg1.Date == msg2.Date && msg1.Sender == msg2.Sender && msg1.Recipient == msg2.Recipient && msg1.Content == msg2.Content)
            {
                isEqual = true;
            }
            return isEqual;
        }

        public static bool operator !=(Message msg1, Message msg2)
        {
            return !(msg1 == msg2);
        }



        #endregion

        #region Override

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var msg = obj as Message;

            return (this == msg);
            
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Date) ? Date.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Recipient) ? Recipient.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Sender) ? Sender.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Content) ? Content.GetHashCode() : 0);
                return hash;
            }
        }


        #endregion
    }
}
