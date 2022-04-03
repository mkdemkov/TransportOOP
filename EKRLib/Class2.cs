using System;

namespace EKRLib
{
    /// <summary>
    /// Класс Car.
    /// </summary>
    public class Car : Transport
    {
        public Car(string model, uint power) : base(model, power)
        {
        }

        public override string ToString() => "Car. " + base.ToString();

        public override string StartEngine() => $"{Model}: Vroom";
    }

}
