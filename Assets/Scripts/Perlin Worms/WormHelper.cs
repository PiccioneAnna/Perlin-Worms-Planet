using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helper methods for worm generation
/// </summary>
internal class WormHelper
{
    public static float RangeMap(float inputValue, float inMin, float inMax, float outMin, float outMax)
    {
        return outMin + (inputValue - inMin) * (outMax - outMin) / (inMax - inMin);
    }
}
