using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pickup_and_drop : MonoBehaviour
{
    public Camera main;


    [SerializeField] private Transform Left_hand;


    [SerializeField] private float Distance_to_Pickup;

    [SerializeField] private LayerMask pickable_object_layer;

    private Rigidbody rb;

    public GameObject pickedobject;

    

    public bool In_the_hand;
    public bool canpickup;

    private void Update()
    {
        if (!In_the_hand)
        {
            finding_the_nearest_pickable();
        }
        if (In_the_hand)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                dropping_the_object();
            }
        }

        if (pickedobject != null && pickedobject.transform.parent == Left_hand)
        {
            In_the_hand = true;
        }
        else
        {
            In_the_hand = false;
        }


    }

    void finding_the_nearest_pickable()
    {
        RaycastHit hit;


        Debug.DrawRay(main.transform.position, main.transform.forward * Distance_to_Pickup, Color.red);
        if (Physics.Raycast(main.transform.position, main.transform.forward, out hit, Distance_to_Pickup,pickable_object_layer))
        {
            if (hit.collider != null)
            {
                canpickup = true;
                rb = hit.collider.GetComponent<Rigidbody>();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    pickedobject = hit.collider.gameObject;
                    hit.collider.gameObject.transform.SetParent(Left_hand);
                    hit.collider.gameObject.transform.localPosition = Vector3.zero;
                    hit.collider.gameObject.transform.localRotation = Quaternion.identity;
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }
            }
            else
            {
                canpickup=false;
            }
        }

    }

    void dropping_the_object()
    {
        rb = pickedobject.GetComponent<Rigidbody>();
        pickedobject.transform.SetParent(null);
        rb.useGravity = true;
        rb.isKinematic = false;
    }


}
