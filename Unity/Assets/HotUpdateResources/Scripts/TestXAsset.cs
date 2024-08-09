using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Networking;
using xasset;

public class TestXAsset : MonoBehaviour
{
    private void Start()
    {
        Addressables.InstantiateAsync("Assets/XAsset/HotFix/Remote/Res/Capsule.prefab");
        return;
        StartCoroutine(UpdateAddreaasble());
    }

    private InitializeRequest InitXAsset()
    {
        return Assets.InitializeAsync();
    }

    private IEnumerator UpdateAddreaasble()
    {
        yield return Addressables.InitializeAsync();
        UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<List<string>> check = Addressables.CheckForCatalogUpdates(true);
        yield return check;
        if (!check.Status.Equals(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)) yield break;
        if (check.Result.Count == 0) yield break;
        UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<List<IResourceLocator>> updateHandle = Addressables.UpdateCatalogs(check.Result);
        yield return updateHandle;
        if (!updateHandle.Status.Equals(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)) yield break;
        List<IResourceLocator> locators = updateHandle.Result;
        foreach (IResourceLocator locator in locators)
        {

        }
    }
}
