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
}