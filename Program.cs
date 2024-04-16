using System.Security.AccessControl;

class EngMoney
{
    readonly double pound;
    readonly double shilling;
    readonly double penny;

    public EngMoney(double pound, double shilling, double penny)
    {
        this.pound = pound;
        this.shilling = shilling;
        this.penny = penny;
    }


    public static EngMoney operator + (EngMoney money1, EngMoney money2)
    {
        double TotalPence1 = money1.pound * 240 + money1.shilling * 12 + money1.penny;
        double TotalPence2 = money2.pound * 240 + money2.shilling * 12 + money2.penny;

        double TotalPence = TotalPence1 + TotalPence2;

        double pound = TotalPence / 240;
        double shilling = (TotalPence % 240) / 12;
        double penny = TotalPence % 12;

        return new EngMoney(pound, shilling, penny);
    }

    public static EngMoney operator - (EngMoney money1, EngMoney money2)
    {
        double TotalPence1 = money1.pound * 240 + money1.shilling * 12 + money1.penny;
        double TotalPence2 = money2.pound * 240 + money2.shilling * 12 + money2.penny;

        double TotalPence = TotalPence1 - TotalPence2;

        if (TotalPence < 0)
        {
            throw new InvalidOperationException("Что-то пошло не так :(");
        }

        double pound = TotalPence / 240;
        double shilling = (TotalPence % 240) / 12;
        double penny = TotalPence % 12;

        return new EngMoney(pound, shilling, penny);
    }

    public static EngMoney operator * (EngMoney money1, EngMoney money2)
    {
        double TotalPence1 = money1.pound * 240 + money1.shilling * 12 + money1.penny;
        double TotalPence2 = money2.pound * 240 + money2.shilling * 12 + money2.penny;

        double TotalPence = TotalPence1 * TotalPence2;

        double pound = TotalPence / 240;
        double shilling = (TotalPence % 240) / 12;
        double penny = TotalPence % 12;

        return new EngMoney(pound, shilling, penny);
    }

    public static EngMoney operator / (EngMoney money1, EngMoney money2)
    {
        double TotalPence1 = money1.pound * 240 + money1.shilling * 12 + money1.penny;
        double TotalPence2 = money2.pound * 240 + money2.shilling * 12 + money2.penny;

        if (TotalPence2 == 0)
        {
            throw new InvalidOperationException("Что-то пошло не так :(");
        }

        double TotalPence = TotalPence1 / TotalPence2;

        double pound = TotalPence / 240;
        double shilling = (TotalPence % 240) / 12;
        double penny = TotalPence % 12;

        return new EngMoney(pound, shilling, penny);
    }

    public int CompareTo(EngMoney other)
    {
        double TotalPence1 = this.TotalPence();
        double TotalPence2 = other.TotalPence();

        return TotalPence1.CompareTo(TotalPence2);
    }
    private double TotalPence()
    {
        return this.pound * 240 + this.shilling * 12 + this.penny;
    }
    public void DisplayMoney()
    {
        Console.WriteLine($"{this.pound} фунтов, {this.shilling} шиллингов, {this.penny} пенсов");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите первые значения (фунты, шиллинги, пенсы):");
            double pound1 = double.Parse(Console.ReadLine());
            double shilling1 = double.Parse(Console.ReadLine());
            double penny1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите вторые значения (фунты, шиллинги, пенсы):");
            double pound2 = double.Parse(Console.ReadLine());
            double shilling2 = double.Parse(Console.ReadLine());
            double penny2 = double.Parse(Console.ReadLine());

            EngMoney money1 = new EngMoney(pound1, shilling1, penny1);
            EngMoney money2 = new EngMoney(pound2, shilling2, penny2);

            EngMoney addition = money1 + money2;
            Console.Write("Сумма значений: ");
            addition.DisplayMoney();

            EngMoney difference = money1 - money2;
            Console.Write("Разность значений: ");
            difference.DisplayMoney();

            EngMoney multiplication = money1 * money2;
            Console.Write("Произведение значений: ");
            multiplication.DisplayMoney();

            EngMoney division = money1 / money2;
            Console.Write("Частное значений: ");
            division.DisplayMoney();

            double comparison = money1.CompareTo(money2);

            if (comparison > 0)
            {
                Console.WriteLine("Первое значение больше второго");
            }
            else if (comparison < 0)
            {
                Console.WriteLine("Первое значение меньше второго");
            }
            else
            {
                Console.WriteLine("Значения равны");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Что-то пошло не так :(");
        }
    }   
}