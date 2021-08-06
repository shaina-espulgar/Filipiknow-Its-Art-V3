using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBehavior : MonoBehaviour
{
    [SerializeField] private GameObject toggle;

    private int toggleState;

    [SerializeField] private Sprite[] switchSprites;

    private Image switchImage;

    // Start is called before the first frame update
    void Start()
    {
        toggleState = 0;

        switchImage = GetComponent<Button>().image;
        switchImage.sprite = switchSprites[toggleState];

        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
    }

    // Update is called once per frame
    void TurnOnAndOff()
    {
        toggleState = 1 - toggleState;
        switchImage.sprite = switchSprites[toggleState];
    }
}
