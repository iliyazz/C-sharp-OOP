using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();
            strings.Add("str1");
            strings.Add("str2");
            strings.Add("str3");
            strings.Add("str4");
            strings.Add("str5");
            strings.RandomString();
            strings.RandomString();
            strings.RandomString();
            strings.RandomString();
            strings.RandomString();
            strings.RandomString();
            strings.RandomString();
        }
    }
}
