using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroInteraction : MonoBehaviour
{
    private NavMeshAgent heroAgent;
    private RaycastHit hit;

    public Camera camera;
    public Animator heroAnimator;


    private string groundflag = "Ground";
    public LayerMask layermask;
    public float rayLength;

    public bool moving;
    public bool ready;
    public bool attack;
    public float meleerange;
    public float attackpause;

    // Start is called before the first frame update
    void Start()
    {
        heroAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layermask)) 
            {
                Debug.Log(1);
            }


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundflag)) ;
                {
                    heroAgent.SetDestination(hit.point);
                }
                

            }

        }

        if (heroAgent.remainingDistance > 0.1f)
        {
            heroAnimator.SetBool("Walk", true);

        }
        if (heroAgent.remainingDistance < 0.1f)
        {
            heroAnimator.SetBool("Walk", false);

        }


    }
}
