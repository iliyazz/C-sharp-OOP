namespace AuthorProblem
{
    using System;
    [Author("GeorgeI")]
    [Author("GeorgeII")]
    public class StartUp
    {
        [Author("GeorgeIV")]
        static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}