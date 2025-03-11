using UnityEditor;
using UnityEngine;

namespace DisplayConsole
{
    public class DisplayConsoleHelloWorld : Editor
    {
        [MenuItem("Tools/Log Console/Debug Hello World")]
        public static void DebugelloWorld()
        {
            Debug.Log("Hello World");
        }
    }
}