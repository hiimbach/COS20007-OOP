using NUnit.Framework;


namespace Iteration2
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void ItemUnitTest()
        {
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            bool identifiable = dark_sword.AreYou("sword");
            string short_description = dark_sword.ShortDescription;
            string full_description = dark_sword.FullDescription;
            Assert.IsTrue(identifiable);
            Assert.That(short_description, Is.EqualTo("a Dark Sword (sword)"));
            Assert.That(full_description, Is.EqualTo("Destroy everything with dark magiccc!"));
        }

        [Test]
        public void InventoryUnitTest()
        {
            Player Bach = new Player("Bach", "Handsome");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eatting tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            Bach.Inventory.Put(dark_sword);
            Bach.Inventory.Put(steel_spoon);

            bool find_item = Bach.Inventory.HasItem("sword");
            Assert.IsTrue(find_item);

            bool no_item_find = Bach.Inventory.HasItem("knife");
            Assert.IsFalse(no_item_find);

            string item_list = Bach.Inventory.ItemList;
            Assert.That(item_list, Is.EqualTo($"- a Dark Sword (sword)\n- a Steel spoon (eatting tool)\n"));

            Item fetch_item = Bach.Inventory.Fetch("sword");
            Assert.That(fetch_item, Is.EqualTo(dark_sword));

            Item take_item = Bach.Inventory.Take("eatting tool");
            Assert.That(take_item, Is.EqualTo(steel_spoon));

            

        }

        [Test]
        public void PlayerUnitTest()
        {
            Player Bach = new Player("Bach", "Handsome");
            Item dark_sword = new Item(new string[] { "sword" }, "Dark Sword", "Destroy everything with dark magiccc!");
            Item steel_spoon = new Item(new string[] { "eatting tool" }, "Steel spoon", "Just use to eat, definitely useless in fighting :)");
            Bach.Inventory.Put(dark_sword);
            Bach.Inventory.Put(steel_spoon);

            bool player_is_identifiable = Bach.AreYou("inventory");
            Assert.IsTrue(player_is_identifiable);

            GameObject player_locate_item = Bach.Locate("sword");
            Assert.That(player_locate_item, Is.EqualTo(dark_sword));

            GameObject player_locate_itself = Bach.Locate("inventory");
            Assert.That(player_locate_itself, Is.EqualTo(Bach));

            GameObject player_locate_nothing = Bach.Locate("knife");
            Assert.That(player_locate_nothing, Is.EqualTo(null));

            string player_full_description = Bach.FullDescription;
            Assert.That(player_full_description, Is.EqualTo($"Hello mighty Bach. \nYou are carrying: \n- a Dark Sword (sword)\n- a Steel spoon (eatting tool)\n"));


        }

    }
}