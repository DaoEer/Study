using JEngine.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using xasset;

public class Main : MonoBehaviour
{
    private void Start()
    {
        AssetMgr.Load<GameObject>("Assets/HotUpdateResources/Remote_1/Other/Cube.prefab");
    }
}
