using System;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthPoint", menuName = "Character/Health", order = 1)]
    public class HealthPoint : ScriptableObject
    {
        public Action LoseHealthEvent;
    }
}