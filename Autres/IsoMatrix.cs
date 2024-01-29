using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IsoMatrix
{
    public static readonly Quaternion ToIso;
    public static readonly Quaternion FromIso;
    public static readonly Quaternion ToIsoY;

    static IsoMatrix()
    {
        ToIso = Quaternion.Euler(35, 45, 0);
        FromIso = Quaternion.Inverse(ToIso);
        ToIsoY = Quaternion.Euler(0, 45, 0);
    }
}