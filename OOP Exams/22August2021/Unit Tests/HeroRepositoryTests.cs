using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestCreateHero()
    {
        //if (hero == null)
        //{
        //    throw new ArgumentNullException(nameof(hero), "Hero is null");
        //}
        HeroRepository hr = new HeroRepository();

        Hero h = null;
        Assert.Throws<ArgumentNullException>(()
            => hr.Create(h), "Hero is null");

    }
    [Test]
    public void TestCreateHeroAny()
    {
        //if (this.data.Any(h => h.Name == hero.Name))
        //{
        //    throw new InvalidOperationException($"Hero with name {hero.Name} already exists");
        //}
        HeroRepository heroRepository = new HeroRepository();
        Hero h = new Hero("ds", 4);
        heroRepository.Create(h);
        Hero h1 = new Hero("ds", 7);
        Assert.Throws<InvalidOperationException>(()
            => heroRepository.Create(h1), $"Hero with name {h.Name} already exists");

    }
    [Test]
    public void TestCreateS()
    {
        HeroRepository hr = new HeroRepository();
        Hero h = new Hero("sd", 5);
        hr.Create(h);
        Assert.AreEqual(hr.Heroes.Count, 1);
        //$"Successfully added hero {hero.Name} with level {hero.Level}";?
        
    }
    [Test]
    public void TestRemoveIsNullor()
    {
        //if (String.IsNullOrWhiteSpace(name))
        //{
        //    throw new ArgumentNullException(nameof(name), "Name cannot be null");
        //}
        HeroRepository hr = new HeroRepository();
        Hero h = new Hero(null, 6);
        hr.Create(h);
        Assert.Throws<ArgumentNullException>(()
            => hr.Remove(null), "Name cannot be null");
    }
    [Test]
    public void TestRemoveWS()
    {
        HeroRepository hr = new HeroRepository();
        Hero h = new Hero("", 6);
        hr.Create(h);
        Assert.Throws<ArgumentNullException>(()
            => hr.Remove(""), "Name cannot be null");

    }
    [Test]
    public void TestRemove()
    {
        HeroRepository hr = new HeroRepository();
        Hero h = new Hero("sd", 6);
        hr.Create(h);
        hr.Remove("sd");
        Assert.AreEqual(hr.Heroes.Count, 0);
    }
    [Test]
    public void TestGetHLevel()
    {
        HeroRepository hr = new HeroRepository();
        Hero h = new Hero("sd", 6);
        Hero h1 = new Hero("f", 15);
        hr.Create(h);
        hr.Create(h1);
        //hr.GetHeroWithHighestLevel();
        Assert.AreEqual(hr.GetHeroWithHighestLevel(), h1);
    }
    [Test]
    public void TestGetHeto()
    {
        HeroRepository hr = new HeroRepository();
        Hero h = new Hero("sd", 6);
        Hero h1 = new Hero("f", 15);
        hr.Create(h);
        hr.Create(h1);
        Assert.AreEqual(hr.GetHero("sd"), h);
    }
    
}