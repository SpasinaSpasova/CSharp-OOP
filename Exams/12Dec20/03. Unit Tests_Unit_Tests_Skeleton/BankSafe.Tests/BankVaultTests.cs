using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Spasina","0015");
        }

        [Test]
        public void BankVaultDoesNotContainKeyAdd()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("V3", item));
        }

        [Test]
        public void BankVaultDoesNotAddAtTheSameKey()
        {
            vault.AddItem("A2", item);
            Assert.Throws<ArgumentException>(() => vault.AddItem("A2", new Item("sp","1236")));
        }

        [Test]
        public void BankVaultDoesNotAddAtTheSameItem()
        {
            vault.AddItem("A2", item);
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A1", item));
        }
        [Test]
        public void BankVaultSeccessAddItem()
        {
            var result= vault.AddItem("B2", item);
            Assert.AreEqual("Item:0015 saved successfully!", result);
        }
        [Test]
        public void BankVaultDoesNotContainKeyRemove()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("V3", item));
        }

        [Test]
        public void BankVaultDoesNotContainItemInThisKeyRemove()
        {
            vault.AddItem("A2", item);
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A2", new Item("k","3")));
        }
        [Test]
        public void BankVaultItemInThisKeyRemoveSuccess()
        {
            vault.AddItem("A2", item);
           var result = vault.RemoveItem("A2", item);
            Assert.AreEqual("Remove item:0015 successfully!", result);
        }
        [Test]
        public void BankVaultAddSuccess()
        {
            vault.AddItem("A2", item);
            
            Assert.That(vault.VaultCells["A2"],Is.EqualTo(item));
        }
        [Test]
        public void BankVaultRemoveSuccess()
        {
            vault.AddItem("A2", item);
            vault.RemoveItem("A2", item);
            Assert.That(vault.VaultCells["A2"], Is.EqualTo(null));
        }
    }
}