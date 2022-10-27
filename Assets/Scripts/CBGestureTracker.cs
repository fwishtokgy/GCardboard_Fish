using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBGestureTracker : MonoBehaviour {

    public Transform pivotPoint;
    public Vector3 cross;
    public Vector3 mcross;
    public float dot;

    enum Gestate { Straight, Wiggle, smLeft, smRight, Left, Right, CW, CCW }
    Gestate state = Gestate.Straight;
    public Vector3 lastRotation;

    gestureInfoBit[] data;
    int ptr;
    int max;
    float checkInterval;
    float checkCtr;

	// Use this for initialization
	void Start () {
        lastRotation = this.transform.forward;
        if (checkInterval<=0)
        {
            checkInterval = 1.0f;
        }
        if (max<=0)
        {
            max = 10;
        }
        data = new gestureInfoBit[max];
        ptr = 0;
	}
	
	// Update is called once per frame
	void Update () {
        checkCtr += Time.deltaTime;
        if (this.transform.hasChanged || checkCtr>=checkInterval)
        {
            cross = Vector3.Cross(this.transform.forward, lastRotation);
            calcMCross();
            dot = Vector3.Dot(this.transform.forward, lastRotation);

            checkCtr = 0f;
            
            if (dot<1f)
            {
                if (mcross[1]>mcross[2] && mcross[1]>mcross[0] )
                {
                    if (cross[1] > 0f)
                    {
                        Debug.Log("Turning Left");
                    } else
                    {
                        Debug.Log("Turning Right");
                    }
                }
                else if (mcross[0]>mcross[1] && mcross[0]>mcross[2])
                {
                    if (cross[0]>0f)
                    {
                        Debug.Log("Nose Up");
                    }
                    else
                    {
                        Debug.Log("Nose Down");
                    }
                }
            }
        }
        lastRotation = this.transform.forward;
    }
    void calcMCross()
    {
        mcross = new Vector3(Mathf.Abs(cross.x), Mathf.Abs(cross.y), Mathf.Abs(cross.z));
    }

    void insertNote()
    {

    }
}
