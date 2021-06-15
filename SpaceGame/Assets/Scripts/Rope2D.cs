using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope2D : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public List<RopeSegment> ropeSegments = new List<RopeSegment>();
    public float ropeSegLen = 0.25f;
    public int segmentLength = 35;
    public float lineWidth = 0.1f;
    public Transform startPoint;
    public Transform endPoint;
    public float colliderWidth = 0.1f;
    public PolygonCollider2D polygonCollider;

    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = startPoint.position;

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.SetCollider();
        this.DrawRope();       
    }

    private void SetCollider()
    {
        // get array of all rope points
        Vector3[] ropePoints = new Vector3[segmentLength];
        Vector2[] ropePointsV2 = new Vector2[segmentLength];
        lineRenderer.GetPositions(ropePoints);

        // convert to vector2 array
        for(int i = 0; i < segmentLength; i++)
        {
            ropePointsV2[i] = (Vector2) ropePoints[i];
        }

        // set up polygon collider
        Vector2[] colliderPoints = new Vector2[segmentLength*2];
        polygonCollider.pathCount = 1;

        // set left hand path
        for(int i = 0; i < segmentLength; i++)
        {
            colliderPoints[i] = ropePointsV2[i] - new Vector2(colliderWidth,0);
        }

        // set right hand path
        for(int i = 0; i < segmentLength; i++)
        {
            colliderPoints[segmentLength + i] = ropePointsV2[segmentLength-1-i] + new Vector2(colliderWidth,0);
        }
        polygonCollider.SetPath(0,colliderPoints);
    }

    private void FixedUpdate()
    {
        this.Simulate();
    }

    public void Simulate()
    {
        // SIMULATION
        Vector2 forceGravity = new Vector2(0f, -1.5f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            // firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
        }

        //CONSTRAINTS
        for (int i = 0; i < 100; i++)
        {
            this.ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.startPoint.position;
        this.ropeSegments[0] = firstSegment;

        RopeSegment endSegment = this.ropeSegments[this.segmentLength - 1];
        endSegment.posNow = this.endPoint.position;
        this.ropeSegments[this.segmentLength - 1] = endSegment;

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector2 changeDir = Vector2.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;

            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    public void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }
}