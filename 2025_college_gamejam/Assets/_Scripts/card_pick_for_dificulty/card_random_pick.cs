using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class card_random_pick : MonoBehaviour
{
    //public TextMeshProUGUI thisbutton;
    public Button thisbutton;

    public GameObject card1;
    public GameObject card2;

   
    public Sprite good_card_img;
    public Sprite bad_card_img;
    public Sprite death_card_img;

    public Animator anim;

    int randomnumber;

    public void randomvaluepicker()
    {
        randomnumber = Random.Range(0, 8);
        anim.SetBool("draw", true);
        card1.SetActive(false);
        card2.SetActive(false);

        Debug.Log("picked number is =" + randomnumber);
    }

    public void changing_texture()
    {
        if (randomnumber <= 2)
        {
            thisbutton.image.sprite = good_card_img;
        }
        if (randomnumber <= 5 && randomnumber > 2)
        {
            thisbutton.image.sprite = bad_card_img;
        }

    }
}



