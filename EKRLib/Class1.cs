using System;
using System.Linq;

namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс Transport. 
    /// </summary>
    public abstract class Transport
    {
        private string _model;
        private uint _power;

        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Свойство, отвечающее за модель транспортного средства. 
        /// </summary>
        public string Model
        {
            get => _model;

            set
            {
                if (!CorrectModel(value))
                    throw new TransportException($"Недопустимая модель {value}");
                _model = value;
            }
        }

        /// <summary>
        /// Метод, проверяющий корректность модели транспортного средства.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static bool CorrectModel(string model)
        {
            if (model.Length != 5)
                return false;
            foreach (var ch in model)
            {
                if (ch >= 'A' && ch <= 'Z' || Char.IsDigit(ch))
                    continue;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Свойство, отвечающее за мощность транспортного средства.
        /// </summary>
        public uint Power
        {
            get => _power;

            set
            {
                if (value < 20)
                    throw new TransportException("мощность не может быть меньше 20 л.с.");
                _power = value;
            }
        }

        /// <summary>
        /// Переопределённый метод ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Model: {_model}, Power: {_power}";

        /// <summary>
        /// Абстрактный метод StartEngine. Переопределен в производных классах.
        /// </summary>
        /// <returns></returns>
        public abstract string StartEngine();

        /// <summary>
        /// Метод, генерирующий рандомную модель транспортного средства с использованием LINQ.
        /// </summary>
        /// <returns></returns>
        public static string GetRandomModel()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIGKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
