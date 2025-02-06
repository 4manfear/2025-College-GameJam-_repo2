using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class card_random_pick : MonoBehaviour
{
    public GameObject maincanves;

    //public TextMeshProUGUI thisbutton;
    public Button thisbutton;

    public GameObject card1;
    public GameObject card2;

   
    public Sprite good_card_img;
    public bool good_card_selected;
    public Sprite bad_card_img;
    public bool bad_card_selected;
    public Sprite death_card_img;
    public bool death_card_selected;

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
            good_card_selected = true;
            Destroy(maincanves, 3);
        }
        if (randomnumber <= 5 && randomnumber > 2)
        {
            thisbutton.image.sprite = bad_card_img;
            Destroy(maincanves, 3);
            bad_card_selected = true;
        }
        if (randomnumber > 5)
        {
            death_card_selected = true;
            Destroy(maincanves, 3);
        }

    }
}



