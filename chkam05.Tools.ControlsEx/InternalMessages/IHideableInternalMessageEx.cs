using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static chkam05.Tools.ControlsEx.Events.Delegates;

namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public interface IHideableInternalMessageEx
    {

        //  EVENTS

        event InternalMessageHide MessageHide;


        //  GETTERS & SETTERS

        bool AllowHide { get; set; }

        bool IsHidden { get; set; }

    }
}
