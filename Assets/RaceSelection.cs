using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceSelection : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;
    DelverController Source;
    public Sprite[] Races;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Source = GetComponentInParent<DelverController>();
        m_SpriteRenderer.sprite = Races[Source.RaceType];
        Destroy(this, 1);
    }


}