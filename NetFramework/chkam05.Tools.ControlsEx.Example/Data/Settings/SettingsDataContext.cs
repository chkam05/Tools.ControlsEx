using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Theme;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data.Settings
{
    public class SettingsDataContext : BaseViewModel
    {

        //  VARIABLES

        private ThemeDataModel theme;
        private ColorPaletteExCollection usedColorsCollection;
        private SettingsWindow window;


        //  GETTERS & SETTERS

        public ThemeDataModel Theme
        {
            get => theme;
            set => UpdateProperty(ref theme, value);
        }

        public ColorPaletteExCollection UsedColorsCollection
        {
            get => usedColorsCollection;
            set => UpdateUsedColorsCollectionProperty(value);
        }

        public SettingsWindow Window
        {
            get => window;
            set => UpdateProperty(ref window, value);
        }


        //  METHODS

        #region CLASS CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsDataContext class constructor. </summary>
        public SettingsDataContext(
            ThemeDataModel theme = null,
            ColorPaletteExCollection usedColorsCollection = null,
            SettingsWindow window = null)
        {
            Theme = theme ?? new ThemeDataModel();
            UsedColorsCollection = usedColorsCollection ?? SetupDefaultUsedColorsCollection();
            Window = window ?? new SettingsWindow();
        }

        #endregion CLASS CONSTRUCTORS

        #region PROPERTIES CHANGED NOTIFICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers a property changed notification event after UsedColorsCollection change. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify collection changed event arguments. </param>
        private void UsedColorsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(UsedColorsCollection));
        }

        #endregion PROPERTIES CHANGED NOTIFICATION

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a UsedColorsCollection property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        private void UpdateUsedColorsCollectionProperty(ColorPaletteExCollection newValue)
        {
            if (usedColorsCollection != null)
                usedColorsCollection.CollectionChanged -= UsedColorsCollectionChanged;

            usedColorsCollection = newValue;
            usedColorsCollection.CollectionChanged += UsedColorsCollectionChanged;

            NotifyPropertyChanged(nameof(UsedColorsCollection));
        }

        #endregion PROPERTIES MANAGEMENT

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup UsedColorsCollection with default values. </summary>
        /// <returns> Default UsedColorsCollection. </returns>
        private ColorPaletteExCollection SetupDefaultUsedColorsCollection()
        {
            return new ColorPaletteExCollection(false)
            {
                new ColorPaletteExItem(ColorsResources.Blue),
                new ColorPaletteExItem(ColorsResources.LightlyOrchid),
                new ColorPaletteExItem(ColorsResources.DarkOrange),
                new ColorPaletteExItem(ColorsResources.SteelBlue),
                new ColorPaletteExItem(ColorsResources.BrightlyIridescent),
            };
        }

        #endregion SETUP METHODS

    }
}
