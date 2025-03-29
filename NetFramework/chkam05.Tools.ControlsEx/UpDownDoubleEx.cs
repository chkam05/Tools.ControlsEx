using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using static System.Net.Mime.MediaTypeNames;

namespace chkam05.Tools.ControlsEx
{
    public class UpDownDoubleEx : UpDownEx<double>
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            nameof(Maximum),
            typeof(double),
            typeof(UpDownDoubleEx),
            new PropertyMetadata(100d));

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
            nameof(Minimum),
            typeof(double),
            typeof(UpDownDoubleEx),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty StepProperty = DependencyProperty.Register(
            nameof(Step),
            typeof(double),
            typeof(UpDownDoubleEx),
            new PropertyMetadata(1d));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(double),
            typeof(UpDownDoubleEx),
            new PropertyMetadata(50d, OnValuePropertyChanged));


        //  DELEGATES

        public delegate void DoubleUpDownValueChangedExEventHandler(object sender, UpDownDoubleValueChangedEventArgsEx e);


        //  EVENTS

        public event DoubleUpDownValueChangedExEventHandler ValueChangedEx;


        //  GETTERS & SETTERS

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, MathUtilities.Clamp(value, Minimum, double.MaxValue));
        }

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, MathUtilities.Clamp(value, double.MinValue, Maximum));
        }

        public double Step
        {
            get => (double)GetValue(StepProperty);
            set => SetValue(StepProperty, MathUtilities.Clamp(value, 0, Maximum));
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, MathUtilities.Clamp(value, Minimum, Maximum));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownDoubleEx class constructor. </summary>
        public UpDownDoubleEx() : base()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownDoubleEx class constructor. </summary>
        static UpDownDoubleEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownDoubleEx),
                new FrameworkPropertyMetadata(typeof(UpDownDoubleEx)));
        }

        #endregion CONSTRUCTORS

        #region BUTTONS BEHAVIOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking up button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void UpButtonClick(object sender, RoutedEventArgs e)
        {
            Value = Math.Min(Maximum, Value + Step);
            ValueChangedEx?.Invoke(this, new UpDownDoubleValueChangedEventArgsEx(Value, true, true));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking down button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void DownButtonClick(object sender, RoutedEventArgs e)
        {
            Value = Math.Max(Minimum, Value - Step);
            ValueChangedEx?.Invoke(this, new UpDownDoubleValueChangedEventArgsEx(Value, true, true));
        }

        #endregion BUTTONS BEHAVIOR

        #region COMPONENT

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after loading component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            previousValue = Value;
            LockTextBoxValueUpdate(previousValue.ToString());
        }

        #endregion COMPONENT

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #endregion TEMPLATE

        #region TEXTBOX BEHAVIOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after text box lost focus. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                textChanged = false;

                if (ValidateValue(textBox.Text, out string correctValue))
                {
                    lockUpdate = true;

                    if (previousValue.ToString() != correctValue)
                    {
                        var doubleValue = MathUtilities.Clamp(double.Parse(correctValue), Minimum, Maximum);
                        previousValue = doubleValue;
                        textBox.Text = previousValue.ToString();
                        Value = doubleValue;
                        ValueChangedEx?.Invoke(this, new UpDownDoubleValueChangedEventArgsEx(doubleValue, true, true));
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after the contents of the text box change. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Text changed event arguments. </param>
        protected override void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!lockUpdate)
            {
                if (textBox.localFocused)
                {
                    textChanged = true;

                    if (!ValidateValue(textBox.Text, out string correctValue, true))
                    {
                        int carretPosition = textBox.SelectionStart;
                        int textLength = textBox.Text.Length;
                        int textLengthDiff = Math.Max(0, textLength - correctValue.Length);

                        lockUpdate = true;
                        textBox.Text = correctValue;
                        textBox.SelectionStart = Math.Max(0, Math.Min(carretPosition - textLengthDiff, correctValue.Length));
                    }
                }
                else if (!ValidateValue(textBox.Text, out string correctValue))
                {
                    lockUpdate = true;
                    textBox.Text = correctValue;
                }
            }
            else
            {
                lockUpdate = false;
            }
        }

        #endregion TEXTBOX BEHAVIOR

        #region VALUE MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Update text box value in lock mode. </summary>
        /// <param name="newValue"> New value. </param>
        protected override void LockTextBoxValueUpdate(string newValue)
        {
            if (textBox == null)
                return;

            lockUpdate = true;
            textBox.Text = newValue;
            lockUpdate = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after upading Value propery in dependency property. </summary>
        /// <param name="d"> Dependency object that invoked the method. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as UpDownDoubleEx)?.LockTextBoxValueUpdate(e.NewValue.ToString());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Validates a string value to double. </summary>
        /// <param name="newValue"> String value to validate. </param>
        /// <param name="prevValue"> Previous correct value. </param>
        /// <param name="resultValue"> Correct validated value. </param>
        /// <param name="editMode"> Edit mode. </param>
        /// <returns> Returns true if validation was correct, false otherwise. </returns>
        protected override bool ValidateValue(string newValue, out string resultValue, bool editMode = false)
        {
            newValue = newValue.Replace(".", ",");

            if (editMode)
            {
                if (string.IsNullOrEmpty(newValue))
                {
                    resultValue = newValue;
                    return true;
                }

                if (newValue.Length == 1 && (floatingPointSpecialChars.Contains(newValue[0]) || specialChars.Contains(newValue[0])))
                {
                    resultValue = newValue;
                    return true;
                }

                if (newValue.Length > 1)
                {
                    if (newValue == "-,")
                    {
                        resultValue = newValue;
                        return true;
                    }

                    if (floatingPointSpecialChars.Contains(newValue.Last())
                        && double.TryParse(newValue.Substring(0, newValue.Length - 2), out double _))
                    {
                        resultValue = newValue;
                        return true;
                    }

                    if (floatingPointSpecialChars.Contains(newValue.First())
                        && double.TryParse($"0{newValue}", out double _))
                    {
                        resultValue = newValue;
                        return true;
                    }
                }
            }

            bool canConvert = double.TryParse(newValue.ToLower(), out double _);
            resultValue = canConvert ? newValue : previousValue.ToString();
            return canConvert;
        }

        #endregion VALUE MANAGEMENT

    }
}
