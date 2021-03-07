using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOpacity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseOpacity()
    {
        Debug.Log("Opacity decreasing");
        var childRenders = gameObject.GetComponentsInChildren<Renderer>();
        foreach (var render in childRenders)
        {
            var col = render.material.color;
            col.a = col.a - 0.2f <= 0.0f ? 0.0f : col.a - 0.2f;
            render.material.color = col;
            Debug.Log("col.a: " + col.a);
        }
        Debug.Log("Opacity decreased by 0.2");
        Debug.Log("childRenders len: " + childRenders.Length);
        Debug.Log("last opacity: " + childRenders[0].material.color.a);
    }

    public void increaseOpacity()
    {
        var childRenders = gameObject.GetComponentsInChildren<Renderer>();
        foreach (var render in childRenders)
        {
            var col = render.material.color;
            col.a = col.a + 0.2f >= 1.0f ? 1.0f : col.a + 0.2f;
            render.material.color = col;
        }
        Debug.Log("Opacity increased by 0.2");
    }
}
