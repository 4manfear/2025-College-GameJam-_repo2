using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public card_pick_difficulty_maker cpdm;

    public GameObject[] jumpscare_canvas;

    public int hard_jumpScare;
    public int easy_jumpScare;

    public int random_number_forjumpscare;

    public float appearing_timming;

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cpdm.good_level)
            {
                random_number_forjumpscare = Random.Range(0, hard_jumpScare);
            }
            if (cpdm.bad_level)
            {
                random_number_forjumpscare = Random.Range(0, easy_jumpScare);
            }
            if (random_number_forjumpscare == 1)
            {
                StartCoroutine(TriggerJumpscare());
            }
        }
    }

    private IEnumerator TriggerJumpscare()
    {
        // Choose a random GameObject from the array
        int randomIndex = Random.Range(0, jumpscare_canvas.Length);
        GameObject selectedJumpscare = jumpscare_canvas[randomIndex];

        // Activate the jumpscare
        selectedJumpscare.SetActive(true);

        // Wait for 0.6 seconds
        yield return new WaitForSeconds(appearing_timming);

        // Deactivate the jumpscare
        selectedJumpscare.SetActive(false);
    }

}
