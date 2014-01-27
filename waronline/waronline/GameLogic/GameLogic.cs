using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using waronline.Data;

namespace waronline.GameLogic
{
    public class SendMessageEventArgs
    {
        public SendMessageEventArgs(IMessage message) { Message = message; }
        public IMessage Message { get; private set; } // readonly
    }

    public abstract class GameLogic
    {
        public abstract void HandleMessage(IMessage message);

        public delegate void SendMessageEvent(object sender, SendMessageEventArgs e);

        public event SendMessageEvent SendMessage;

        // <summary>
        // Reset to a point that would be considered the "beginning" of the game.
        // </summary>
        public abstract void Reset();

        protected virtual void RaiseSendMessageEvent(IMessage message)
        {
            if (SendMessage != null)
            {
                SendMessage(this, new SendMessageEventArgs(message));
            }
        }
    }
}
