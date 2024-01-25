using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandShirtColour : MonoBehaviour
{
    public SpriteRenderer shirtSprite;

    public Color[] colours;

    private void Start()
    {
        int i = Random.Range(0, colours.Length);

        shirtSprite.color = colours[i];
    }
}
