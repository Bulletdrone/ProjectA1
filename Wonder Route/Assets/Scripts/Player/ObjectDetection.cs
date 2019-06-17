using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;

    [SerializeField]
    private int _sightDistance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectObject();
        }
    }

    void DetectObject()
    {
        RaycastHit hit;
        Ray forwardRay = new Ray(_cam.transform.position, transform.forward);

        if (Physics.Raycast(forwardRay, out hit, _sightDistance))
        {
            Debug.DrawRay(_cam.transform.position, hit.point, Color.green);
            Animator animator = hit.collider.GetComponent<Animator>();

            if (animator == null)
            {
                //change textt
                return;
            }

            animator.SetTrigger("StartAnimation");
        }
    }
}
