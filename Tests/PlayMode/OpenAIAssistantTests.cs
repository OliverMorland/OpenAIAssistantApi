using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAIAssistantsApi;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class OpenAIAssistantTests
    {
        [SetUp]
        public void Setup()
        {
            OpenAIAssistant openAIAssistant = new OpenAIAssistant();
            openAIAssistant.OnResponseRecieved.AddListener(OnOpenAIAssistantResponse);
        }

        void OnOpenAIAssistantResponse(string response)
        {

        }

        [UnityTest]
        public IEnumerator CreateNewThreadTest()
        {
            GameObject newAssistant = new GameObject();
            newAssistant.AddComponent<OpenAIAssistant>();
            OpenAIAssistant openAIAssistant = new OpenAIAssistant();
            openAIAssistant.AskAssistant("Hello");
            yield return new WaitForSeconds(5f);

        }

        void OnAssistantResponse()
        {

        }
    }
}
