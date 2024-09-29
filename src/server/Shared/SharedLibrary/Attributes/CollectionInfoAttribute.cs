namespace SharedLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionInfoAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public CollectionInfoAttribute(string collectionName)
        {
            this.CollectionName = collectionName;
        }
    }
}
