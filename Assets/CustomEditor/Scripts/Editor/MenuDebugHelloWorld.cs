using UnityEditor;
using UnityEngine;

namespace MenuDebug
{
    public class MenuDebugHelloWorld : Editor
    {
        [MenuItem("Tools/Log Console/Debug Hello World")]
        public static void DebugHelloWorld()
        {
            Debug.Log("Hello World");
        }
    }
}