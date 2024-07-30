using System.Threading.Tasks;
using UnityEngine;

public class TestUniTask : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Test();
    }

    private async void Test()
    {
        int log = await WaitTime(3000);
        Debug.Log(3);
    }

    private async Task<int> WaitTime(int time)
    {
        await Task.Delay(time);
        return time;
    }
}
