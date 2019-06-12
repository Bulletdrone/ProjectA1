using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image locationImage;
    public Image characterImage;

    public Image topObjectImage, bottomObjectImage;
    private Sprite topSprite, bottomSprite;

    private void Start()
    {
        locationUI(0);
        SetImage(topObjectImage, topSprite);
        SetImage(bottomObjectImage, bottomSprite);
    }

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

    public void locationUI(int locInt)
    {
        string path = "UISprites/";

        locationImage.sprite = Resources.Load<Sprite>(path + locInt + "LocationSprite");
        characterImage.sprite = Resources.Load<Sprite>(path + locInt + "CharacterSprite");

        topSprite = Resources.Load<Sprite>(path + locInt + "TopObject");
        bottomSprite = Resources.Load<Sprite>(path + locInt + "BottomObject");
    }
}