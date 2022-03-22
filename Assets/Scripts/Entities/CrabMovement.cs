using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CastleCrabers.ScriptableObjects;


namespace CastleCrabers.Entities {

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CrabMovement : MonoBehaviour
    {
        private const string MOVING_ANIMATION = "isMoving";

        [SerializeField]
        private Animator characterAnimator;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private CrabStats stats;

        private Vector2 targetDestination = Vector2.zero;
        private bool hasADestination = false;

        private void SetDestination(Vector2 newDestination) {
            targetDestination = newDestination;
            hasADestination = true;
            characterAnimator.SetBool(MOVING_ANIMATION, true);
        }

        private void UnsetDestination() {
            hasADestination = false;
            characterAnimator.SetBool(MOVING_ANIMATION, false);
        }
        
        public void Update() {
            if (hasADestination)  {
                float moveAmount = stats.speed * Time.deltaTime;
                Vector2 destinationVector = targetDestination - (Vector2)transform.position;
                Vector2 movementVector = destinationVector.normalized * moveAmount;
                transform.Translate(movementVector);
                if ((targetDestination - (Vector2)transform.position).magnitude < moveAmount) {
                    UnsetDestination();
                }
            }
        }

        public void OnMove() {
            SetDestination(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        }
    }
}
