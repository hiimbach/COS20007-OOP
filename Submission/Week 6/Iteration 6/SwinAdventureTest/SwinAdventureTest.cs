using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture]
    public class Tests2  
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
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            Bach.ChangeLocationTo(hogwarts);

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

    public class Tests3
    {
        [Test]
        public void BagLocatesItems()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Level 1 Bag", "This is a level 1 bag, try to find a better bag");
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

    public class Tests4
    {

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
            Assert.That(command.Execute(Bach, new string[] { "look", "at", "gem" }), Is.EqualTo(gem.FullDescription));
        }

        [Test]
        public void LookAtUnk()
        {
            Player Bach = new Player("Bach", "The TBF");
            Item gem = new Item(new string[] { "gem" }, "Light gem", "Brings the light to outshine the darkness");
            Bach.Inventory.Put(gem);
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            Bach.ChangeLocationTo(hogwarts);
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
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            Bach.ChangeLocationTo(hogwarts);
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

    public class Test6
    {
        [Test]
        public void IndentifyThemselves()
        {
            Player player = new Player("Bach", "The TBF");
            LookCommand command = new LookCommand();

            //Location
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            player.ChangeLocationTo(hogwarts);
            Item judgement_book = new Item(new string[] { "spellbook" }, "Spellbook of Judment", "More books! Moreee!");
            Item dark_orb = new Item(new string[] { "orb" }, "The orb of dark magic", "Shadow is commingg!");
            hogwarts.Inventory.Put(judgement_book);
            hogwarts.Inventory.Put(dark_orb);

            string identify_themselves = command.Execute(player, new string[] { "look", "at", "location" });
            Assert.That(identify_themselves, Is.EqualTo("Wizard School"));

        }

        [Test]
        public void LocationIdentifyItem()
        {
            Player player = new Player("Bach", "The TBF");
            LookCommand command = new LookCommand();

            //Location
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            player.ChangeLocationTo(hogwarts);
            Item judgement_book = new Item(new string[] { "spellbook" }, "Spellbook of Judment", "More books! Moreee!");
            Item dark_orb = new Item(new string[] { "orb" }, "The orb of dark magic", "Shadow is commingg!");
            hogwarts.Inventory.Put(judgement_book);
            hogwarts.Inventory.Put(dark_orb);

            GameObject location_identify_item = hogwarts.Locate("orb");
            Assert.That(location_identify_item, Is.EqualTo(dark_orb));

        }

        [Test]
        public void IndentifyItemInLocation()
        {
            Player player = new Player("Bach", "The TBF");
            LookCommand command = new LookCommand();

            //Location
            Location hogwarts = new Location("Hogwarts", "Wizard School");
            player.ChangeLocationTo(hogwarts);
            Item judgement_book = new Item(new string[] { "spellbook" }, "Spellbook of Judment", "More books! Moreee!");
            Item dark_orb = new Item(new string[] { "orb" }, "The orb of dark magic", "Shadow is commingg!");
            hogwarts.Inventory.Put(judgement_book);
            hogwarts.Inventory.Put(dark_orb);

            string identify_item_in_location = command.Execute(player, new string[] { "look", "at", "orb", "in", "location" });
            Assert.That(identify_item_in_location, Is.EqualTo("Shadow is commingg!"));

        }
    }
}