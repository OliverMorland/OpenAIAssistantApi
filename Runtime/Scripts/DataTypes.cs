using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace OpenAIAssistantsApi
{
    public struct ChatMessage
    {
        public string role;
        public string content;
    }

    public struct WebRequestData
    {
        public string path;
        public enum MethodType { POST, GET }
        public MethodType methodType;
        public byte[] body;
    }

    [System.Serializable]
    public struct CreateThreadResult
    {
        public string id;
    }

    [System.Serializable]
    public struct AddMessageRequestBody
    {
        public string role;
        public string content;
    }

    [System.Serializable]
    public struct RunRequestBody
    {
        public string assistant_id;
    }

    [System.Serializable]
    public struct RunResult
    {
        public string id;
        public string last_error;
        public string instructions;
        public string model;
    }

    [System.Serializable]
    public struct ListMessagesResult
    {
        public Message[] data;
    }

    [System.Serializable]
    public struct CreateThreadBody
    {
        public InitialMessage[] messages;
    }

    [System.Serializable]
    public struct Message
    {
        public string id;
        public string role;
        public MessageContent[] content;
    }

    [System.Serializable]
    public struct MessageContent
    {
        public string type;
        public MessageText text;
    }

    [System.Serializable]
    public struct InitialMessage
    {
        public string role;
        public InitialMessageContent[] content;
    }

    [System.Serializable]
    public struct InitialMessageContent
    {
        public string type;
        public string text;
    }

    [System.Serializable]
    public struct MessageText
    {
        public string value;
        public string[] annotations;
    }

    [System.Serializable]
    public struct Configuration
    {
        public string api_key;
        public string organization;
    }


}

