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
    public class JobTests
    {
        //getter jobtitle
        [Fact]
        public void TestGetJobJobTitle()
        {
            Job testjob1 = new Job();
            testjob1.JobTitle = "aJobTitle";
            Assert.Equal("aJobTitle", testjob1.JobTitle);
        }

        //setter of job title
        [Fact]
        public void TestSetJobJobTitle()
        {
            Job testjob2 = new Job();
            testjob2.JobTitle = "aJobTitle";
            testjob2.JobTitle = "NewJobTitle";
            Assert.Equal("NewJobTitle", testjob2.JobTitle);
        }

        //getter of company ID
        [Fact]
        public void TestGetJobCompanyID()
        {
            Job testjob3 = new Job();
            testjob3.CompanyID = 1;
            Assert.Equal(1, testjob3.CompanyID);
        }

        //setter of company id
        [Fact]
        public void TestSetJobCompanyID()
        {
            Job testjob4 = new Job();
            testjob4.CompanyID = 1;
            testjob4.CompanyID = 2;
            Assert.Equal(2, testjob4.CompanyID);
        }

        //getter of description
        [Fact]
        public void TestGetJobDescription()
        {
            Job testjob5 = new Job();
            testjob5.Description = "aDescription";
            Assert.Equal("aDescription", testjob5.Description);
        }

        //setter of description
        [Fact]
        public void TestSetJobDescription()
        {
            Job testjob6 = new Job();
            testjob6.Description = "aDescription";
            testjob6.Description = "NEWDescription";
            Assert.Equal("NEWDescription", testjob6.Description);
        }

        //getter of location
        [Fact]
        public void TestGetJobLocation()
        {
            Job testjob7 = new Job();
            testjob7.location = "aLocation";
            Assert.Equal("aLocation", testjob7.location);
        }

        //setter of location
        [Fact]
        public void TestSetJobLocation()
        {
            Job testjob8 = new Job();
            testjob8.location = "aLocation";
            testjob8.location = "NewLocation";
            Assert.Equal("NewLocation", testjob8.location);
        }

        //getter of wage range
        [Fact]
        public void TestGetJobWageRange()
        {
            Job testjob9 = new Job();
            testjob9.wageRange = "aRange";
            Assert.Equal("aRange", testjob9.wageRange);
        }

        //setter of wage range
        [Fact]
        public void TestSetJobWageRange()
        {
            Job testjob10 = new Job();
            testjob10.wageRange = "aRange";
            testjob10.wageRange = "NEWRange";
            Assert.Equal("NEWRange", testjob10.wageRange);
        }
    }
}
