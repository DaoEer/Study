using Cysharp.Threading.Tasks;
using UnityEngine;
using xasset;

public class TestXAsset : MonoBehaviour
{
    private async void Start()
    {
        await InitXAsset();
    }

    private InitializeRequest InitXAsset()
    {
        return Assets.InitializeAsync();
    }
}
