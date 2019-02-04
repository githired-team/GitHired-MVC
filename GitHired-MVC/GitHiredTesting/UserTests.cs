using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;

namespace GitHiredTesting
{
    public class UserTests
    {

        //getter name
        [Fact]
        public void TestGetUserName()
        {
            User testUser1 = new User();
            testUser1.Name = "";
        }

        //setter name
        [Fact]
        public void TestSetUserName()
        {
        }

        //getter email

        //setter email

        //getter github

        //setter github

        //create user

        //read user

        //update user

        //delete user 
    }
}
