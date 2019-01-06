﻿using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Net;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace AppiumBasicSetup
{
	[TestFixture()]
	public class ConciseApi
	{
		public AndroidDriver<AppiumWebElement> driver;

		[SetUp()]
		public void SetUp()
		{
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "emulator");
            cap.SetCapability("platformVersion", "8.1.0");
            cap.SetCapability("app", "D:\\projects\\craft-dish\\Craft_dish.Craft_dish-Signed.apk");
            cap.SetCapability("fullReset", "True");
        //    cap.SetCapability("appWaitActivity ", 70000);
          //  cap.SetCapability("clearSystemFiles", true);
          //  cap.SetCapability("autoGrantPermissions", true);
            driver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), cap);
		}

        public void waitAppLoading()
        {
            Thread.Sleep(10000);
        }

        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                if (element.Displayed == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [TearDown()]
		public void TearDown()
		{
			driver.Quit();
			Console.Write("Tearing down the test");
		}
	}
}
