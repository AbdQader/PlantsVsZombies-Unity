using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundle : MonoBehaviour
{

    public static string BundleURL;

    [System.Obsolete]
    IEnumerator Start ()
    {
        BundleURL = "file://" + Application.dataPath + "/AssetBundles";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(BundleURL);
        yield return request.Send();
        

        AssetBundle manifestAB = AssetBundle.LoadFromFile("AssetBundles/AssetBundles");
        AssetBundleManifest manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        
        string[] strs = manifest.GetAllDependencies("music");
        foreach (string name in strs)
        {
            print(name);
            AssetBundle.LoadFromFile("AssetBundles/" + name);
        }
    }
}
