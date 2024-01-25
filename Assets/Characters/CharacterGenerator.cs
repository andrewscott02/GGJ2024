using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public Object[] pieces;

    private void Start()
    {
        Instantiate(pieces[Random.Range(0, pieces.Length)], transform);
    }
}
