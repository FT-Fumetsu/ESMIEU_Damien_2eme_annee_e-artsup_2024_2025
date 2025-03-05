using Attribute;
using UnityEditor;
using UnityEngine;

namespace AttributeDrawer
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Integer || property.propertyType == SerializedPropertyType.String)
            {
                var scenes = EditorBuildSettings.scenes;
                string[] sceneNames = new string[scenes.Length];
                for (int i = 0; i < scenes.Length; i++)
                {
                    sceneNames[i] = System.IO.Path.GetFileNameWithoutExtension(scenes[i].path);
                }

                if (property.propertyType == SerializedPropertyType.Integer)
                {
                    property.intValue = EditorGUI.Popup(position, label.text, property.intValue, sceneNames);
                }
                else if (property.propertyType == SerializedPropertyType.String)
                {
                    int index = System.Array.IndexOf(sceneNames, property.stringValue);
                    index = EditorGUI.Popup(position, label.text, index, sceneNames);
                    property.stringValue = index >= 0 ? sceneNames[index] : "";
                }
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use [Scene] with int or string.");
            }
        }
    }
}