using NUnit.Framework;

namespace Iteration3
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BagLocatesItems()
        {
            Bag bag = new Bag(new string[] {"bag"}, "Level 1 Bag", "This is a level 1 bag, try to find a better bag");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            bag.Inventory.Put(dark_sword);
            GameObject bag_locate_items = bag.Locate("sword");
            Assert.That(bag_locate_items, Is.EqualTo(dark_sword));

        }

        [Test]
        public void BagLocatesItself()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Level 1 Bag", "This is a level 1 bag, try to find a better bag");
            GameObject bag_locate_itself = bag.Locate("bag");
            Assert.That(bag_locate_itself, Is.EqualTo(bag));
        }

        [Test]
        public void BagLocatesNothing()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Level 1 Bag", "This is a level 1 bag, try to find a better bag");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            bag.Inventory.Put(dark_sword);
            GameObject bag_locate_nothing = bag.Locate("spoon");
            Assert.That(bag_locate_nothing, Is.EqualTo(null));
        }

        [Test]
        public void BagFullDescription()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Level 1 Bag", "This is a level 1 bag, try to find a better bag");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eatting tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            bag.Inventory.Put(dark_sword);
            bag.Inventory.Put(steel_spoon);
            string bag_full_description = bag.FullDescription;
            Assert.That(bag_full_description, Is.EqualTo("In the Level 1 Bag you can see: \n- a Dark Sword (sword)\n- a Steel spoon (eatting tool)\n"));
        }

        [Test]
        public void BagInBag()
        {
            Bag bag1 = new Bag(new string[] { "bag" }, "Level 1 Bag", "This is a level 1 bag, try to find a better bag");
            Bag bag2 = new Bag(new string[] { "bag" }, "Level 2 Bag", "This is a level 2 bag, good bag but no enough");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eatting tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            bag1.Inventory.Put(dark_sword);
            bag2.Inventory.Put(steel_spoon);

            // Assert that item in bag 1 can be located
            GameObject bag1_item = bag1.Locate("sword");
            Assert.That(bag1_item, Is.EqualTo(dark_sword));

            // Assert that item in bag 2 can not be located by bag 1
            GameObject bag2_item_in_bag1 = bag1.Locate("eatting tool");
            GameObject bag2_item_in_bag2 = bag2.Locate("eatting tool");
            Assert.That(bag2_item_in_bag1, Is.EqualTo(null));
            Assert.That(bag2_item_in_bag2, Is.EqualTo(steel_spoon));

        }


    }
}