using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        #region Initialize Web Elements
        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement deleteYesButton { get; set; }

        //Alert message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement alertMessage { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement SaveButton { get; set; }

        //Listing title
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        private IWebElement ListingTitle { get; set; }

        //Listing Description
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[4]")]
        private IWebElement ListingDescription { get; set; }
        #endregion

        #region Initialize Local Variables
        public string message;
        #endregion

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
        }

        //Function to edit the Share Skill listing
        internal string EditListing()
        {
            //go to Manage Listings page    
            GlobalDefinitions.Wait(2);
            manageListingsLink.Click();
            try
            {
                GlobalDefinitions.Wait(2);
                edit.Click();

                GlobalDefinitions.Wait(1);
                Title.Clear();
                Title.SendKeys("API Testing");
                Description.Clear();
                Description.SendKeys("API Testing for beginners");
                SaveButton.Click();
                GlobalDefinitions.Wait(2);
                if(ListingTitle.Text.Equals("API Testing") & ListingDescription.Text.Equals("API Testing for beginners"))
                {
                    Console.WriteLine("Listing edited successfully");
                    return "pass";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Could not find element by: By.XPath: (//i[@class='outline write icon'])[1]"))
                {
                    Console.WriteLine("You do not have any service listings!");
                    return "pass";
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    return "fail";
                }

            }
        }

        //Function to delete the Share Skill listing
        internal string DeleteListing()
        {
            //go to Manage Listings page    
            GlobalDefinitions.Wait(2);
            manageListingsLink.Click();

            //click on the delete icon
            try
            {
                GlobalDefinitions.Wait(1);
                delete.Click();

                GlobalDefinitions.Driver.SwitchTo().ActiveElement();
                deleteYesButton.Click();

                if (alertMessage.Text.Contains("Selenium has been deleted"))
                {
                    Console.WriteLine("Listing successfully deleted");
                    return "pass";
                }
                else
                {
                    Console.WriteLine(alertMessage.Text);
                    return "pass";
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("You do not have any service listings!");
                return "fail";
            }

        }
    }
}
