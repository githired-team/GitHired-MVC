using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using System.Linq;
using GitHired_MVC.Models;

namespace GitHiredTesting
{
    public class CardTests
    {
        //getter columnid
        [Fact]
        public void TestGetCardColID()
        {
            Card testCard1 = new Card();
            testCard1.ColumnID = 1;
            Assert.Equal(1, testCard1.ColumnID);
        }

        //setter column id
        [Fact]
        public void TestSetCardColID()
        {
            Card testCard2 = new Card();
            testCard2.ColumnID = 1;
            testCard2.ColumnID = 2;
            Assert.Equal(2, testCard2.ColumnID);
        }

        //getter resumecheck
        [Fact]
        public void TestGetCardResume()
        {
            Card testCard3 = new Card();
            testCard3.ResumeCheck = true;
            Assert.True(testCard3.ResumeCheck);
        }

        //setter resumecheck
        [Fact]
        public void TestSetCardResume()
        {
            Card testCard4 = new Card();
            testCard4.ResumeCheck = true;
            testCard4.ResumeCheck = false;
            Assert.False(testCard4.ResumeCheck);
        }

        //getter coverlettercheck
        [Fact]
        public void TestGetCardCoverLetter()
        {
            Card testCard5 = new Card();
            testCard5.CoverLetterCheck = true;
            Assert.True(testCard5.CoverLetterCheck);
        }

        //setter coverlettercheck
        [Fact]
        public void TestSetCardCoverLetter()
        {
            Card testCard6 = new Card();
            testCard6.CoverLetterCheck = true;
            testCard6.CoverLetterCheck = false;
            Assert.False(testCard6.CoverLetterCheck);
        }

        //getter job title
        [Fact]
        public void TestGetCardJobTitle()
        {
            Card testCard7 = new Card();
            testCard7.JobTitle = "aJob";
            Assert.Equal("aJob", testCard7.JobTitle);
        }

        //setter job title
        [Fact]
        public void TestSetCardJobTitle()
        {
            Card testCard8 = new Card();
            testCard8.JobTitle = "aJob";
            testCard8.JobTitle = "NewJob";
            Assert.Equal("NewJob", testCard8.JobTitle);
        }

        //getter company name
        [Fact]
        public void TestGetCardCompName()
        {
            Card testCard9 = new Card();
            testCard9.CompanyName = "aCompanyName";
            Assert.Equal("aCompanyName", testCard9.CompanyName);
        }

        //setter company name
        [Fact]
        public void TestSetCardCompName()
        {
            Card testCard10 = new Card();
            testCard10.JobTitle = "aCompanyName";
            testCard10.JobTitle = "NewCompanyName";
            Assert.Equal("NewCompanyName", testCard10.JobTitle);
        }

        //getter wage
        [Fact]
        public void TestGetCardWage()
        {
            Card testCard11 = new Card();
            testCard11.Wage = "10";
            Assert.Equal("10", testCard11.Wage);
        }

        //setter wage
        [Fact]
        public void TestSetCardWage()
        {
            Card testCard12 = new Card();
            testCard12.Wage = "10";
            testCard12.Wage = "100";
            Assert.Equal("100", testCard12.Wage);
        }

        //getter description
        [Fact]
        public void TestGetCardDescription()
        {
            Card testCard13 = new Card();
            testCard13.Description = "aDescription";
            Assert.Equal("aDescription", testCard13.Description);
        }

        //setter description
        [Fact]
        public void TestSetCardDescription()
        {
            Card testCard13 = new Card();
            testCard13.Description = "aDescription";
            testCard13.Description = "NewDescription";
            Assert.Equal("NewDescription", testCard13.Description);
        }

        //create card

        //read card

        //update card

        //delete card
    }
}
