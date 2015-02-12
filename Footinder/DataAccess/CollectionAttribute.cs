using System;

namespace Footinder.DataAccess
{
    public class CollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public CollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}