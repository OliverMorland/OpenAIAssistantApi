using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAIAssistantsApi;
using UnityEngine;
using UnityEngine.TestTools;

namespace OpenAIAssistantsApi
{
    public class UtilsTests
    {
        [Test]
        public void GetMethodTypeTest()
        {
            string getAsString = Utils.GetMethodTypeAsString(WebRequestData.MethodType.GET);
            Assert.AreEqual("GET", getAsString);
        }

        [Test]
        public void PostMethodTypeTest()
        {
            string postAsString = Utils.GetMethodTypeAsString(WebRequestData.MethodType.POST);
            Assert.AreEqual("POST", postAsString);
        }
    }
}
