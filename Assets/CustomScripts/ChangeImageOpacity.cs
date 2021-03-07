using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageOpacity : MonoBehaviour
{
    RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        // for (int i = 0; i < 4; i++)
        // {
        //     DecreaseOpacity();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseOpacity()
    {
        Debug.Log("Image opacity decreasing");
        var col = image.color;
        col.a = col.a - 0.2f <= 0.0f ? 0.0f : col.a - 0.2f;
        image.color = col;
        Debug.Log("col.a: " + image.color.a);
    }

    public void IncreaseOpacity()
    {
        Debug.Log("Image opacity increasing");
        var col = image.color;
        col.a = col.a + 0.2f >= 1.0f ? 1.0f : col.a + 0.2f;
        image.color = col;
        Debug.Log("col.a: " + image.color.a);
    }
}
