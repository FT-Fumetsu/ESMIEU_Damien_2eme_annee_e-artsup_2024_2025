using UnityEngine;

namespace Structures
{
    [System.Serializable]
        public struct Stats
        {
            [Range(0, 100)] public int Health;
            [Range(0, 250)] public float Mana;
        }
}