using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "all_exorcist_items", menuName = "all_exorcist_items")]
public class can_be_spawned_items : ScriptableObject
{
    public bool candles;
    public bool Holey_water;
    public bool cursed_doll;
    public bool cross;

    public bool candles_placed;
    public bool Holey_water_Placed;
    public bool cursed_doll_Placed;
    public bool cross_Placed;
}
