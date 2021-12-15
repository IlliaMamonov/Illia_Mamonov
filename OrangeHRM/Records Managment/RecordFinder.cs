﻿using OpenQA.Selenium;

namespace OrangeHRM.Records_Managment
{
    public sealed class RecordFinder : IRecordFinder
    {
        private IWebDriver _driver;

        public RecordFinder(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public IWebElement Find(string gradeName)
        {
            IWebElement element;
            try
            {
                element = _driver.FindElement(By.XPath($"//*[contains(text(), '{gradeName}')]"));
            }
            catch (NoSuchElementException)
            {
                element = null;
            }

            return element;
        }
    }
}