using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEventsFramework {
   [CreateAssetMenu(menuName="Unity Events Framework/UI/Swap Action Sctipable Object")]
   public class SwapActionSO : ScriptableObject {
   
      public int actionToSwap;

      public Action actionToSwapTo;
      
   }
}
