using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour
{
    public LayerMask layers = 8;
    private Collider _lastHitCollider;
    // Use this for initialization

    void Start()
    {
        layers = LayerMask.NameToLayer("VrUsableLayer");
        print(layers.value);

    }

    // Update is called once per frame
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 200);

        Debug.DrawRay(ray.origin, transform.forward * 200, Color.cyan);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "SceneModifier")
            {
                ChangeSceneScript sceneChanger = hit.collider.gameObject.GetComponent<ChangeSceneScript>();
                
                if (sceneChanger != null)
                {
                    sceneChanger.Gazing();
                }
                if (_lastHitCollider == null)
                {
                    _lastHitCollider = hit.collider;
                }
            }

            else if (hit.collider.gameObject.tag == "VR_menu")
            {
                //Hello world
            }
      /*      else if (hit.collider.gameObject.tag == "PositionModifier")
            {
                ChangePosition positionChanger = hit.collider.gameObject.GetComponent<ChangePosition>();
                if (positionChanger != null)
                {
                    positionChanger.Gazing();
                }
                if (_lastHitCollider == null)
                {
                    _lastHitCollider = hit.collider;
                }
            }*/
            else
            {

            }

        }



        else if (_lastHitCollider != null)
        {

        //    try
        //    {
                _lastHitCollider.gameObject.GetComponent<ChangeSceneScript>().NotGazing();
        //    }
        //    catch (System.Exception e) { }
        //
        //    try
        //    {
        //        _lastHitCollider.gameObject.GetComponent<ChangePosition>().NotGazing();
        //   }
        //   catch (System.Exception e) { }

            _lastHitCollider = null;
        }




    }
}