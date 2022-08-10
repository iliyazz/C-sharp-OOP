using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldCreateCorrectObject()
        {
            Dictionary<string, Item> expectedDictionary = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            BankVault test = new BankVault();
            CollectionAssert.AreEqual(expectedDictionary, test.VaultCells);
        }

        [Test]
        public void AddItemShouldThrowExceptionIfCellDoesNotExist()
        {
            BankVault test = new BankVault();
            Assert.Throws<ArgumentException>(() =>
            {
                test.AddItem("inexistingCell", null);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemShouldThrowExceptionIfCellIsNotNull()
        {
            Item item = new Item("name1", "name1ID");
            Item item2 = new Item("name2", "name2ID");
            BankVault test = new BankVault();
            test.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                test.AddItem("A1", item2);
            }, "Cell is already taken!");
        }

        [Test]
        public void AddItemShouldThrowExceptionIfAnyCellHaveSameValue()
        {
            Item item = new Item("name1", "name1ID");
            Item item2 = new Item("name2", "name1ID");
            BankVault test = new BankVault();
            test.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                test.AddItem("B1", item2);
            }, "Item is already in cell!");
            Assert.AreEqual(item, test.VaultCells["A1"]);
        }

        [Test]
        public void AddItemShouldReturnCorrectString()
        {
            Item item1 = new Item("name1", "name1ID");
            BankVault test = new BankVault();
            string expectedString = $"Item:{item1.ItemId} saved successfully!";
            string actualString = test.AddItem("A1", item1);
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void RemoveItemShouldThrowExceptionIfCellDoesNotExist()
        {
            Item item1 = new Item("name1", "name1ID");
            Item item2 = new Item("name2", "name2ID");
            BankVault test = new BankVault();
            test.AddItem("A1", item1);
            Assert.Throws<ArgumentException>(() =>
            {
                test.RemoveItem("F2", item2);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItemShouldThrowExceptionIfCellValueIsDifferent()
        {
            Item item1 = new Item("name1", "name1ID");
            Item item2 = new Item("name2", "name2ID");
            BankVault test = new BankVault();
            test.AddItem("A1", item1);
            Assert.Throws<ArgumentException>(() =>
            {
                test.RemoveItem("A1", item2);
            }, "Cell doesn't exists!");
        }
        [Test]
        public void AfterRemoveItemCellValueShouldBeNull()
        {
            Item item1 = new Item("name1", "name1ID");
            //Item item2 = new Item("name2", "name2ID");
            BankVault test = new BankVault();
            test.AddItem("A1", item1);
            Assert.IsNotNull(test.VaultCells["A1"]);
            test.RemoveItem("A1", item1);
            Assert.IsNull(test.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItemShouldReturnCorrectString()
        {
            Item item1 = new Item("name1", "name1ID");
            BankVault test = new BankVault();
            test.AddItem("A1", item1);
            string expectedString = $"Remove item:{item1.ItemId} successfully!";
            string actualString = test.RemoveItem("A1", item1);
            Assert.AreEqual(expectedString, actualString);
        }
    }
}