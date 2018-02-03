using System.Collections;
using System.Collections.Generic;
namespace HoldColor.Config {
    static class GameConfig {
        public static int _ScreenWidth = 1920;
        public static int _ScreenHeight = 1080;
        public static bool _FullScreen = false;
    }
    static class CameraConfig {
        public static float _MoveSpeed = 0.05f;
    }
    static class PlayerConfig
    {
        public static float _MoveSpeed = 0.5f;
        public static float _InteractRadius = 10f;
    }
}
