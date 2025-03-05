using UnityEditor;
using UnityEngine;

namespace ComponentEditor
{
    [CustomEditor(typeof(SuperComponent))]
    [CanEditMultipleObjects]
    public class SuperComponentEditor : Editor
    {
        SerializedProperty _sceneIndexProperty;
        SerializedProperty _sampleTextProperty;


        public void OnEnable()
        {
            _sampleTextProperty = serializedObject.FindProperty("_sampleText");
            _sceneIndexProperty = serializedObject.FindProperty("_sceneIndex");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_sampleTextProperty);

            EditorGUILayout.LabelField(_sampleTextProperty.stringValue);

            EditorGUILayout.PropertyField(_sceneIndexProperty);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("+"))
            {
                if (_sceneIndexProperty.intValue == 1)
                {
                    return;
                }
                else
                {
                    _sceneIndexProperty.intValue += 1;
                }                
            }

            if (GUILayout.Button("-"))
            {
                if (_sceneIndexProperty.intValue == 0)
                {
                    return;
                }
                else
                {
                    _sceneIndexProperty.intValue -= 1;
                }
            }

            EditorGUILayout.EndHorizontal();

            //SceneManager.GetSceneByBuildIndex(_sceneIndexProperty.intValue);

            serializedObject.ApplyModifiedProperties();
        }
    }
}