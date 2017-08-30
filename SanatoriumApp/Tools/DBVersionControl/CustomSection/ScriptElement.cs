using System;
using System.Configuration;

namespace DBVersionControl.CustomSection
{
    public class ScriptElement : ConfigurationElement
    {
        #region Properties

        [ConfigurationProperty("name")]
        public String Name
        {
            get
            {
                return (String)base["name"];
            }
        }

        #endregion
    }
}