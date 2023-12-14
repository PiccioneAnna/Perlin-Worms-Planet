using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Worm
{
    #region Fields

    [SerializeField] public WormBody wBody;
    [SerializeField] public WormSkeleton wSkeleton;
    [SerializeField] public WormSettings wSettings;

    #endregion

    public Worm(WormSettings settings, Vector3 mousePos)
    {
        wSkeleton = new(mousePos);
        wSettings = settings;
        wSkeleton.settings = settings;
        wSkeleton.filter = new WormNoiseFilter(settings);
        wBody = new(wSkeleton, wSettings);
    }
}