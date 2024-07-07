using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;

namespace OpenAIAssistantsApi
{
    public class OpenAIConfigurationWindow : EditorWindow
    {
        private string inputField;
        const string authenticationFile = "openAiAuth";
        const string authenticationFilePath = "Assets/OpenAIAssistantsApi/Resources/openAiAuth.json";
            

        [MenuItem("Window/OpenAI Configuration")]
        public static void ShowWindow()
        {
            OpenAIConfigurationWindow window = GetWindow<OpenAIConfigurationWindow>("OpenAI Configuration Window");
            if (!File.Exists(authenticationFilePath))
            {
                window.CreateAuthenticationFile();
            }
            window.inputField = window.GetApiKeyFromAuthFile();            
        }

        private void OnGUI()
        {
            // Title
            GUILayout.Label("Set up your API Key", new GUIStyle() { fontSize = 20, fontStyle = FontStyle.Bold });

            GUILayout.Space(10);

            // Label and Input Field
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Input Field:", GUILayout.Width(70));
            inputField = EditorGUILayout.TextField(inputField);
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);

            // Apply Button
            if (GUILayout.Button("Apply"))
            {
                ApplyInput();
            }
        }

        private void ApplyInput()
        {
            if (!string.IsNullOrEmpty(inputField))
            {
                SetNewApiKey(inputField);
                Debug.Log("Set new api key to be " + inputField);
            }
            else
            {
                Debug.LogError("Could not set new api key because input field is empty");
            }
        }

        string GetApiKeyFromAuthFile()
        {
            TextAsset auth = Resources.Load<TextAsset>(authenticationFile);
            if (auth != null)
            {
                Configuration configuration = JsonUtility.FromJson<Configuration>(auth.text);
                return configuration.api_key;
            }
            else
            {
                Debug.LogError("NO AUTHENTICATION FILE! Add one to your Resources folder.");
                return "";
            }
        }

        void SetNewApiKey(string newApiKey)
        {
            Configuration configuration = new Configuration();
            configuration.api_key = newApiKey;
            string authText = JsonUtility.ToJson(configuration);
            try
            {
                File.WriteAllText(authenticationFilePath, authText);
                AssetDatabase.Refresh(); // Refresh the asset database to reflect changes in the editor
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to write to auth file: " + e.Message);
            }
        }

        private void CreateAuthenticationFile()
        {
            Configuration configuration = new Configuration();
            configuration.api_key = "";
            string authText = JsonUtility.ToJson(configuration);
            try
            {
                File.WriteAllText(authenticationFilePath, authText);
                AssetDatabase.Refresh(); // Refresh the asset database to reflect changes in the editor
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to write to auth file: " + e.Message);
            }
        }
    }
    
}
