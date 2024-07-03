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
        [UnityTest]
        public IEnumerator CreateNewThreadTest()
        {
            GameObject newAssistant = new GameObject();
            newAssistant.AddComponent<OpenAIAssistant>();
            OpenAIAssistant openAIAssistant = new OpenAIAssistant();
            yield return null;
        }
    }
}
