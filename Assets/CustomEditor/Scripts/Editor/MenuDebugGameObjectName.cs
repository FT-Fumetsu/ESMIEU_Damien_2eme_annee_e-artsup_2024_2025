using UnityEditor;
using UnityEngine;

namespace MenuDebug
{
    public class MenuDebugGameObjectName : Editor
    {
        [MenuItem("Tools/Log Console/Debug Game Object Name")]
        public static void DebugGameObjectName()
        {
            Debug.Log(Selection.activeGameObject.name);
        }

        [MenuItem("Tools/Log Console/Debug Game Object Name", true)]
        public static bool ValidateLogSelectedGameObjectName()
        {
            return Selection.activeGameObject != null;
        }
    }
}