using System.Configuration;

namespace DBVersionControl.CustomSection
{
    [ConfigurationCollection(typeof(VersionsElement), AddItemName = "Version",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class VersionsCollection : ConfigurationElementCollection
    {
        #region Properties

        protected override ConfigurationElement CreateNewElement()
        {
            return new VersionsElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((VersionsElement)element).ApplyTo;
        }

        public VersionsElement this[int index]
        {
            get
            {
                return (VersionsElement)BaseGet(index);
            }
        }

        public new VersionsElement this[string name]
        {
            get
            {
                return (VersionsElement)BaseGet(name);
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "Version";
            }
        }

        #endregion
    }
}