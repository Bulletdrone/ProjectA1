using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image locationSprite;

    public Image characterSprite;

    public Image topObject, bottomObject;

    /// <summary>
    /// Overwrite the Image's Sprite.
    /// </summary>
    public void SetImage(Image image, Sprite sprite)
    {
        image.sprite = sprite;
    }

    /// <summary>
    /// Temporarily change the sprite and after the duration sets it back to the origional.
    /// </summary>
    public void TempImage(Image image, Sprite sprite, float duration)
    {
        StartCoroutine(TempImageIE(image, sprite, duration));
    }


    IEnumerator TempImageIE(Image image, Sprite sprite, float duration)
    {
        Sprite org = image.sprite;
        image.sprite = sprite;
        yield return new WaitForSeconds(duration);
        image.sprite = org;
    }
}