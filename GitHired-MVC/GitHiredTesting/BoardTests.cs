using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Services;

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

        //create board
        [Fact]
        public async void TestCreateBoard()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("CreateBoard").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Board testBoard1 = new Board();
                testBoard1.ID = 1;
                testBoard1.FocusID = 1;
                testBoard1.Name = "testBoardName";

                BoardManagementService boardService = new BoardManagementService(context);

                await boardService.CreateBoard(testBoard1);

                var board1Answer = context.Board.FirstOrDefault(a => a.ID == testBoard1.ID);

                Assert.Equal(testBoard1, board1Answer);
            }
        }

        //read baord
        [Fact]
        public async void TestReadBoard()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("ReadBoard").Options;

            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Board testBoard2 = new Board();
                testBoard2.ID = 1;
                testBoard2.FocusID = 1;
                testBoard2.Name = "testBoardName";

                BoardManagementService boardService = new BoardManagementService(context);

                await boardService.CreateBoard(testBoard2);
                var board2Answer = await boardService.GetBoardAsync(testBoard2.ID);

                Assert.Equal(testBoard2, board2Answer);
            }
        }

        //update board
        [Fact]
        public async void TestUpdateBoard()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("UpdateBoard").Options;

            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Board testBoard3 = new Board();
                testBoard3.ID = 1;
                testBoard3.FocusID = 1;
                testBoard3.Name = "testBoardName";
                testBoard3.Name = "New Test Board Name";

                BoardManagementService boardService = new BoardManagementService(context);

                await boardService.CreateBoard(testBoard3);
                var board3Answer = await boardService.GetBoardAsync(testBoard3.ID);

                Assert.Equal("New Test Board Name", board3Answer.Name);
            }
        }

        //delete board
        [Fact]
        public async void TestDeleteBoard()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("DeleteBoard").Options;

            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Board testBoard4 = new Board();
                testBoard4.ID = 1;
                testBoard4.FocusID = 1;
                testBoard4.Name = "testBoardName";

                BoardManagementService boardService = new BoardManagementService(context);

                await boardService.CreateBoard(testBoard4);
                await boardService.DeleteBoard(1);
                var board4Answer = await boardService.GetBoardAsync(testBoard4.ID);

                Assert.Null(board4Answer);
            }
        }
    }
}
