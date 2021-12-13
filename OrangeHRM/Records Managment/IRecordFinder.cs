using OpenQA.Selenium;

namespace OrangeHRM.Records_Managment
{
    public interface IRecordFinder
    {
        IWebDriver Driver { get; }
        IWebElement Find(string name);
    }
}