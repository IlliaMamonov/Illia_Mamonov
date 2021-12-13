using OpenQA.Selenium;

namespace OrangeHRM.Records_Managment
{
    public interface IRecordAdder
    {
        IWebDriver Driver { get; }

        void AddNewRecord(string name);
    }
}