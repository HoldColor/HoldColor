using System.Collections;
using System.Collections.Generic;

public class MessageBox {

    public class MessageBase
    {
        public string Type;
        public string Message;
    }

    public class InitializeMessage
    {
        public string id;
        public string Camp;
        public string PlayerID;
        public string PlayerPosition;
        public string HingeID;
        public string HingePosition;
    }

    public class OtherInitializeMessage
    {
        public string Camp;
        public string PlayerID;
        public string PlayerPosition;
        public string HingeID;
        public string HingePosition;
    }

    public class Position
    {
        public float x;
        public float y;
    }
    
    public class PlayerPosition
    {
        public string id;
        public float x;
        public float y;
    }

    public class BulletMessage
    {
        public string Camp;
        public string StartPosition;
        public string TargetID;
    }

    public class SendBulletMessage
    {
        public string ShooterID;
        public string StartPosition;
        public string TargetID;
    }

    public class ChangeStateBar
    {
        public string id;
        public float Health;
        public float Energy;
        public float Shield;
    }

    public class BuildMessage
    {
        public string Type;
        public string id;
        public string Position;
        public string Camp;
    }

}
