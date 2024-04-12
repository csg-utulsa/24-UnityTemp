using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S;//Singleton
    [Header("Set in Inspector")]
    public float minDist = 0.1f;

    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Awake()
    {
        S = this; //set the singleton
        //get a refrence to the line renderer
        line = GetComponent<LineRenderer>();
        //disable the linerenderer until it's needed
        line.enabled = false;
        //initialize the points list
        points = new List<Vector3>();
    }
    //this is a property (that is, a method masquerading as a field)
    public GameObject poi
    {
        get
        {
            return (_poi);
        }
        set
        {
            _poi = value;
            if(_poi != null)
            {
                //when poi is set to something new it resets everything
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();

            }
        }
    }
    //this can be used to clear the line directly
    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        //this is called to add a point to the line
        Vector3 pt = _poi.transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {//if the point isnt far enough from the last point it returns
            return;

        }
        if (points.Count == 0)
        {// if this is the launchpoint
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;//to be defined
            //it adds an extra bit of line to aid aiming later
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            //sets the first two points

            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            //enables line renderer
            line.enabled = true;
            /////HERE

        }

        else
        {
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }

    }
    public Vector3 lastPoint
    {
        get
        {
            if(points == null)
            {
                //if there are no points, returns Vector3.zero
                return (Vector3.zero);
            }
            return (points[points.Count - 1]);
        }
    }
     void FixedUpdate()
    {
        if (poi == null)
        {
            //if there is no poi, search for one
            if(FollowCam.POI != null)
            {
                if(FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return;//return if we didn't find a poi
                }
            }
            else
            {
                return; //return if we didn't find a poi
            }
        }
        //if there is a poi it's loc is added every FixedUpdate
        AddPoint();
        if( FollowCam.POI == null)
        {
            //once followcam.poi is null make the local poi null too
            poi = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


/*[RequireComponent(typeof(LineRenderer))]
public class ProjectileLine : MonoBehaviour
{

private LineRenderer _line;
// a






// b



// c





// d

}
void FixedUpdate()
{
    if (_drawing)
    {
        _line.positionCount++;
        _line.SetPosition(_line.positionCount - 1,
        transform.position);

// If the Projectile Rigidbody is sleeping, stop drawing

// e








    if (_projectile != null)
        {
            if (!_projectile.awake)
            {
                _drawing = false;
                _projectile = null;
            }
        }
    }
}
private bool
private Projectile
void Start()
{
    _line = GetComponent<LineRenderer>();
    _line.positionCount = 1;
    _line.SetPosition(0, transform.position);
    _projectile = GetComponentInParent<Projectile>();
    _drawing = true;
    _projectile;
}
*/
