using System;

namespace EKRLib
{
    /// <summary>
    /// Класс MotorBoat.
    /// </summary>
    public class MotorBoat : Transport
    {
        public MotorBoat(string model, uint power) : base(model, power)
        {
        }

        public override string ToString() => "MotorBoat. " + base.ToString();

        public override string StartEngine() => $"{Model}: Brrrbrr";
    }
}
