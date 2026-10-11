using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerKindProbabilityData",menuName = "ScriptableObject/CustomerKindProbabilityData")]
public class CustomerKindProbabilityData : ScriptableObject
{
    public CustomerKind customerKind;
    public float probability;
}
