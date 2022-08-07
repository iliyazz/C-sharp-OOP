using System;
using NUnit.Framework;
using System;
using System.Numerics;

public class HeroRepositoryTests
{

    [Test]
    public void CreateShouldThrowExceptionIfHeroIsNull()
    {
        Hero hero = null;//new Hero("name1", 20);
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        }, "Hero is null");
    }

    [Test]
    public void CreateShouldThrowExceptionIfHeroExistInCollection()
    {
        Hero hero =new Hero("name1", 20);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        }, $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void CreateShouldAddHeroToCollection()
    {
        Hero hero = new Hero("name1", 20);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        Assert.AreSame(hero, heroRepository.GetHero("name1"));
        string expectedReturn = $"Successfully added hero {hero.Name} with level {hero.Level}";
        string actualReturn = $"Successfully added hero {heroRepository.GetHero("name1").Name} with level {heroRepository.GetHero("name1").Level}";
        Assert.AreEqual(expectedReturn, actualReturn);
    }

    [TestCase(null)]
    [TestCase("")]
    public void RemoveShouldThrowExceptionIfHeroNameIsNullOrWhiteSpace(string name)
    {
        Hero hero1 = new Hero("name1", 20);
        Hero hero2 = new Hero("name2", 22);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(name);
        }, "Name cannot be null");
    }

    [Test]
    public void RemoveShouldThrowExceptionIfHeroNameIsNullOrWhiteSpace()
    {
        Hero hero1 = new Hero("name1", 20);
        Hero hero2 = new Hero("name2", 22);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Remove("name1");
        Assert.That(heroRepository.GetHero("name1") == null);
        Assert.That(heroRepository.Remove("name2") == true);
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnCorrectResult()
    {
        Hero hero1 = new Hero("name1", 20);
        Hero hero2 = new Hero("name2", 22);
        Hero hero3 = new Hero("name3", 12);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        Hero actualHero = heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual("name2", actualHero.Name);
        Assert.AreEqual(22, actualHero.Level);
    }

    [Test]
    public void HeroRepositoryListShouldWorkCorrectly()
    {
        Hero hero1 = new Hero("name1", 20);
        Hero hero2 = new Hero("name2", 22);
        Hero hero3 = new Hero("name3", 12);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        int expectedCount = 3;
        int actualCount = heroRepository.Heroes.Count;
        Assert.AreEqual(expectedCount, actualCount);
    }

}