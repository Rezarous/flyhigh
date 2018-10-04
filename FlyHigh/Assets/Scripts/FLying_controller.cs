using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLying_controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject ball;

    float xValue = 0;
    float yValue = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        xValue = Input.mousePosition.x;
        if(xValue > 3 * Screen.width / 4){
            xValue = 3 * Screen.width / 4;
        }
        else if(xValue < Screen.width / 4){
            xValue = Screen.width / 4;
        }

        yValue = Input.mousePosition.y;
        if (yValue > 3 * Screen.height / 4)
        {
            yValue = 3 * Screen.height / 4;
        }
        else if (yValue < Screen.height / 4)
        {
            yValue = Screen.height / 4;
        }



        Vector3 ballPos = mainCamera.ScreenToWorldPoint(new Vector3(xValue, yValue, 20));
        ball.transform.position = ballPos;

        print(Input.mousePosition.x + " --- " + Input.mousePosition.y);

        Vector3 targetDir = ballPos - transform.position;

        // The step size is equal to speed times frame time.
        float step = 20 * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir*100, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);





        if (Input.GetKey("w") || Input.GetKey("up")){
            transform.Translate(transform.forward);
        }else if(Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.Translate(-transform.forward);
        }
	}

    private void LateUpdate()
    {
        //mainCamera.transform.position = transform.position + transform.forward * (-8) + transform.up * (6);
        //mainCamera.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(17f, 0, 0));
        //mainCamera.transform.LookAt(transform.position);
    }        

}
