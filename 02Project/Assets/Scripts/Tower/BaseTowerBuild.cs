using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tower
{
    public class BaseTowerBuild 
    {
        public TurretType TurretType { get; set; }
        public int TurretLevel { get; set; }
        public Transform TransformTurret { get; set; }
        public Transform TransformBase { get; set; }
    }
    public enum TurretType
    {
        Red,
        Green,
        Blu
    }
}
