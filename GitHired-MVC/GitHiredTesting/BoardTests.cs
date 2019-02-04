using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;

namespace GitHiredTesting
{
    public class BoardTests
    {
        //getter FocusID
        [Fact]
        public void TestGetBoardFocusID()
        {
            Board testBoard1 = new Board();
            testBoard1.FocusID = 1;
            Assert.Equal(1, testBoard1.FocusID);
        }

        //setter FocusID
        [Fact]
        public void TestSetBoardFocusID()
        {
            Board testBoard2 = new Board();
            testBoard2.FocusID = 1;
            testBoard2.FocusID = 2;
            Assert.Equal(2, testBoard2.FocusID);
        }

        //getter Name
        [Fact]
        public void TestGetBoardName()
        {
            Board testBoard3 = new Board();
            testBoard3.Name = "aName";
            Assert.Equal("aName", testBoard3.Name);
        }

        //setter Name
        [Fact]
        public void TestSetBoardName()
        {
            Board testBoard4 = new Board();
            testBoard4.Name = "aName";
            testBoard4.Name = "newName";

            Assert.Equal("newName", testBoard4.Name);
        }

        //setter

        //create board

        //read baord

        //update board

        //delete board
    }
}
