using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image darkness;
    public bool darkening = false;

    [Range(0, 1.0f)]
    public float alphaAmount;

    // Use this for initialization
    void Start()
    {
        darkness = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (darkness.color.a < 1.0f && darkening == true)
        {
            darkness.color += new Color(0, 0, 0, alphaAmount);
        }

        if (darkness.color.a > 0.0f && darkening == false)
        {
            darkness.color -= new Color(0, 0, 0, alphaAmount);
        }
    }
}