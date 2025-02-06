using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class check_item_placing : MonoBehaviour
{
    [SerializeField] private pickup_and_drop pick_and_drop_script;
    [SerializeField] private GameObject Player;

    [SerializeField] private float distance_to_place_items;

    public bool canplace;

    [Header("items to be placed")]
    public string candles_tag;
    [SerializeField] private GameObject candles;
    public bool candleplaced;

    public string holeywater_tag;
    [SerializeField] private GameObject holey_water;
    public bool holey_water_placed;

    public string cursedoll_tag;
    [SerializeField] private GameObject Curseddoll;
    public bool curseddoll_placed;

    public string cross_tag;
    [SerializeField] private GameObject cross;
    public bool cross_placed;


    private void Start()
    {
        candles.SetActive(false);
        Curseddoll.SetActive(false);
        holey_water.SetActive(false);
        cross.SetActive(false);

       

        
       
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        pick_and_drop_script = FindObjectOfType<pickup_and_drop>();
        distance_checker();

        if (canplace)
        {
            if (pick_and_drop_script.pickedobject.CompareTag(candles_tag))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    placing_candlers();
                }
            }
            if (pick_and_drop_script.pickedobject.CompareTag(holeywater_tag))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    placing_holeyWater();
                }
            }
            if (pick_and_drop_script.pickedobject.CompareTag(cursedoll_tag))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    placing_curseddoll();
                }
            }
            if (pick_and_drop_script.pickedobject.CompareTag(cross_tag))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    placing_cross();
                }
            }
        }
    }

    void distance_checker()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);

        if (distance <= distance_to_place_items)
        {
            canplace = true;
        }
        else if (distance > distance_to_place_items)
        {
            canplace = false;
        }
    }

    void placing_candlers()
    {
        Destroy(pick_and_drop_script.pickedobject);
        candles.SetActive(true);
        candleplaced = true;
    }
    void placing_curseddoll()
    {
        Destroy(pick_and_drop_script.pickedobject);
        Curseddoll.SetActive(true);
        curseddoll_placed = true;
    }
    void placing_holeyWater()
    {
        Destroy(pick_and_drop_script.pickedobject);
        holey_water.SetActive(true);
        holey_water_placed = true;
    }
    void placing_cross()
    {
        Destroy(pick_and_drop_script.pickedobject);
        cross.SetActive(true);
        cross_placed = true;
    }

}
