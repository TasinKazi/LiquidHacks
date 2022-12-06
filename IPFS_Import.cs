using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class IPFS_Import : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetRequest("http://localhost:8080/ipfs/Qmd33BfA3mNJZoUqkyCcwk482is9qCMsvvVpaVQU7NeVMM"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    
                    break;
            }
        }
    }
}