using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAIAssistantsApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class OpenAIAssistantTests
    {
        const float MAX_RESPONSE_WAIT_TIME = 4f;
        bool responseRecieved = false;
        OpenAIAssistant openAIAssistant;
        const string openAIConfigurationPath = "Assets/OpenAIConfigurations/OpenAIConfiguration.asset";

        [SetUp]
        public void Setup()
        {
            GameObject newAssistant = new GameObject();
            openAIAssistant = newAssistant.AddComponent<OpenAIAssistant>();
            OpenAIConfigurationSO configuration = AssetDatabase.LoadAssetAtPath<OpenAIConfigurationSO>(openAIConfigurationPath);
            if (configuration == null)
            {
                Assert.Fail("Found no Open AI configurations, create one and add it to resources");
            }
            openAIAssistant.openAIConfig = configuration;
            openAIAssistant.OnResponseRecieved.AddListener(OnOpenAIAssistantResponse);
        }

        void OnOpenAIAssistantResponse(string response)
        {
            responseRecieved = true;
        }

        [UnityTest]
        public IEnumerator DoesAssistantRespondInTime()
        {
            openAIAssistant.AskAssistant("Hello");
            yield return new WaitForSeconds(MAX_RESPONSE_WAIT_TIME);
            Assert.IsTrue(responseRecieved);
        }
    }
}
