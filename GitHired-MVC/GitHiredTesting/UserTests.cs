using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;
using Microsoft.EntityFrameworkCore;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Services;

namespace GitHiredTesting
{
    public class UserTests
    {

        //getter name
        [Fact]
        public void TestGetUserName()
        {
            User testUser1 = new User();
            testUser1.Name = "aName";
            Assert.Equal("aName", testUser1.Name);
        }

        //setter name
        [Fact]
        public void TestSetUserName()
        {
            User testUser2 = new User();
            testUser2.Name = "aName";
            testUser2.Name = "NewName";
            Assert.Equal("NewName", testUser2.Name);
        }

        //getter email
        [Fact]
        public void TestGetUserEmail()
        {
            User testUser3 = new User();
            testUser3.Email = "aEmail";
            Assert.Equal("aEmail", testUser3.Email);
        }

        //setter email
        [Fact]
        public void TestSetUserEmail()
        {
            User testUser4 = new User();
            testUser4.Email = "aEmail";
            testUser4.Email = "NewEmail";
            Assert.Equal("NewEmail", testUser4.Email);
        }

        //getter github
        [Fact]
        public void TestGetUserGitHub()
        {
            User testUser5 = new User();
            testUser5.GitHubLink = "aGLink";
            Assert.Equal("aGLink", testUser5.GitHubLink);
        }

        //setter github
        [Fact]
        public void TestSetUserGitHub()
        {
            User testUser6 = new User();
            testUser6.GitHubLink = "aGLink";
            testUser6.GitHubLink = "NewGLink";
            Assert.Equal("NewGLink", testUser6.GitHubLink);
        }

        //create user
        [Fact]
        public async void TestCreateUser()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("CreateUser").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                User testUser1 = new User();
                testUser1.ID = 1;
                testUser1.Name = "aName";
                testUser1.Email = "anEmail";
                testUser1.GitHubLink = "aGitHubLink";
                testUser1.Avatar = "anAvatar";

                UserManagementService userService = new UserManagementService(context);

                await userService.CreateUser(testUser1);

                var user1Answer = context.User.FirstOrDefault(a => a.ID == testUser1.ID);

                Assert.Equal(testUser1, user1Answer);
            }
        }

        //read user
        [Fact]
        public async void TestReadUser()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("ReadUser").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                User testUser2 = new User();
                testUser2.ID = 1;
                testUser2.Name = "aName";
                testUser2.Email = "anEmail";
                testUser2.GitHubLink = "aGitHubLink";
                testUser2.Avatar = "anAvatar";

                UserManagementService userService = new UserManagementService(context);

                await userService.CreateUser(testUser2);

                var user2Answer = await userService.GetUserById(testUser2.ID);

                Assert.Equal(testUser2, user2Answer);
            }
        }

        //update user
        [Fact]
        public async void TestUpdateUser()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("UpdateUser").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                User testUser3 = new User();
                testUser3.ID = 1;
                testUser3.Name = "aName";
                testUser3.Email = "anEmail";
                testUser3.GitHubLink = "aGitHubLink";
                testUser3.Avatar = "anAvatar";
                testUser3.Avatar = "newAvatar";

                UserManagementService userService = new UserManagementService(context);

                await userService.CreateUser(testUser3);

                var user3Answer = await userService.GetUserById(testUser3.ID);

                Assert.Equal("newAvatar", user3Answer.Avatar);
            }
        }

        //delete user 
        [Fact]
        public async void TestDeleteUser()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("DeleteUser").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                User testUser3 = new User();
                testUser3.ID = 1;
                testUser3.Name = "aName";
                testUser3.Email = "anEmail";
                testUser3.GitHubLink = "aGitHubLink";
                testUser3.Avatar = "anAvatar";
                testUser3.Avatar = "newAvatar";

                UserManagementService userService = new UserManagementService(context);

                await userService.CreateUser(testUser3);
                await userService.DeleteUser(1);

                var user4Answer = await userService.GetUserById(testUser3.ID);

                Assert.Null(user4Answer);
            }
        }
    }
}
