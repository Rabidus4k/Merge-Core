using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public UnitInfo UnitInfo => unitInfo;
    private UnitInfo unitInfo;

    public void Init(UnitInfo info)
    {
        unitInfo = info;
    }
}
