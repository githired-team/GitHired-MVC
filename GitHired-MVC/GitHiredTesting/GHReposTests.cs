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
    public class GHReposTests
    {
        //getter focusID
        [Fact]
        public void TestGetFocusGHRepoFocusID()
        {
            GHRepos testGHRepo1 = new GHRepos();
            testGHRepo1.FocusID = 1;
            Assert.Equal(1, testGHRepo1.FocusID);
        }

        //setter focusID
        [Fact]
        public void TestSetFocusGHRepoFocusID()
        {
            GHRepos testGHRepo2 = new GHRepos();
            testGHRepo2.FocusID = 1;
            testGHRepo2.FocusID = 2;
            Assert.Equal(2, testGHRepo2.FocusID);
        }

        //getter ghrepo
        [Fact]
        public void TestGetFocusGHRepoGHrepo()
        {
            GHRepos testGHRepo3 = new GHRepos();
            testGHRepo3.GHRepo = "aGHLink";
            Assert.Equal("aGHLink", testGHRepo3.GHRepo);
        }

        //setter ghrepo
        [Fact]
        public void TestSetFocusGHRepoGHrepo()
        {
            GHRepos testGHRepo4 = new GHRepos();
            testGHRepo4.GHRepo = "aGHLink";
            testGHRepo4.GHRepo = "NewGHLink";
            Assert.Equal("NewGHLink", testGHRepo4.GHRepo);
        }
    }
}
