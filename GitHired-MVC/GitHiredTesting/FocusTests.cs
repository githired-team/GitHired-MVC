using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;
using GitHired_MVC.Data;
using Microsoft.EntityFrameworkCore;
using GitHired_MVC.Models.Services;

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
        [Fact]
        public async void TestCreateFocus()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("CreateFocus").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Focus testFoc1 = new Focus();
                testFoc1.ID = 1;
                testFoc1.UserID = 1;
                testFoc1.Name = "aName";
                testFoc1.DesiredPosition = "aPositionOfInterest";
                testFoc1.Location = "Seattle";
                testFoc1.Skill = "aSkill";
                testFoc1.ResumeLink = "aResumeLink";
                testFoc1.CoverLetter = "aCoverLetterLink";

                FocusManagementService focService = new FocusManagementService(context);

                await focService.CreateFocus(testFoc1);

                var foc1Answer = context.Focus.FirstOrDefault(a => a.ID == testFoc1.ID);

                Assert.Equal(testFoc1, foc1Answer);
            }
        }

        //read focus
        [Fact]
        public async void TestReadFocus()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("ReadFocus").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Focus testFoc2 = new Focus();
                testFoc2.ID = 1;
                testFoc2.UserID = 1;
                testFoc2.Name = "aName";
                testFoc2.DesiredPosition = "aPositionOfInterest";
                testFoc2.Location = "Seattle";
                testFoc2.Skill = "aSkill";
                testFoc2.ResumeLink = "aResumeLink";
                testFoc2.CoverLetter = "aCoverLetterLink";

                FocusManagementService focService = new FocusManagementService(context);

                await focService.CreateFocus(testFoc2);

                var foc2Answer = await focService.GetFocus(1);
                var foc2AnswerA = foc2Answer.FirstOrDefault();

                Assert.Equal(testFoc2, foc2AnswerA);
            }
        }

        //update focus
        [Fact]
        public async void TestUpdateFocus()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("UpdateFocus").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Focus testFoc3 = new Focus();
                testFoc3.ID = 1;
                testFoc3.UserID = 1;
                testFoc3.Name = "aName";
                testFoc3.DesiredPosition = "aPositionOfInterest";
                testFoc3.Location = "Seattle";
                testFoc3.Skill = "aSkill";
                testFoc3.ResumeLink = "aResumeLink";
                testFoc3.CoverLetter = "aCoverLetterLink";
                testFoc3.CoverLetter = "NewCoverLetterLink";

                FocusManagementService focService = new FocusManagementService(context);

                await focService.CreateFocus(testFoc3);

                var foc3Answer = context.Focus.FirstOrDefault(a => a.ID == testFoc3.ID);

                Assert.Equal("NewCoverLetterLink", foc3Answer.CoverLetter);
            }
        }
        //delete focus
        [Fact]
        public async void TestDeleteFocus()
        {
            DbContextOptions<GitHiredDBContext> options = new DbContextOptionsBuilder<GitHiredDBContext>().UseInMemoryDatabase("DeleteFocus").Options;
            using (GitHiredDBContext context = new GitHiredDBContext(options))
            {
                Focus testFoc4 = new Focus();
                testFoc4.ID = 1;
                testFoc4.UserID = 1;
                testFoc4.Name = "aName";
                testFoc4.DesiredPosition = "aPositionOfInterest";
                testFoc4.Location = "Seattle";
                testFoc4.Skill = "aSkill";
                testFoc4.ResumeLink = "aResumeLink";
                testFoc4.CoverLetter = "aCoverLetterLink";

                FocusManagementService focService = new FocusManagementService(context);

                await focService.CreateFocus(testFoc4);
                await focService.DeleteFocus(1);
                var foc4Answer = context.Focus.FirstOrDefault(a => a.ID == testFoc4.ID);

                Assert.Null(foc4Answer);
            }
        }
    }
}
