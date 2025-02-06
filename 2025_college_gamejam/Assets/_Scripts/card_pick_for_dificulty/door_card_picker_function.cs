using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_card_picker_function : MonoBehaviour
{
    public card_pick_difficulty_maker cpdm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            cpdm.card_picker_function = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cpdm.card_picker_function = true;
        }
    }

}
