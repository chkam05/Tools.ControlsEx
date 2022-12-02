using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data
{
    public class FontFamilyInfo : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private FontFamily _fontFamily;
        private string _name;
        private string _subName;
        private bool _isCustomFont;


        //  GETTERS & SETTERS

        public FontFamily FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value;
                OnPropertyChanged(nameof(FontFamily));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string SubName
        {
            get => _subName;
            set
            {
                _subName = value;
                OnPropertyChanged(nameof(SubName));
            }
        }

        public bool IsCustomFont
        {
            get => _isCustomFont;
            set
            {
                _isCustomFont = value;
                OnPropertyChanged(nameof(IsCustomFont));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FontFamilyInfo class constructor for Json serialization. </summary>
        public FontFamilyInfo()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> FontFamilyInfo class constructor. </summary>
        /// <param name="fontFamily"> Font family. </param>
        /// <param name="isAppFont"> Is application font. </param>
        public FontFamilyInfo(FontFamily fontFamily, bool isAppFont = false)
        {
            FontFamily = fontFamily;
            Name = fontFamily.FamilyNames.First().Value;
            IsCustomFont = isAppFont;

            if (fontFamily.Source.Contains("./#"))
                SubName = fontFamily.Source
                    .Replace("./#", "")
                    .Replace(Name, "")
                    .Trim();
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region OBJECT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a string that represents the current object. </summary>
        /// <returns> A string that represents the current object. </returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if (!string.IsNullOrEmpty(SubName))
                    return $"{Name} {SubName}";

                return Name;
            }

            return base.ToString();
        }

        #endregion OBJECT METHODS

    }
}
