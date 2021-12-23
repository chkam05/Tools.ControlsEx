using System.Windows;


namespace chkam05.DotNetTools.ExtendedControls.Data.EventsModels
{
    public class TextChangeEventArgs : RoutedEventArgs
    {

        //  VARIABLES

        public bool ProgrammaticallyChanged { get; private set; }
        public string Text { get; private set; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextChangedEventArgs class constructor. </summary>
        /// <param name="text"> Text. </param>
        /// <param name="programmaticallyChanged"> If event was invoked by code. </param>
        public TextChangeEventArgs(string text, bool programmaticallyChanged)
        {
            ProgrammaticallyChanged = programmaticallyChanged;
            Text = text;
        }

    }
}
