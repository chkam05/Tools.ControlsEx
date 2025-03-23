using chkam05.Tools.ControlsEx.Data.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Interfaces
{
    public interface IFrameEx<T> where T : Page
    {

        //  GETTERS & SETTERS

        FrameNavigationServiceEx<T> NavigationService { get; set; }

    }
}
