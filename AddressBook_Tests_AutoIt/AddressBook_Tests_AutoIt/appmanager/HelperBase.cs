using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoItX3Lib;

namespace AddressBook_Tests_AutoIt
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}