using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text destinationText;
    public Text statusText;

    public Text locationName;

    public Text characterTextTitle;
    public Text characterTextDescription;

    public Text topObjectName, topObjectDescription;

    public Text bottomObjectName, bottomObjectDescription;

    /// <summary>
    /// Overwrite a Text string.
    /// </summary>
    public void SetText(Text text, string sentence)
    {
        text.text = sentence;
    }

    /// <summary>
    /// Add to the already existing Text string.
    /// </summary>
    public void AddText(Text text, string sentence)
    {
        text.text += sentence;
    }

    /// <summary>
    /// Temporarily change the sprite and after the duration sets it back to the origional..
    /// </summary>
    public void TempText(Text text, string sentence, float duration)
    {
        StartCoroutine(TempTextIE(text, sentence, duration));
    }


    IEnumerator TempTextIE(Text text, string sentence, float duration)
    {
        string org = text.text;
        text.text = sentence;
        yield return new WaitForSeconds(duration);
        text.text = org;
    }

    void LocationText()
    {
        int locInt = (int)WorldManager.locations;

        //Loading Json and taking the right array of SceneInfo.
        SceneInfoArray data;
        string dataPath = Application.streamingAssetsPath + "/SceneInfo.json";
        string json = File.ReadAllText(dataPath);
        data = JsonUtility.FromJson<SceneInfoArray>(json);
        SceneInfo sceneInfo = data.SceneInfo[locInt];

        //Set Text on the UI.
        locationName.text = sceneInfo.locationName;

        characterTextTitle.text = sceneInfo.characterTextTitle;
        characterTextDescription.text = sceneInfo.characterTextDescription;

        topObjectName.text = sceneInfo.topObjectName;
        topObjectDescription.text = sceneInfo.topObjectDescription;

        bottomObjectName.text = sceneInfo.bottomObjectName;
        bottomObjectDescription.text = sceneInfo.bottomObjectDescription;
    }
}




//Set Text Object structure.
[System.Serializable]
public struct SceneInfoArray
{
    public SceneInfo[] SceneInfo;
}

[System.Serializable]
public class SceneInfo
{
    public string locationName;

    public string characterTextTitle;
    public string characterTextDescription;

    public string topObjectName;
    public string topObjectDescription;

    public string bottomObjectName;
    public string bottomObjectDescription;
}