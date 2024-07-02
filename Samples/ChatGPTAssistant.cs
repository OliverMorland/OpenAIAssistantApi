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

        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "Act as a random stranger in a chat room and reply to the questions. Don't break character. Don't ever mention that you are an AI model.";

        private void Start()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void AppendMessage(ChatMessage message)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

            var item = Instantiate(message.role == "user" ? sent : received, scroll.content);
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = message.content;
            item.anchoredPosition = new Vector2(0, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        void OnButtonClicked()
        {
            StartCoroutine(SendReplyAsync());
        }

        IEnumerator SendReplyAsync()
        {
            yield return null;
        }

        //private async void SendReply()
        //{
        //    var newMessage = new ChatMessage()
        //    {
        //        role = "user",
        //        content = inputField.text
        //    };

        //    AppendMessage(newMessage);

        //    if (messages.Count == 0) newMessage.content = prompt + "\n" + inputField.text;

        //    messages.Add(newMessage);

        //    button.enabled = false;
        //    inputField.text = "";
        //    inputField.enabled = false;

        //    // Complete the instruction
        //    var completionResponse = await openAiAssistant.CreateChatCompletion(new CreateChatCompletionRequest()
        //    {
        //        Model = "gpt-3.5-turbo-0613",
        //        Messages = messages
        //    });

        //    if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
        //    {
        //        var message = completionResponse.Choices[0].Message;
        //        message.Content = message.Content.Trim();

        //        messages.Add(message);
        //        AppendMessage(message);
        //    }
        //    else
        //    {
        //        Debug.LogWarning("No text was generated from this prompt.");
        //    }

        //    button.enabled = true;
        //    inputField.enabled = true;
        //}
    }
}
