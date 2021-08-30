using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.IO;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            public object GlobalDefinition { get; private set; }

            [Test]
            public void AddSkillListing()
            {
                //Start Report
                test = extent.StartTest("AddSkillListing");

                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.ClickOnShareSkillBUtton();
                string status = shareSkillObj.EnterShareSkill();

                //Log 'info'
                test.Log(LogStatus.Info, "Add Skill Listing");

                if (status.Equals("pass"))
                {
                    //Pass scenario
                    test.Log(LogStatus.Pass, "Test Passed");
                }
                else if (status.Equals("fail"))
                {
                    //Fail scenario
                    test.Log(LogStatus.Fail, "Test Failed");
                }
            }
            
            [Test]
            public void DeleteSkillListing()
            {
                //Start Report
                test = extent.StartTest("DeleteSkillListing");

                ManageListings manageListingObj = new ManageListings();
                string status = manageListingObj.DeleteListing();

                //Log 'info'
                test.Log(LogStatus.Info, "Delete Skill Listing");
                if (status.Equals("pass"))
                {
                    //Pass scenario
                    test.Log(LogStatus.Pass, "Test Passed");
                }
                else if (status.Equals("fail"))
                {
                    //Fail scenario
                    test.Log(LogStatus.Fail, "Test Failed");
                }
            }

            [Test]
            public void EditSkillListing()
            {
                //Start Report
                test = extent.StartTest("EditSkillListing");

                ManageListings manageListingObj = new ManageListings();
                string status = manageListingObj.EditListing();

                //Log 'info'
                test.Log(LogStatus.Info, "Edit Skill Listing");

                if (status.Equals("pass"))
                {
                    //Pass scenario
                    test.Log(LogStatus.Pass, "Test Passed");
                }
                else if (status.Equals("fail"))
                {
                    //Fail scenario
                    test.Log(LogStatus.Fail, "Test Failed");
                }
            }
        }
    }
}