using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Theme;
using chkam05.Tools.ControlsEx.Example.Data.Settings;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data
{
    public class SettingsPageDataContext : BaseViewModel
    {

        //  VARIABLES

        private ColorPaletteExCollection colorsCollection;
        private ColorPaletteExItem selectedColorItem;
        private ColorPaletteExItem selectedUsedColorItem;
        private ObservableCollection<ThemeType> themeTypesCollection;


        //  GETTERS & SETTERS

        public ColorPaletteExCollection ColorsCollection
        {
            get => colorsCollection;
            set => UpdateColorsCollectionProperty(value);
        }

        public ColorPaletteExItem SelectedColorItem
        {
            get => selectedColorItem;
            set => UpdateSelectedColorItemProperty(value);
        }

        public ColorPaletteExItem SelectedUsedColorItem
        {
            get => selectedUsedColorItem;
            set => UpdateSelectedUsedColorItemProperty(value);
        }

        public ObservableCollection<ThemeType> ThemeTypesCollection
        {
            get => themeTypesCollection;
            set => UpdateThemeTypesCollectionProperty(value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsPageDataContext class constructor. </summary>
        public SettingsPageDataContext()
        {
            SetupColorsCollection();
            SetupThemeTypesCollection();
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES CHANGED NOTIFICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers a property changed notification event after ColorsCollection change. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify collection changed event arguments. </param>
        private void ColorsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(ColorsCollection));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers a property changed notification event after ThemeTypesCollection change. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify collection changed event arguments. </param>
        private void ThemeTypesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(ThemeTypesCollection));
        }

        #endregion PROPERTIES CHANGED NOTIFICATION

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a ColorsCollection property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        private void UpdateColorsCollectionProperty(ColorPaletteExCollection newValue)
        {
            if (colorsCollection != null)
                colorsCollection.CollectionChanged -= ColorsCollectionChanged;

            colorsCollection = newValue;
            colorsCollection.CollectionChanged += ColorsCollectionChanged;

            NotifyPropertyChanged(nameof(ColorsCollection));
        }

        //  --------------------------------------------------------------------------------
        private void UpdateSelectedColorItemProperty(ColorPaletteExItem item)
        {
            if (item == null)
                return;

            selectedColorItem = item;

            NotifyPropertyChanged(nameof(SelectedColorItem));
            UpdateSelectedUsedColorItemProperty(item);
        }

        //  --------------------------------------------------------------------------------
        private void UpdateSelectedUsedColorItemProperty(ColorPaletteExItem item)
        {
            if (item == null)
                return;

            selectedUsedColorItem = item;

            SettingsManager.Instance.AddUsedColor(item);
            NotifyPropertyChanged(nameof(SelectedUsedColorItem));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a ThemeTypesCollection property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        private void UpdateThemeTypesCollectionProperty(ObservableCollection<ThemeType> newValue)
        {
            if (themeTypesCollection != null)
                themeTypesCollection.CollectionChanged -= ThemeTypesCollectionChanged;

            themeTypesCollection = newValue;
            themeTypesCollection.CollectionChanged += ThemeTypesCollectionChanged;

            NotifyPropertyChanged(nameof(ThemeTypesCollection));
        }

        #endregion PROPERTIES MANAGEMENT

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup ColorsCollection values. </summary>
        private void SetupColorsCollection()
        {
            ColorsCollection = new ColorPaletteExCollection(ColorsResources.GetPaletteColors()
                .Select(cx => new ColorPaletteExItem(cx)), false);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ThemeTypesCollection values. </summary>
        private void SetupThemeTypesCollection()
        {
            ThemeTypesCollection = new ObservableCollection<ThemeType>(Enum.GetValues(typeof(ThemeType)).OfType<ThemeType>());
        }

        #endregion SETUP METHODS

    }
}
