using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPoints", menuName = "Character/Health", order = 1)]
public class HealthPoints : ScriptableObject
{
    public Action LoseHealthEvent;
}
