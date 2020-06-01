using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
    public class SwapActionMono : MonoBehaviour {
        
        public int actionIndex;

        public Action[] actions;

        public void SwapActionAtIndex(int index) {
            StateController controller = GetComponent<StateController>();
            State state = controller.currentState;
            state.actions[actionIndex] = actions[index];
        }
    }
}