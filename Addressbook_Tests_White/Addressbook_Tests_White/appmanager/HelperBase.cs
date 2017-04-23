using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Addressbook_Tests_White
{
    public class HelperBase
    {
        protected ApplicationManager manager;


        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}