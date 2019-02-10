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
    public class JobPostingTests
    {
        //getter companyID
        [Fact]
        public void TestGetJobPostingCompanyID()
        {
            Job testJP1 = new Job();
            testJP1.CompanyID = 1;
            Assert.Equal(1, testJP1.CompanyID);
        }

        //setter companyID
        [Fact]
        public void TestSetJobPostingCompanyID()
        {
            JobPosting testJP2 = new JobPosting();
            testJP2.CompanyID = 1;
            testJP2.CompanyID = 2;
            Assert.Equal(2, testJP2.CompanyID);
        }

        //getter Company name
        [Fact]
        public void TestGetJobPostingCompanyName()
        {
            JobPosting testJP3 = new JobPosting();
            testJP3.CompanyName = "aCompanyName";
            Assert.Equal("aCompanyName", testJP3.CompanyName);
        }

        //setter company name
        [Fact]
        public void TestSetJobPostingCompanyName()
        {
            JobPosting testJP4 = new JobPosting();
            testJP4.CompanyName = "aCompanyName";
            testJP4.CompanyName = "NewCompanyName";
            Assert.Equal("NewCompanyName", testJP4.CompanyName);
        }

        //getter jobtitle
        [Fact]
        public void TestGetJobPostingJobTitle()
        {
            JobPosting testJP5 = new JobPosting();
            testJP5.JobTitle = "aName";
            Assert.Equal("aName", testJP5.JobTitle);
        }

        //setter job title
        [Fact]
        public void TestSetJobPostingJobTitle()
        {
            JobPosting testJP6 = new JobPosting();
            testJP6.JobTitle = "aName";
            testJP6.JobTitle = "NewName";
            Assert.Equal("NewName", testJP6.JobTitle);
        }

        //getter description
        [Fact]
        public void TestGetJobPostingDescription()
        {
            JobPosting testJP7 = new JobPosting();
            testJP7.Description = "aDescription";
            Assert.Equal("aDescription", testJP7.Description);
        }

        //setter description
        [Fact]
        public void TestSetJobPostingDescription()
        {
            JobPosting testJP8 = new JobPosting();
            testJP8.Description = "aDescription";
            testJP8.Description = "NEWDescription";
            Assert.Equal("NEWDescription", testJP8.Description);
        }

        //getter location
        [Fact]
        public void TestGetJobPostingLocation()
        {
            JobPosting testJP9 = new JobPosting();
            testJP9.Location = "aLocation";
            Assert.Equal("aLocation", testJP9.Location);
        }

        //setter location
        [Fact]
        public void TestSetJobPostingLocation()
        {
            JobPosting testJP10 = new JobPosting();
            testJP10.Location = "aLocation";
            testJP10.Location = "NewLocation";
            Assert.Equal("NewLocation", testJP10.Location);
        }

        //getter wage range
        [Fact]
        public void TestGetJobPostingWageRange()
        {
            JobPosting testJP11 = new JobPosting();
            testJP11.WageRange = "aRange";
            Assert.Equal("aRange", testJP11.WageRange);
        }

        //setter wage range
        [Fact]
        public void TestSetJobPostingWageRange()
        {
            JobPosting testJP12 = new JobPosting();
            testJP12.WageRange = "aRange";
            testJP12.WageRange = "NEWRange";
            Assert.Equal("NEWRange", testJP12.WageRange);
        }

        //getter application URL
        [Fact]
        public void TestGetJobPostingApplicationURL()
        {
            JobPosting testJP13 = new JobPosting();
            testJP13.ApplicationUrl = "aURL";
            Assert.Equal("aURL", testJP13.ApplicationUrl);
        }

        //setter applicaiton URL
        [Fact]
        public void TestSetJobPostingApplicationURL()
        {
            JobPosting testJP14 = new JobPosting();
            testJP14.ApplicationUrl = "aURL";
            testJP14.ApplicationUrl = "NewURL";
            Assert.Equal("NewURL", testJP14.ApplicationUrl);
        }

        //getter skill set
        [Fact]
        public void TestGetJobPostingSkill()
        {
            JobPosting testJP15 = new JobPosting();
            List<string> testJP15List = new List<string>();
            testJP15List.AddRange(new[] {"a","b","c"});
            testJP15.Skillset = testJP15List;
            Assert.Equal("a", testJP15.Skillset[0]);
        }

        //setter skill set
        [Fact]
        public void TestSetJobPostingSkill()
        {
            JobPosting testJP16 = new JobPosting();
            List<string> testJP16List = new List<string>();
            testJP16List.AddRange(new[] { "a", "b", "c" });
            testJP16.Skillset = testJP16List;
            testJP16.Skillset[0] = "newA";
            Assert.Equal("newA", testJP16.Skillset[0]);
        }
    }
}
