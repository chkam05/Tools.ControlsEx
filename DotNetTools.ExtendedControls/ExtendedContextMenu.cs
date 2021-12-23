using System.Windows;
using System.Windows.Controls;


namespace chkam05.DotNetTools.ExtendedControls
{
    public class ExtendedContextMenu : ContextMenu
    {

        //  CONST

        private static readonly CornerRadius CORNER_RADIUS_DEFAULT = new CornerRadius(4);


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius), typeof(CornerRadius), typeof(ExtendedContextMenu),
            new PropertyMetadata(CORNER_RADIUS_DEFAULT));


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtendedContextMenu class constructor. </summary>
        public ExtendedContextMenu() : base()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static class constructor to override default style. </summary>
        static ExtendedContextMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedContextMenu),
                new FrameworkPropertyMetadata(typeof(ExtendedContextMenu)));
        }

        #endregion CLASS METHODS

    }
}
