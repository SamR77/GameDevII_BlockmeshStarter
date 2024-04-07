using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImageSelector : MonoBehaviour
{
    public List<Sprite> images; // List to hold your images
    public Image uiImage;       // Reference to your UIImage component

    void Start()
    {
        if (images.Count > 0)
        {
            SetRandomImage();
        }
    }

    void SetRandomImage()
    {
        int index = Random.Range(0, images.Count); // Generate a random index
        uiImage.sprite = images[index];            // Set the UIImage sprite to the randomly selected image
    }
}
