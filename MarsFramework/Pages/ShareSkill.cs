using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
using MarsFramework.Config;
using OpenQA.Selenium.Support.UI;
using System;
using AutoItX3Lib;
using System.Diagnostics;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.Driver, this);

            //Populating the excel data 
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ShareSkill");
            GlobalDefinitions.Wait(1);
        }

        #region Initialize Web Elements
        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }
        [FindsBy(How = How.XPath,Using = "//tbody/tr[1]/td[3]")]
        private IWebElement ListingTitle { get; set; }
        
        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[4]")]
        private IWebElement ListingDescription { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "(//input[@name='serviceType'])[1]")]
        private IWebElement ServiceTypeOptionHourly { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@name='serviceType'])[2]")]
        private IWebElement ServiceTypeOptionOneOff { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "(//input[@name='locationType'])[1]")]
        private IWebElement LocationTypeOnSite { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@name='locationType'])[2]")]
        private IWebElement LocationTypeOnline { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Available days
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input")]
        private IWebElement Sunday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Monday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input")]
        private IWebElement Tuesday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[5]/div[1]/div/input")]
        private IWebElement Wednesday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input")]
        private IWebElement Thursday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input")]
        private IWebElement Friday { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[8]/div[1]/div/input")]
        private IWebElement Saturday { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")]
        private IWebElement SunStartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")]
        private IWebElement MonStartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input")]
        private IWebElement TueStartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[5]/div[2]/input")]
        private IWebElement WedStartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input")]
        private IWebElement ThuStartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[2]/input")]
        private IWebElement FriStartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[8]/div[2]/input")]
        private IWebElement SatStartTime { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input")]
        private IWebElement SunEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement MonEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[4]/div[3]/input")]
        private IWebElement TueEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[5]/div[3]/input")]
        private IWebElement WedEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input")]
        private IWebElement ThuEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input")]
        private IWebElement FriEndTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[3]/input")]
        private IWebElement SatEndTime { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillExchangeOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement CreditOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Upload work samples
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSampleButton { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement HiddenOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }
        #endregion

        #region Initialize Local Variables
        public static Random integer = new Random();
        public int randomInt = integer.Next(2, 4);
        public string serviceTypeOption, locationTypeOption, daysOption, skillTradeOption, active, startDateAndTime, endDateAndTime, message;

        #endregion

        #region Share Skill Page Functions
        //Function to click on the Share Skill Button
        public void ClickOnShareSkillBUtton()
        {
            GlobalDefinitions.Wait(4);
            ShareSkillButton.Click();
        }

        internal string EnterShareSkill()
        {
            //Passing values for the Skill through excel
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Title"));
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Description"));
            
            //Selecting category
            CategoryDropDown.Click();
            SelectElement selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Category"));

            //Selecting sub category
            SubCategoryDropDown.Click();
            SelectElement selectSubCategory = new SelectElement(SubCategoryDropDown);
            selectSubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(randomInt, "SubCategory"));

            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Tags"));
            Tags.SendKeys(",");

            //Selecting service option
            serviceTypeOption = GlobalDefinitions.ExcelLib.ReadData(randomInt, "ServiceType");
            if (serviceTypeOption.Equals("One-off service"))
            {
                ServiceTypeOptionOneOff.Click();
            }
            else if(serviceTypeOption.Equals("Hourly basis service"))
            {
                ServiceTypeOptionHourly.Click();
            }
            else
            {
                Console.WriteLine("Please enter a valid Service Type option");
            }

            //Selecting location type
            locationTypeOption = GlobalDefinitions.ExcelLib.ReadData(randomInt, "LocationType");
            if (locationTypeOption.Equals("On-site"))
            {
                LocationTypeOnSite.Click();
            }
            else if (locationTypeOption.Equals("Online"))
            {
                LocationTypeOnline.Click();
            }
            else
            {
                Console.WriteLine("Please enter a valid Location Type ");
            }

            //Selecting start and end dates 
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Startdate"));
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Enddate"));

            //Selecting days available
            daysOption = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Selectday");
            if (daysOption.Equals("Sun")){
                Sunday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime"); 
                SunStartTime.SendKeys(startDateAndTime);
                SunEndTime.SendKeys(endDateAndTime);
            }
            if (daysOption.Equals("Mon")){
                Monday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime");
                MonStartTime.SendKeys(startDateAndTime);
                MonEndTime.SendKeys(endDateAndTime);
            }
            else if (daysOption.Equals("Tue")){
                Tuesday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime");
                TueStartTime.SendKeys(startDateAndTime);
                TueEndTime.SendKeys(endDateAndTime);
            }
            else if (daysOption.Equals("Wed")){
                Wednesday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime");
                WedStartTime.SendKeys(startDateAndTime);
                WedEndTime.SendKeys(endDateAndTime);
            }
            else if (daysOption.Equals("Thu")){
                Thursday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime");
                ThuStartTime.SendKeys(startDateAndTime);
                ThuEndTime.SendKeys(endDateAndTime);
            }
            else if (daysOption.Equals("Fri")){
                Friday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime");
                FriStartTime.SendKeys(startDateAndTime);
                FriEndTime.SendKeys(endDateAndTime);
            }
            else if (daysOption.Equals("Sat")){
                Saturday.Click();
                startDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Starttime");
                endDateAndTime = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Endtime");
                SatStartTime.SendKeys(startDateAndTime);
                SatEndTime.SendKeys(endDateAndTime);
            }

            //Selecting Skill Trade option
            skillTradeOption = GlobalDefinitions.ExcelLib.ReadData(randomInt, "SkillTrade");
            if(skillTradeOption.Equals("Skill-Exchange"))
            {
                SkillExchangeOption.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Skill-Exchange"));
                SkillExchange.SendKeys(",");
            }
            else if(skillTradeOption.Equals("Credit"))
            {
                CreditOption.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Credit"));
            }

            //Uploading work samples
            WorkSampleButton.Click();
            GlobalDefinitions.Wait(2);
            //Calling the AutoIt exe file to upload work sample
            using (Process exeProcess = Process.Start("E:\\MVP Studio\\Competition Task\\marsframework-master\\MarsFramework\\FileUpload.exe")) 
            {
                exeProcess.WaitForExit();
            }

            //Selecting Active/Hidden option
            GlobalDefinitions.Wait(2);
            active = GlobalDefinitions.ExcelLib.ReadData(randomInt, "Active");
            if(active.Equals("Active"))
            {
                ActiveOption.Click();
            }    
            else if (active.Equals("Hidden"))
            {
                HiddenOption.Click();
            }

            //Saving the skill listing
            Save.Click();
            GlobalDefinitions.Wait(2);

            //Checking if the skill has been saved
            if (ListingTitle.Text.Equals(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Title")) & ListingDescription.Text.Equals(GlobalDefinitions.ExcelLib.ReadData(randomInt, "Description")))
            {
                Console.WriteLine("Service Listing Added successfully");
                return "pass";
            }
            else
            {
                Console.WriteLine("Service Listing was not saved");
                return "fail";
            }
        }
        #endregion
    }
}
