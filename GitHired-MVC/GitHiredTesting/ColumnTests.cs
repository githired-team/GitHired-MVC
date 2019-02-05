using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;

namespace GitHiredTesting
{
    public class ColumnTests
    {
        //getter board id
        [Fact]
        public void TestGetColumnBoardID()
        {
            Column testCol1 = new Column();
            testCol1.BoardID = 1;
            Assert.Equal(1, testCol1.BoardID);
        }

        //setter board id
        [Fact]
        public void TestSetColumnBoardID()
        {
            Column testCol2 = new Column();
            testCol2.BoardID = 1;
            testCol2.BoardID = 2;
            Assert.Equal(2, testCol2.BoardID);
        }

        //getter name
        [Fact]
        public void TestGetColumnName()
        {
            Column testCol3 = new Column();
            testCol3.Name = "Name";
            Assert.Equal("Name", testCol3.Name);
        }

        //setter name
        [Fact]
        public void TestSetColumnName()
        {
            Column testCol4 = new Column();
            testCol4.Name = "Name";
            testCol4.Name = "NewName";
            Assert.Equal("NewName", testCol4.Name);
        }

        //getter order
        [Fact]
        public void TestGetColumnOrder()
        {
            Column testCol5 = new Column();
            testCol5.Order = 1;
            Assert.Equal(1, testCol5.Order);
        }

        //setter order
        [Fact]
        public void TestSetColumnOrder()
        {
            Column testCol6 = new Column();
            testCol6.Order = 1;
            testCol6.Order = 2;
            Assert.Equal(2, testCol6.Order);
        }

        //create column

        //read column

        //update column

        //delete column
    }
}
