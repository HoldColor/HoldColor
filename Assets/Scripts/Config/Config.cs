using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoldColor.Config {
    static class GameConfig {
        public static int _ScreenWidth = 1024;
        public static int _ScreenHeight = 768;
        public static bool _FullScreen = false;
        
    }
    static class CampDefine
    {
        public static Color Orange = new Color(255f / 255f, 183f / 255f, 77f / 255f);
        public static Color Blue = new Color(79f / 255f, 195f / 255f, 247f / 255f);
        public static Color Green = new Color(129f / 255f, 199f / 255f, 132f / 255f);
        public static Color Purple = new Color(149f / 255f, 177f / 255f, 205f / 255f);
        public static Color Campless = new Color(117f / 255f, 117f / 255f, 117f / 255f);
    }
    static class CameraConfig {
        public static float _MoveSpeed = 5.0f;
    }
    static class PlayerConfig
    {
        public static float _MoveSpeed = 3.0f;
        public static float _FiringRate = 1.0f;
        public static int _Damage = 50;
        public static float _BulletSpeed = 5.0f;
        public static float _InteractAreaRadius = 5.0f;
        public static int _TotalHealth = 300;
        public static int _TotalEnergy = 100;
    }

    static class HingeConfig
    {
        public static int _AddResourceByCycle = 4;
        public static float _AddResourceCycle = 2.0f;
        public static int _AddHealthBySecond = 10;
        public static float _InteractAreaRadius = 10.0f;
        public static int _TotalHealth = 3000;
        public static int _TotalEnergy = 1000;
    }

    static class ReserveConfig
    {
        public static int _AddEnergyByCycle = 10;
        public static float _AddEnergyCycle = 1.0f;
        public static float _InteractAreaRadius = 5.0f;
        public static int _TotalHealth = 500;
        public static int _TotalEnergy = 1000;
        public static float _BuildingTime = 10.0f;
    }

    static class TurretConfig
    {
        public static float _FiringRate = 1.5f;
        public static int _Damage = 100;
        public static float _BulletSpeed = 4.0f;
        public static int _TotalHealth = 1000;
        public static int _TotalEnergy = 1000;
        public static float _InteractAreaRadius = 3f;
        public static float _BuildingTime = 30.0f;
    }

    static class SFConfig
    {
        public static int _TotalValue = 200;
        public static int _OccupyPointBySecond = 10;
        public static float _InteractAreaRadius = 5.0f;
    }

    static class ShieldSF
    {
        public static int _TotalShield = 200;
        public static int _RestoreShieldBySecond = 10;
    }

    static class ResourceSF
    {
        public static int _AddResourceByCycle = 2;
        public static float _AddResourceCycle = 1.0f;
    }

    static class AttackSF
    {
        public static int _ImproveDamage = 2;
        public static float _ImproveInteractRadius = 0.2f;
    }

    static class Field
    {
        public static float _HalfLength = 6.0f;
        public static int _TotalHealth = 500;
        public static int _TotalEnergy = 500;
        public static float _BuildingTime = 3.0f;
    }

    static class UI
    {
        public static Color _BuildingDiasbled = new Color(229f / 255f, 57f / 255f, 53f / 255f, 200f / 255f);
        public static Color _BuildingAbled = new Color(104 / 255f, 159 / 255f, 56 / 255f, 200 / 255f);
    }
}
