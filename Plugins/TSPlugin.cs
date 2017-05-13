using System;
using NUnit.Framework;

namespace TS.Plugins
{
    public class TSPlugin
    {
        private object target;

        public TSPlugin()
        {
        }

        public virtual object Target
        {
            get { return target; }
            set { target = value; }
        }

        public virtual float Value
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string PropertyName
        {
            get {
                throw new NotImplementedException();
            }
        }

    }

}