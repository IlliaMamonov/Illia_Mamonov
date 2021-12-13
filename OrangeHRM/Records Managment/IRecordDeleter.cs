using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeHRM.Records_Managment
{
    public interface IRecordDeleter
    {
        IWebDriver Driver { get; }
        void RemoveRecord(string name);
    }
}
