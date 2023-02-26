using UnityEngine;

public class SimpleAnimator : MonoBehaviour
{

    public int state;

    public Transform movingObject;
    [SerializeField] private float speed;

    public Vector3[] positions;


    private void Update()
    {
        AnimationMove();
    }

    private void AnimationMove()
    {
        var currentPos = movingObject.position;
        var targetPos = positions[state];

        var timeStep = Time.deltaTime * speed;

        movingObject.position = Vector3.Lerp(currentPos, targetPos,timeStep);
    }
    

}
