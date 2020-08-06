using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
/* 
    [System.Serializable]
    public class SwapFunction {
        public int actionIndex;

        public Action[] actions;
    } */

    public class SwapActionMono : MonoBehaviour {

        
        public List<SwapActionSO> swapActions;
        

        public void SwapActionAtIndex(int swapActionIndex) {
            StateController controller = GetComponent<StateController>();
            State state = controller.currentState;

            int actionIndex = swapActions[swapActionIndex].actionToSwap;
            Action act = swapActions[swapActionIndex].actionToSwapTo;

            state.actions[actionIndex] = act;
        }
    }
}