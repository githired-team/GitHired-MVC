using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Services;
using Microsoft.EntityFrameworkCore;

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
        [Fact]
        public async void TestCreateColumn()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("CreateColumn").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Column testCol1 = new Column();
                testCol1.ID = 1;
                testCol1.BoardID = 1;
                testCol1.Name = "aName";
                testCol1.Order = 1;

                ColumnManagementService colService = new ColumnManagementService(context);

                await colService.CreateColumn(testCol1);

                var col1Answer = context.Column.FirstOrDefault(a => a.ID == testCol1.ID);

                Assert.Equal(testCol1, col1Answer);
            }
        }

        //read column
        [Fact]
        public async void TestReadColumn()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("ReadColumn").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Column testCol2 = new Column();
                testCol2.ID = 1;
                testCol2.BoardID = 1;
                testCol2.Name = "aName";
                testCol2.Order = 1;

                ColumnManagementService colService = new ColumnManagementService(context);

                await colService.CreateColumn(testCol2);

                var col2Answer = await colService.GetColumn(1);

                Assert.Equal(testCol2, col2Answer);
            }
        }

        //update column
        [Fact]
        public async void TestUpdateColumn()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("UpdateColumn").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Column testCol3 = new Column();
                testCol3.ID = 1;
                testCol3.BoardID = 1;
                testCol3.Name = "aName";
                testCol3.Order = 1;
                testCol3.Order = 100;

                ColumnManagementService colService = new ColumnManagementService(context);

                await colService.CreateColumn(testCol3);

                var col3Answer = await colService.GetColumn(1);

                Assert.Equal(100, col3Answer.Order);
            }
        }

        //delete column
        [Fact]
        public async void TestDeleteColumn()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("DeleteColumn").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Column testCol4 = new Column();
                testCol4.ID = 1;
                testCol4.BoardID = 1;
                testCol4.Name = "aName";
                testCol4.Order = 1;

                ColumnManagementService colService = new ColumnManagementService(context);

                await colService.CreateColumn(testCol4);
                await colService.DeleteColumn(1);
                var col4Answer = await colService.GetColumn(1);

                Assert.Null(col4Answer);
            }
        }
    }
}
