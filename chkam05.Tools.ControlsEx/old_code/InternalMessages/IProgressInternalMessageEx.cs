using chkam05.Tools.ControlsEx.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public interface IProgressInternalMessageEx
    {

        //  EVENTS

        event ProgressInternalMessageCancel ProgressCancel;


        //  VARIABLES

        bool AllowCancel { get; set; }
        bool IsFinished { get; }
        bool KeepOnScreenCompleted { get; set; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke finish method. </summary>
        /// <param name="forceResult"> Forced result value. </param>
        void InvokeFinish(InternalMessageResult? forceResult = null);

    }
}
