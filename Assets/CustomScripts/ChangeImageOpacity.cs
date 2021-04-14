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
    public float init_opacity = 0.35f;
    public float opacity_step = 0.2f;
    public float lower_bound = 0.35f;
    public float upper_bound = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        var col = image.color;
        col.a = init_opacity;
        image.color = col;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseOpacity()
    {
        Debug.Log("Image opacity decreasing");
        var col = image.color;
        var decreasedTo = col.a - opacity_step;
        col.a = decreasedTo <= lower_bound? lower_bound : decreasedTo;
        image.color = col;
        Debug.Log("col.a: " + image.color.a);
    }

    public void IncreaseOpacity()
    {
        Debug.Log("Image opacity increasing");
        var col = image.color;
        var increasedTo = col.a + opacity_step;
        col.a = increasedTo >= upper_bound ? upper_bound : increasedTo;
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
