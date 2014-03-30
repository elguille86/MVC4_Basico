using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using GuestBook.Controllers;
using GuestBook.Models;
using GuestBook.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuestBook.Tests.Controllers
{
    [TestClass]
    public class GuestBookControllerTest
    {
        [TestMethod]
        public void Index_RenderView()
        {
            //Arrange
            var controller = new GuestBookController(new FakeGuestbookRepository());

            //Act
            var result = controller.index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_get_most_recent_entries()
        {
            //Arrange
            var controller = new GuestBookController(new FakeGuestbookRepository());

            //Act
            var result = controller.index() as ViewResult;
            var entries = (IList<GuestBookEntry>)result.Model;
            //Assert
            Assert.AreEqual(1, entries.Count);
        }
    }
}
