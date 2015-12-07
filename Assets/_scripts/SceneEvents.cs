//using System;
//using UnityEngine;

//public static class SceneEvents {
//    public static event EventHandler<PlayerPositionActionArgs> UserAction;

//    public static void RaisePlayerPositionAction(object sender, PlayerPositionActionArgs e)
//    {
//        EventHandler<PlayerPositionActionArgs> handler = UserAction;
//        if (handler != null)
//        {
//            handler(sender, e);
//        }
//    }
//}

//public class PlayerPositionActionArgs : EventArgs
//{
//    public Vector3 position { get; set; }
//}
