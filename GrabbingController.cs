using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingController : MonoBehaviour
{
    Transform game;
    public Transform grabObjMain;
    ParticleSystem liquid;
    public LayerMask layer;

    public bool puring = false;
    public float pureSpeed = 10f;

    public float MoveObjectspeed = .1f;
    public float maxForward = 1, maxBackward = 0.2f;

    float originHeight;

    void Start()
    {
        originHeight= transform.GetComponent<CapsuleCollider>().height;
        liquid = null;
        game = null;
    }
    void Update()
    {
        Physics.IgnoreLayerCollision(11, 10);
        Physics.IgnoreLayerCollision(10, 12);

        CheckZoomCamera();
        CheckCrouch();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, layer))
            {
                if (hit.collider.CompareTag(StaticString.ErlenmeyerFlask))
                {
                    game = hit.transform;
                    liquid = game.Find("Mesh/Particle System").GetComponent<ParticleSystem>();
                    //
                    grabObjMain.position = game.position;
                }
            }
        }

        if (game)
        {
            game.GetComponent<Rigidbody>().useGravity = !Input.GetMouseButton(0);
            if (Input.GetMouseButton(0))
            {
                Flask();
            }
            else
            {
                game.GetComponent<Rigidbody>().isKinematic=false;
                game = null;
            }
        }
    }

    public Transform TargetPlane;
    public LayerMask layerTarget;
    void Flask()
    {
        game.position = grabObjMain.position;
        game.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // game.GetComponent<Rigidbody>().position =Vector3.Lerp(game.position, grabObjMain.position, 100 * Time.deltaTime);

        puring = Input.GetMouseButton(1);
        var lookPos = transform.position - game.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        if (puring)
            rotation *= Quaternion.Euler(0, 0, -120);
        // game.rotation = rotation;
        game.transform.rotation = Quaternion.Slerp(game.transform.rotation, rotation, pureSpeed * Time.deltaTime);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (grabObjMain.localPosition.z <= maxForward)
                grabObjMain.localPosition = new Vector3(0, 0, grabObjMain.localPosition.z + MoveObjectspeed);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (grabObjMain.localPosition.z >= maxBackward)
                grabObjMain.localPosition = new Vector3(0, 0, grabObjMain.localPosition.z - MoveObjectspeed);
        }

        if (puring)
        {
            liquid.Emit(1);
        }
        else
        {
            liquid.Emit(0);
        }

        //check targetPlane
        if (Physics.Raycast(game.position, -game.up, out var hit, Mathf.Infinity,layerTarget))
        {
            //lookat
            var vec = game.position - TargetPlane.position;
            vec.y = 0;
            var rotatea = Quaternion.LookRotation(lookPos);
            TargetPlane.rotation = rotatea;
            //setlocation
            //TargetPlane.position=hit.point+Vector3.up*.01f;
            // TargetPlane.position=new Vector3(TargetPlane.right*-.2f,TargetPlane.localPosition.y,TargetPlane.localPosition.z);
            TargetPlane.position = hit.point + Vector3.up * .01f;
            var tg = -transform.right * .0f;
            TargetPlane.localPosition = TargetPlane.localPosition + tg;
        }

    }

    void CheckZoomCamera()
    {
        Camera.main.usePhysicalProperties = Input.GetKey(KeyCode.F);
        if (!Input.GetKey(KeyCode.F))
            Camera.main.fieldOfView = 60f;
    }

    void CheckCrouch()
    {
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        if (crouch)
            transform.GetComponent<CapsuleCollider>().height = originHeight / 3.5f;
        else
            transform.GetComponent<CapsuleCollider>().height = originHeight;

    }

}
