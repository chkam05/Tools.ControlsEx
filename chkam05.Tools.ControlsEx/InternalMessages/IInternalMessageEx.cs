using chkam05.Tools.ControlsEx.Data;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public interface IInternalMessageEx
    {

        //  GETTERS & SETTERS

        bool AllowHide { get; set; }

        bool IsHidden { get; }

        bool IsLoadingComplete { get; }

        InternalMessageResult Result { get; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Close InternalMessage. </summary>
        void Close();

        //  --------------------------------------------------------------------------------
        /// <summary> Hide InternalMessage if it is allowed. </summary>
        void Hide();

        //  --------------------------------------------------------------------------------
        /// <summary> Show hidden InternalMessage. </summary>
        void Show();

    }
}
