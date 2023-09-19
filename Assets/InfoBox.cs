using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
    public Image canvasImage;
    public Sprite[] images;
    public GameObject[] CardBoxes;
    //this is largely controlled by the SelectMoveToPosition script
    void Start()
    {
        canvasImage = GetComponent<Image>();
        Clear();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Select(GameObject selectedObject)
    {
        canvasImage.sprite = images[0];
        if (selectedObject.GetComponent<CombatCardManager>() != null)
        {
        CardBoxes[0].SetActive(true);
        CardBoxes[1].SetActive(true);
        }
    }
    public void Clear()
    {
        canvasImage.sprite = images[1];
        CardBoxes[0].SetActive(false);
        CardBoxes[1].SetActive(false);
    }
}
