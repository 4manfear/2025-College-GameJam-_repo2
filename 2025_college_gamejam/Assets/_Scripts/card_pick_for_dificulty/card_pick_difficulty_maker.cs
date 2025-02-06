using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class card_pick_difficulty_maker : MonoBehaviour
{
    public bool card_picker_function = true;

    public card_random_pick crp;
    public bool cardselecting;



    public bool good_level;
    public int good_level_number;
    public bool bad_level;
    public int bad_level_number;

    public GameObject card_draw_prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (card_picker_function)
            {
                Instantiate(card_draw_prefab);
                cardselecting = true;
            }
           
        }
    }

    private void Update()
    {
        if (cardselecting)
        {
            crp = FindObjectOfType<card_random_pick>();

            if (crp.good_card_selected)
            {
                good_level = true;
                goodlevel_additatyive_loader();
                cardselecting= false;
                card_picker_function = false;
            }
            if (crp.bad_card_selected == true)
            {
                bad_level = true;
                badlevel_sceneloadieradditive();
                cardselecting = false;
                card_picker_function = false;
            }
        }

       


    }


    public void reseter()
    {
        good_level = false;
        bad_level = false;
    }

    void goodlevel_additatyive_loader()
    {
        //SceneManager.LoadScene(good_level_number, LoadSceneMode.Additive);

        crp.good_card_selected = false;

    }
    void badlevel_sceneloadieradditive()
    {
       // SceneManager.LoadScene(bad_level_number, LoadSceneMode.Additive);
        crp.bad_card_selected = false;
    }
}
