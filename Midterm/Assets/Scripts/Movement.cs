using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; //import the pathfinding library 


public class Movement : MonoBehaviour
{
    //[SerializeField] float speed = 5f;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform playerTransform;
    private Vector3 playerPosition;
    Rigidbody2D rb;

    [Header("Navigator options")]
    [SerializeField] float gridSize = 0.5f; //increase patience or gridSize for larger maps
    [SerializeField] float speed = 0.05f; //increase for faster movement
    
    Pathfinder<Vector2> pathfinder; //the pathfinder object that stores the methods and patience

    [Tooltip("The layers that the navigator can not pass through.")]
    [SerializeField] LayerMask obstacles;
    [Tooltip("Deactivate to make the navigator move along the grid only, except at the end when it reaches to the target point. This shortens the path but costs extra Physics2D.LineCast")] 
    [SerializeField] bool searchShortcut =false; 
    [Tooltip("Deactivate to make the navigator to stop at the nearest point on the grid.")]
    [SerializeField] bool snapToGrid =false; 
    Vector2 targetNode; //target in 2D space
    List <Vector2> path;
    List<Vector2> pathLeftToGo= new List<Vector2>();
    [SerializeField] bool drawDebugLines;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        playerTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = new Pathfinder<Vector2>(GetDistance,GetNeighbourNodes,1000); //increase patience or gridSize for larger maps

        // Get the player character's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
    }

    public void moveTransform(Vector3 vel){
        transform.position += vel * Time.deltaTime; 
    }

    // This is the player character movement code
    public void moveRobot(Vector3 vel){ 
        rb.velocity = vel * speed;
        if(vel.magnitude > 0){
            animationStateChanger.ChangeAnimationState("Walk");
        }else{
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }

    // Test and delete -- Probably old code for bullets / enemies
    public void moveRB(Vector3 vel){
        rb.velocity = vel * speed;
    }

    // Move and face target WITHOUT pathfinding
    public void MoveToward2(Vector3 target){
        // Look at target
        Quaternion lookRotation = Quaternion.LookRotation(transform.forward, target - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 20);

        // Move to target
        Vector3 direction = (target - transform.position).normalized;
        Vector3 newPosition = playerTransform.position + direction * Time.deltaTime * speed;
        playerTransform.position = newPosition;
    }


    // Move Toward Target WITH Pathfinding
    public void MoveToward(Vector3 target){
        // Look at target
        Quaternion lookRotation = Quaternion.LookRotation(transform.forward, target - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 20);

        // Move to target
        GetMoveCommand(target);        

        if (pathLeftToGo.Count > 0) //if the target is not yet reached
        {
            Vector3 dir =  (Vector3)pathLeftToGo[0]-transform.position ;
            transform.position += dir.normalized * Time.deltaTime * speed;
            if (((Vector2)transform.position - pathLeftToGo[0]).sqrMagnitude <speed*speed*Time.deltaTime) 
            {
                transform.position = pathLeftToGo[0];
                pathLeftToGo.RemoveAt(0);
            }
        }

        if (drawDebugLines)
        {
            for (int i=0;i<pathLeftToGo.Count-1;i++) //visualize your path in the sceneview
            {
                Debug.DrawLine(pathLeftToGo[i], pathLeftToGo[i+1]);
            }
        }
    }

    void GetMoveCommand(Vector2 target)
    {
        Vector2 closestNode = GetClosestNode(transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path)) //Generate path between two points on grid that are close to the transform position and the assigned target.
        {
            if (searchShortcut && path.Count>0)
                pathLeftToGo = ShortenPath(path);
            else
            {
                pathLeftToGo = new List<Vector2>(path);
                if (!snapToGrid) pathLeftToGo.Add(target);
            }

        }
        
    }

    /// <summary>
    /// Finds closest point on the grid
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    Vector2 GetClosestNode(Vector2 target) 
    {
        return new Vector2(Mathf.Round(target.x/gridSize)*gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }

    /// <summary>
    /// A distance approximation. 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    float GetDistance(Vector2 A, Vector2 B) 
    {
        return (A - B).sqrMagnitude; //Uses square magnitude to lessen the CPU time.
    }

    /// <summary>
    /// Finds possible conenctions and the distances to those connections on the grid.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    Dictionary<Vector2,float> GetNeighbourNodes(Vector2 pos) 
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        for (int i=-1;i<2;i++)
        {
            for (int j=-1;j<2;j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j)*gridSize;
                if (!Physics2D.Linecast(pos,pos+dir, obstacles))
                {
                    neighbours.Add(GetClosestNode( pos + dir), dir.magnitude);
                }
            }

        }
        return neighbours;
    }

    
    List<Vector2> ShortenPath(List<Vector2> path)
    {
        List<Vector2> newPath = new List<Vector2>();
        
        for (int i=0;i<path.Count;i++)
        {
            newPath.Add(path[i]);
            for (int j=path.Count-1;j>i;j-- )
            {
                if (!Physics2D.Linecast(path[i],path[j], obstacles))
                {
                    
                    i = j;
                    break;
                }
            }
            newPath.Add(path[i]);
        }
        newPath.Add(path[path.Count - 1]);
        return newPath;
    }

}
