
namespace CollectionHierarchy.Core
{
    using CollectionHierarchy.IO.Contracts;
    using CollectionHierarchy.Models;
    using CollectionHierarchy.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Start()
        {
            string[] inputToAdd = Console.ReadLine().Split();
            int amountToRemove = int.Parse(Console.ReadLine());
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();
            AddToCollection(addCollection, inputToAdd);
            AddToCollection(addRemoveCollection, inputToAdd);
            AddToCollection(myList, inputToAdd);
            RemoveFromCollectoin(addRemoveCollection, amountToRemove);
            RemoveFromCollectoin(myList, amountToRemove);
            
        }
        private static void AddToCollection(IAddCollection<string> collection, string[] inputToAdd)
        {
            foreach (var item in inputToAdd)
            {
                Console.Write(collection.Add(item) + " ");
            }
            Console.WriteLine();
        }
        private static void RemoveFromCollectoin(IAddRemoveCollection<string> collection, int amountToRemove)
        {
            for (int i = 0; i < amountToRemove; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }

    }
}
