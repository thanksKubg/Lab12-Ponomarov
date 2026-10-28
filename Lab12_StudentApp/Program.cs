namespace Lab12_StudentApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Лабораторна робота №12 (Композиція: виклик методів внутрішніх об'єктів) ---\n");

            // TODO: Завдання 8. Один день з життя автомобіля.
            // Користуйтеся методами Car (TryStartEngine, Drive, ...), а не car.CarEngine.Start() тощо.

            // Крок 1. Створіть автомобіль. Виведіть, скільки шин спущено (CountFlatWheels)
            //         і чи готове авто до поїздки (IsReadyToDrive).
            Car car = new Car("Toyota Camry");
            Console.WriteLine("Авто: " + car.Model);
            Console.WriteLine("Спущених шин: " + car.CountFlatWheels());
            Console.WriteLine("Готове до поїздки: " + car.IsReadyToDrive());

            // Крок 2. Спробуйте завести двигун, поки водія немає (виведіть результат TryStartEngine).
            //         Створіть водія, посадіть його в авто й заведіть двигун ще раз.
            Console.WriteLine("Завести без водія: " + car.TryStartEngine());
            Driver driver = new Driver("Олег", 5);
            car.CarDriver = driver;
            Console.WriteLine("Завести з водієм: " + car.TryStartEngine());
            Console.WriteLine("Двигун працює: " + car.IsEngineRunning);

            // Крок 3. Проїдьте 100 км. Виведіть результат Drive і показання одометра (Mileage).
            Console.WriteLine("Проїхали: " + car.Drive(100) + " км");
            Console.WriteLine("Одометр: " + car.Mileage + " км");

            // Крок 4. Прокол: car.Wheels[2].Puncture();
            //         Виведіть кількість спущених шин, IsReadyToDrive і результат спроби проїхати 10 км.
            car.Wheels[2].Puncture();
            Console.WriteLine("Прокол! Спущених шин: " + car.CountFlatWheels());
            Console.WriteLine("Готове до поїздки: " + car.IsReadyToDrive());
            Console.WriteLine("Спроба проїхати 10 км: " + car.Drive(10) + " км");

            // Крок 5. Ремонт: замініть колесо (ReplaceWheel) на нове Wheel(16).
            //         Виведіть, чи було зняте колесо спущеним, і чи знову готове авто до поїздки.
            //         Проїдьте ще 50 км і виведіть Mileage.
            Wheel? old = car.ReplaceWheel(2, new Wheel(16));
            if (old != null)
            {
                Console.WriteLine("Зняте колесо спущене: " + old.IsFlat);
            }
            Console.WriteLine("Готове до поїздки: " + car.IsReadyToDrive());
            Console.WriteLine("Проїхали: " + car.Drive(50) + " км");
            Console.WriteLine("Одометр: " + car.Mileage + " км");

            // Крок 6. Передбач і спостерігай (див. методичку, Завдання 8):
            //   а) приберіть водія (RemoveDriver) і викличте метод водія через car.CarDriver без перевірки на null:
            //      Console.WriteLine(car.CarDriver.Introduce());
            //      запишіть прогноз, запустіть, зафіксуйте виняток;
            //   б) обгорніть у try / catch (NullReferenceException) і виведіть ex.GetType().Name;
            //   в) виведіть безпечну версію з ?. та ??, щоб без водія виводилося "Водія немає".
            car.RemoveDriver();
            try
            {
                Console.WriteLine(car.CarDriver.Introduce());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Виняток: " + ex.GetType().Name);
            }
            Console.WriteLine(car.CarDriver?.Introduce() ?? "Водія немає");

            Console.WriteLine("\nЯкщо все працює без помилок — завантажуйте файли на GitHub!");
            Console.ReadLine();
        }
    }
}
