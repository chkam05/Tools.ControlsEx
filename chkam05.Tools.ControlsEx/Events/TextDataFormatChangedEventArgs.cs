using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Events
{
    public class TextDataFormatChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public string DataFormat { get; private set; }
        

        //  GETTERS & SETTERS

        public string ConversionMethod
        {
            get => TextDataConversionMethod.FromDataFormat(DataFormat);
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextDataFormatChangedEventArgs class constructor. </summary>
        /// <param name="dataFormat"> Selected text data format. </param>
        public TextDataFormatChangedEventArgs(string dataFormat) : base()
        {
            DataFormat = dataFormat;
        }

        #endregion CLASS METHODS

    }
}
