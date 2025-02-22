using UnityEditor;

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

            serializedObject.ApplyModifiedProperties();
        }
    }
}