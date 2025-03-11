using Structures;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Drawer
{
    [CustomPropertyDrawer(typeof(Stats))]
    public class StatsDrawer : PropertyDrawer
    {
        private const string HEALTH_NAME = "Health";
        private const string MANA_NAME = "Mana";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //récupérer la propriété.
            SerializedProperty healthProperty = property.FindPropertyRelative(HEALTH_NAME);
            //récupérer le min et le max du range.
            RangeAttribute healthRange = typeof(Stats).GetField(nameof(Stats.Health)).GetCustomAttribute<RangeAttribute>();

            Rect propertyPosition = new(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.PropertyField(propertyPosition, healthProperty);

            propertyPosition = new Rect(propertyPosition.x, 
                                        propertyPosition.y + EditorGUIUtility.singleLineHeight, 
                                        propertyPosition.width, 
                                        propertyPosition.height);

            EditorGUI.ProgressBar(propertyPosition,
                                  healthProperty.intValue / healthRange.max,
                                  $"Health ({healthProperty.intValue} / {healthRange.max})");

            SerializedProperty manaProperty = property.FindPropertyRelative(MANA_NAME);
            RangeAttribute manaRange = typeof(Stats).GetField(nameof(Stats.Mana)).GetCustomAttribute<RangeAttribute>();

            propertyPosition = new Rect(propertyPosition.x,
                                        propertyPosition.y + EditorGUIUtility.singleLineHeight,
                                        propertyPosition.width,
                                        propertyPosition.height);

            EditorGUI.PropertyField(propertyPosition, manaProperty);

            propertyPosition = new Rect(propertyPosition.x,
                                        propertyPosition.y + EditorGUIUtility.singleLineHeight,
                                        propertyPosition.width,
                                        propertyPosition.height);

            EditorGUI.ProgressBar(propertyPosition,
                                  manaProperty.floatValue / manaRange.max,
                                  $"Mana ({manaProperty.floatValue} / {manaRange.max})");
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 4;
        }
    }
}