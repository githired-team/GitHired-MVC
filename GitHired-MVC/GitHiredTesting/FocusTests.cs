using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;

namespace GitHiredTesting
{
    public class FocusTests
    {
        //getter user id
        [Fact]
        public void TestGetFocusUserID()
        {
            Focus testFocus1 = new Focus();
            testFocus1.UserID = 1;
            Assert.Equal(1, testFocus1.UserID);
        }

        //setter user id
        [Fact]
        public void TestSetFocusUserID()
        {
            Focus testFocus2 = new Focus();
            testFocus2.UserID = 1;
            testFocus2.UserID = 2;
            Assert.Equal(2, testFocus2.UserID);
        }

        //getter name
        [Fact]
        public void TestGetFocusName()
        {
            Focus testFocus3 = new Focus();
            testFocus3.Name = "aName";
            Assert.Equal("aName", testFocus3.Name);
        }

        //setter name
        [Fact]
        public void TestSetFocusName()
        {
            Focus testFocus4 = new Focus();
            testFocus4.Name = "aName";
            testFocus4.Name = "NewName";
            Assert.Equal("NewName", testFocus4.Name);
        }

        //getter desired position
        [Fact]
        public void TestGetFocusDesiredP()
        {
            Focus testFocus5 = new Focus();
            testFocus5.DesiredPosition = "aPosition";
            Assert.Equal("aPosition", testFocus5.DesiredPosition);
        }

        //setter desired position
        [Fact]
        public void TestSetFocusDesiredP()
        {
            Focus testFocus6 = new Focus();
            testFocus6.DesiredPosition = "aPosition";
            testFocus6.DesiredPosition = "NewPosition";
            Assert.Equal("NewPosition", testFocus6.DesiredPosition);
        }

        //getter location
        [Fact]
        public void TestGetFocusLocation()
        {
            Focus testFocus7 = new Focus();
            testFocus7.Location = "aLocation";
            Assert.Equal("aLocation", testFocus7.Location);
        }

        //setter location
        [Fact]
        public void TestSetFocusLocation()
        {
            Focus testFocus8 = new Focus();
            testFocus8.Location = "aLocation";
            testFocus8.Location = "NewLocation";
            Assert.Equal("NewLocation", testFocus8.Location);
        }

        //getter skill
        [Fact]
        public void TestGetFocusSkill()
        {
            Focus testFocus9 = new Focus();
            testFocus9.Skill = "aSkill";
            Assert.Equal("aSkill", testFocus9.Skill);
        }

        //setter skill
        [Fact]
        public void TestSetFocusSkill()
        {
            Focus testFocus10 = new Focus();
            testFocus10.Skill = "aSkill";
            testFocus10.Skill = "NewSkill";
            Assert.Equal("NewSkill", testFocus10.Skill);
        }

        //getter resume link
        [Fact]
        public void TestGetFocusResume()
        {
            Focus testFocus11 = new Focus();
            testFocus11.ResumeLink = "aResume";
            Assert.Equal("aResume", testFocus11.ResumeLink);
        }

        //setter resume link
        [Fact]
        public void TestSetFocusResume()
        {
            Focus testFocus12 = new Focus();
            testFocus12.ResumeLink = "aResume";
            testFocus12.ResumeLink = "NewResume";
            Assert.Equal("NewResume", testFocus12.ResumeLink);
        }

        //getter coverletter
        [Fact]
        public void TestGetFocusCoverL()
        {
            Focus testFocus13 = new Focus();
            testFocus13.CoverLetter = "aCoverL";
            Assert.Equal("aCoverL", testFocus13.CoverLetter);
        }

        //setter coverletter
        [Fact]
        public void TestSetFocusCoverL()
        {
            Focus testFocus14 = new Focus();
            testFocus14.CoverLetter = "aCoverL";
            testFocus14.CoverLetter = "NewCoverL";
            Assert.Equal("NewCoverL", testFocus14.CoverLetter);
        }

        //create focus

        //read focus

        //update focus

        //delete focus

    }
}
