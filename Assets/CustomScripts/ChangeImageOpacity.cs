using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageOpacity : MonoBehaviour
{
    RawImage image;
    public int image_num = 14;
    private string image_prefix =  "Images/";
    public string image_format = ".png";
    private int cur_image_no = 1;
    public float opacity_step = 0.25f;
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
        col.a = col.a - opacity_step <= 0.0f ? 0.0f : col.a - opacity_step;
        image.color = col;
        Debug.Log("col.a: " + image.color.a);
    }

    public void IncreaseOpacity()
    {
        Debug.Log("Image opacity increasing");
        var col = image.color;
        col.a = col.a + opacity_step >= 1.0f ? 1.0f : col.a + opacity_step;
        image.color = col;
        Debug.Log("col.a: " + image.color.a);
    }

    public void NextImage(){
        image.texture = newTexture(true);
    }

    public void PreviousImage(){
        image.texture = newTexture(false);
    }

    private Texture2D newTexture(bool next)
    {
        if(next)
        {
            cur_image_no = cur_image_no % image_num + 1; // in range 1 to image_num
        }
        else
        {
            cur_image_no = cur_image_no==1 ? image_num : cur_image_no-1;
        }
        string next_texture_path = image_prefix + cur_image_no.ToString();
        Debug.Log("next image path: " + next_texture_path);
        Texture2D next_texture = Resources.Load<Texture2D>(next_texture_path);
        if(next_texture is null){
            Debug.Log("error loading image");
        }
        return next_texture;
    }
}
