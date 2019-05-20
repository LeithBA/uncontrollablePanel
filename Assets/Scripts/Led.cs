using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led : MonoBehaviour
{

    [Range(0.0f, 1.0f), SerializeField] public float hue, saturation, brightness;
    [HideInInspector] public bool active = false;

    void Start()
    {
        hue = Random.Range(-0.0f, 1.0f);
    }
    void Update()
    {
        //hue = hue + Random.Range(-0.01f, 0.01f);
        //if (hue < 0)
        //	hue++;
        //else if (hue > 1)
        //	hue--;
        this.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, saturation, brightness);
    }

    public void Toggle()
    {
		Camera.main.GetComponent<Playlist>().danger = true;
        if (brightness == 0)
        {
            active = true;
            brightness = 1;
        }
        else if (brightness == 1)
        {
            active = false;
            brightness = 0;
        }
    }

    public void turnOff()
    {
		Camera.main.GetComponent<Playlist>().danger = false;
        active = false;
        brightness = 0;
    }
}
