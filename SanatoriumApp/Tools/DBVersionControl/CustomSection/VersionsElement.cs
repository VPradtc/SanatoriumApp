using System;
using System.Configuration;

namespace DBVersionControl.CustomSection
{
    public class VersionsElement : ConfigurationElement
    {
        #region Properties

        [ConfigurationProperty("number")]
        public String Number
        {
            get
            {
                return (String)base["number"];
            }
        }

        [ConfigurationProperty("applyTo")]
        public String ApplyTo
        {
            get
            {
                return (String)base["applyTo"];
            }
        }

        [ConfigurationProperty("Scripts", IsDefaultCollection = false)]
        public ScriptsCollection Scripts
        {
            get
            {
                return (ScriptsCollection)base["Scripts"];
            }
        }

        #endregion
    }
}