using System.Configuration;

namespace DBVersionControl.CustomSection
{
    public class DBVersionsSection : ConfigurationSection
    {
        #region Properties

        [ConfigurationProperty("Versions", IsDefaultCollection = false)]
        public VersionsCollection Versions
        {
            get
            {
                return (VersionsCollection)base["Versions"];
            }
        }

        [ConfigurationProperty("RootVersion")]
        public VersionsElement RootVersion
        {
            get
            {
                return (VersionsElement)base["RootVersion"];
            }
        }
        [ConfigurationProperty("CreateDB")]
        public VersionsElement CreateDB
        {
            get
            {
                return (VersionsElement)base["CreateDB"];
            }
        }

        #endregion
    }
}