using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager Instance;

    public Text destinationText;
    public Text statusText;

    public Text locationName;

    public Text characterName;
    public Text characterInformation;

    public Text objectName1, objectDescription1;

    public Text objectName2, objectDescription2;


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
    /// Temporarly add a sentence to a text.
    /// </summary>
    public void TempText(Text text, string sentence, float duration)
    {
        StartCoroutine(TempTextIE(text, sentence, duration));
    }


    IEnumerator TempTextIE(Text text, string sentence, float duration)
    {
        text.text = sentence;
        yield return new WaitForSeconds(duration);
        text.text = null;
    }
}