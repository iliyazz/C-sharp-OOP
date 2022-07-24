namespace AuthorProblem
{
    using System;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            foreach (var method in type.GetMethods((BindingFlags)60))
            {
                object[] attributeObjects = method.GetCustomAttributes(false);
                foreach (var attributeObject in attributeObjects)
                {
                    AuthorAttribute authorAttribute = attributeObject as AuthorAttribute;
                    if (authorAttribute != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            } 
        }
    }
}
