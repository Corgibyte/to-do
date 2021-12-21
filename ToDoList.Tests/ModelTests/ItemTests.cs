using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTests()
    {
      DBConfiguration.ConnectionString = "server=localhost; user id=root;password=epicodus;port=3306;database=to_do_list_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionAreTheSame_Item()
    {
      Item firstItem = new Item("Mow the lawn");
      Item secondItem = new Item("Mow the lawn");
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      Item testItem = new Item("Mow the lawn");
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item> { testItem };
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void ItemConstructor_CreatesInstanceOfItem_Item()
    // {
    //   Item newItem = new("test");
    //   Assert.AreEqual(typeof(Item), newItem.GetType());
    // }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   string description = "Walk the dog.";
    //   Item newItem = new(description);
    //   Assert.AreEqual(description, newItem.Description);
    // }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   string description = "Walk the dog.";
    //   Item newItem = new(description);
    //   string updatedDescription = "Do the dishes";
    //   newItem.Description = updatedDescription;
    //   string result = newItem.Description;
    //   Assert.AreEqual(updatedDescription, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      List<Item> newList = new List<Item> { };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new(description01);
      Item newItem2 = new(description02);
      newItem1.Save();
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //   int result = newItem.Id;
    //   Assert.AreEqual(0, result);
    // }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      newItem1.Save();
      newItem2.Save();

      Item result = Item.Find(newItem1.Id);

      Assert.AreEqual(newItem1, result);
    }
  }
}