using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator characterAnim;
    public Image locationImage;

    public Image topObjectImage, bottomObjectImage;

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

    public void LocationUI(int locInt)
    {
        string path = "UISprites/";

        locationImage.sprite = Resources.Load<Sprite>(path + "Locations/" + locInt);
        characterAnim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(path + "Characters/" + locInt);

        topObjectImage.sprite = Resources.Load<Sprite>(path + "TopObjects/" + locInt);
        bottomObjectImage.sprite = Resources.Load<Sprite>(path + "BottomObjects/" + 0);
    }

    public void SetObjectSprites(bool top, bool bottom)
    {
        if (top)
        {
            topObjectImage.color = Color.white;
        }
        else
        {
            topObjectImage.color = Color.black;
        }

        if (bottom)
        {
            bottomObjectImage.color = Color.white;
        }
        else
        {
            bottomObjectImage.color = Color.black;
        }
    }
}