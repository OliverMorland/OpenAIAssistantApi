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
        const string authenticationFile = "auth";


        [MenuItem("Window/OpenAI Configuration")]
        public static void ShowWindow()
        {
            OpenAIConfigurationWindow window = GetWindow<OpenAIConfigurationWindow>("OpenAI Configuration Window");
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
                Debug.Log("Input Applied: " + inputField);
            }
            else
            {
                Debug.LogWarning("Input field is empty!");
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
            string path = "Assets/Resources";
            try
            {
                //File.WriteAllText(path, content);
                Debug.Log("Auth file content set successfully.");
                AssetDatabase.Refresh(); // Refresh the asset database to reflect changes in the editor
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to write to auth file: " + e.Message);
            }
        }
    }
    
}
