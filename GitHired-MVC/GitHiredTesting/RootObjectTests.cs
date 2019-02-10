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
    public class RootObjectTests
    {
        //getting jobs
        [Fact]
        public void TestGetRootObjectJobs()
        {
            RootObject testRootObj1 = new RootObject();
            List<JobPosting> testRootObj1List = new List<JobPosting>();
            JobPosting temp1 = new JobPosting();
            temp1.CompanyName = "JustANameForThisTest";
            testRootObj1List.AddRange(new[] { temp1 });
            testRootObj1.jobs = testRootObj1List;
            Assert.Equal("JustANameForThisTest", testRootObj1.jobs[0].CompanyName);
        }

        //setter jobs
        [Fact]
        public void TestSetRootObjectJobs()
        {
            RootObject testRootObj2 = new RootObject();
            List<JobPosting> testRootObj1List = new List<JobPosting>();
            JobPosting temp2 = new JobPosting();
            temp2.CompanyName = "JustANameForThisTest";
            JobPosting temp3 = new JobPosting();
            temp3.CompanyName = "aDifferentName";
            testRootObj1List.AddRange(new[] { temp2});
            testRootObj2.jobs = testRootObj1List;
            testRootObj1List[0] = temp3;
            Assert.Equal("aDifferentName", testRootObj2.jobs[0].CompanyName);
        }

        //getter query
        [Fact]
        public void TestGetRootObjectQuery()
        {
            RootObject testRootObj3 = new RootObject();
            testRootObj3.query = "aQuery";
            Assert.Equal("aQuery", testRootObj3.query);
        }

        //setter query
        [Fact]
        public void TestSetRootObjectQuery()
        {
            RootObject testRootObj4 = new RootObject();
            testRootObj4.query = "aQuery";
            testRootObj4.query = "NEWQuery";
            Assert.Equal("NEWQuery", testRootObj4.query);
        }
    }
}
