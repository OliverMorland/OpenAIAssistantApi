using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OpenAIAssistantsApi.WebRequestData;

namespace OpenAIAssistantsApi
{
    public class Utils
    {
        public static string GetMethodTypeAsString(WebRequestData.MethodType methodType)
        {
            string methodAsString = "";
            switch (methodType)
            {
                case WebRequestData.MethodType.POST:
                    methodAsString = "POST";
                    break;
                case WebRequestData.MethodType.GET:
                    methodAsString = "GET";
                    break;
                default:
                    methodAsString = "GET";
                    break;
            }
            return methodAsString;
        }
    }
}
