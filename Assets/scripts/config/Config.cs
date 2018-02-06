using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoldColor.Config {
    static class GameConfig {
        public static int _ScreenWidth = 1920;
        public static int _ScreenHeight = 1080;
        public static bool _FullScreen = false;
        
    }
    static class CampDefine
    {
        public static Color Orange = new Color(255f / 255f, 183f / 255f, 77f / 255f);
        public static Color Blue = new Color(79f / 255f, 195f / 255f, 247f / 255f);
        public static Color Green = new Color(129f / 255f, 199f / 255f, 132f / 255f);
        public static Color Purple = new Color(149f / 255f, 177f / 255f, 205f / 255f);
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
