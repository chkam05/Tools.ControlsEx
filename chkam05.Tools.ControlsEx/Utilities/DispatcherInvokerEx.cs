﻿using System;
using System.Collections.Generic;
using System.Windows.Threading;


namespace chkam05.Tools.ControlsEx.Utilities
{
    public class DispatcherInvokerEx
    {

        //  VARIABLES

        public Dispatcher Dispatcher { get; private set; }
        public Stack<Exception> Exceptions { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DispatcherInvoker class constructor. </summary>
        /// <param name="dispatcher"> Dispatcher. </param>
        public DispatcherInvokerEx(Dispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            Exceptions = new Stack<Exception>();
        }

        #endregion CLASS METHODS

        #region INVOKE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Try invoke action method. </summary>
        /// <param name="invokingMethod"> Action method to invoke. </param>
        /// <returns> True - method invoked correctly; False - otherwise. </returns>
        public bool TryInvoke(Action invokingMethod)
        {
            bool result = false;

            try
            {
                Dispatcher.Invoke(() =>
                {
                    try
                    {
                        invokingMethod.Invoke();
                        result = true;
                    }
                    catch (Exception exc)
                    {
                        Exceptions.Push(exc);
                        result = false;
                    }
                });
            }
            catch (Exception exc)
            {
                Exceptions.Push(exc);
                return false;
            }

            return result;
        }

        #endregion INVOKE METHODS

    }
}
