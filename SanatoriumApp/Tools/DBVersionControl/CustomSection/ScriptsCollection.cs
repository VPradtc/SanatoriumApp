using System.Configuration;

namespace DBVersionControl.CustomSection
{
    [ConfigurationCollection(typeof(ScriptElement), AddItemName = "script",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ScriptsCollection : ConfigurationElementCollection
    {
        #region Properties

        [ConfigurationProperty("location")]
        public string Location
        {
            get
            {
                return (string)base["location"];
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ScriptElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ScriptElement)element).Name;
        }

        public ScriptElement this[int index]
        {
            get
            {
                return (ScriptElement)BaseGet(index);
            }
        }

        public new ScriptElement this[string name]
        {
            get
            {
                return (ScriptElement)BaseGet(name);
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
                return "script";
            }
        }

        #endregion
    }
}