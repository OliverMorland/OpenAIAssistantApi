using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OpenAIAssistantsApi
{
    public class ChatGPTAssistant : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;

        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;

        private float height;
        public OpenAIAssistant openAiAssistant;

        private List<string> messages = new List<string>();

        private void Start()
        {
            button.onClick.AddListener(OnButtonClicked);
            openAiAssistant.OnResponseRecieved.AddListener(OnResponseRecieved);
        }

        private void AppendMessage(string message, bool isUser)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
            RectTransform item;
            if (isUser)
            {
                item = Instantiate(sent, scroll.content);
            }
            else
            {
                item = Instantiate(received, scroll.content);
            }
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = message;
            item.anchoredPosition = new Vector2(0, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        void OnButtonClicked()
        {
            SendReply();
        }

        void SendReply()
        {
            AppendMessage(inputField.text, true);
            messages.Add(inputField.text);
            openAiAssistant.AskAssistant(inputField.text);

            button.enabled = false;
            inputField.text = "";
            inputField.enabled = false;
        }

        private void OnResponseRecieved(string response)
        {
            messages.Add(response);
            AppendMessage(response, false);

            button.enabled = true;
            inputField.enabled = true;
        }
    }
}
