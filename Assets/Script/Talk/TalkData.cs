using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkData",menuName = "ScriptableObject/TalkData")]
public class TalkData : ScriptableObject
{
    public NPCState NPCState = NPCState.None;
    [Multiline(3)]
    public List<string> Details = new List<string>();
}
