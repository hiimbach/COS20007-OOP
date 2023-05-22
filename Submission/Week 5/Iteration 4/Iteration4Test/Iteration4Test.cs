using NUnit.Framework;

namespace Iteration4
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroys everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eating tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            Bach.Inventory.Put(dark_sword);
            Bach.Inventory.Put(steel_spoon);

            Bag simple_bag = new Bag(new string[] { "bag" }, "level 1 bag", "Just a simple bag");
            Item legend_knife = new Item(new string[] { "knife" }, "Legend knife", "Brings the power of Godsss");
            simple_bag.Inventory.Put(legend_knife);
            Bach.Inventory.Put(simple_bag);
            LookCommand command = new LookCommand();
        }

        [Test]
        public void LookAtMe()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroys everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eating tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            Bach.Inventory.Put(dark_sword);
            Bach.Inventory.Put(steel_spoon);

            Bag simple_bag = new Bag(new string[] { "bag" }, "level 1 bag", "Just a simple bag");
            Item legend_knife = new Item(new string[] { "knife" }, "Legend knife", "Brings the power of Godsss");
            simple_bag.Inventory.Put(legend_knife);
            Bach.Inventory.Put(simple_bag);

            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "inventory" }), Is.EqualTo("Hello mighty Bach. \nYou are carrying: \n- a Dark Sword (sword)\n- a Steel spoon (eating tool)\n- a level 1 bag (bag)\n"));

        }

        [Test]
        public void LookAtGem()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bach.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[]{ "look", "at", "gem"}), Is.EqualTo(gem.FullDescription));
        }

        [Test]
        public void LookAtUnk()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bach.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "unk" }), Is.EqualTo("I can't find the unk"));
        }

        [Test]
        public void LookAtGemInMe()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bach.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "gem", "in", "inventory" }), Is.EqualTo(gem.FullDescription));
        }

        [Test]
        public void LookAtGemInBag()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bag simple_bag = new Bag(new string[] { "bag" }, "level 1 bag", "Just a simple bag");
            simple_bag.Inventory.Put(gem);
            Bach.Inventory.Put(simple_bag);
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo(gem.FullDescription));
        }

        [Test]
        public void LookAtGemInNoBag()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bag simple_bag = new Bag(new string[] { "bag" }, "level 1 bag", "Just a simple bag");
            simple_bag.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I can't find the bag"));
        }

        [Test]
        public void LookAtNoGemInBag()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bag simple_bag = new Bag(new string[] { "bag" }, "level 1 bag", "Just a simple bag");
            Bach.Inventory.Put(simple_bag);
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void InvalidLook()
        {
            Player Bach = new Player("Bach", "The TBF");
            LookCommand command = new LookCommand();
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "my", "gf" }), Is.EqualTo("I don't know how to look like that"));
            Assert.That(command.Execute(Bach, new string[] { "hello", "my", "friend" }), Is.EqualTo("Error in look input"));
            Assert.That(command.Execute(Bach, new string[] { "look", "my", "gf" }), Is.EqualTo("What do you want to look at?"));
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "sword", "my", "bag" }), Is.EqualTo("What do you want to look in"));
        }
    }
}