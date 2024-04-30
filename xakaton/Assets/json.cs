using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class json : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nm;
    public Slider dat1;
    public string jsonURL;
    public Jsonclass jsnData;

    void Start()
    {
        dat1.interactable = false;
        StartCoroutine(getData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator getData()
    {
        Debug.Log("Download...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            nm.text = "ERROR";
        else
        {
            Debug.Log("Download saved to: " + resultFile);
            jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            nm.text = jsnData.Level.ToString();
            dat1.value = jsnData.Level;
            yield return StartCoroutine(getData());
        }
    }
    [System.Serializable]

    public class Jsonclass
    {
        public string Name;
        public int Level;

    }
}
