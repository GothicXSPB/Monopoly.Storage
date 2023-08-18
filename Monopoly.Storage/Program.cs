using Monopoly.Storage;

internal class Program
{
    private static void Main(string[] args)
    {
        Manager manager = new Manager();
        AutoFeel(manager);

        Console.WriteLine("На данный момент ситуация на складе следующая");
        manager.stock.ShowStockBalance();

        Console.WriteLine("Введите 1 для создания коробки");
        Console.WriteLine("Введите 2 для создания паллеты");
        Console.WriteLine("Введите 3 для добавления коробки на паллету");
        Console.WriteLine("Введите 4 для группировки паллет по сроку годности");
        Console.WriteLine("Введите 5 для получениях 3 паллет с наибольшим сроком годности");
        Console.WriteLine("Введите 0 чтобы выйти");
        int RequestMenu = Convert.ToInt32(Console.ReadLine());

        if (RequestMenu != 0)
            switch (RequestMenu)
            {
                case 1:
                    Console.WriteLine("Введите номер коробки");
                    int idBox = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите ширину коробки");
                    int width = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите высоту коробки");
                    int height = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите глубину коробки");
                    int depth = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите вес коробки");
                    int weight = Convert.ToInt32(Console.ReadLine());
                    Box box = new Box(idBox, width, height, depth, weight);
                    manager.stock.AddBoxOnStock(box);
                    Console.WriteLine($"Коробка номер {box.Id} создана");
                    break;

                case 2:
                    Console.WriteLine("Введите номер паллеты");
                    int idPallet = Convert.ToInt32(Console.ReadLine());
                    Pallet pallet = new Pallet(idPallet);
                    manager.stock.AddPalletOnStock(pallet);
                    Console.WriteLine($"Коробка номер {pallet.Id} создана");
                    break;

                case 3:
                    Console.WriteLine("Введите номер коробки которую вы будете добавлять");
                    int actualIdBox = Convert.ToInt32(Console.ReadLine());
                    Box ActualBox = manager.stock.boxes.Find(x => x.Id == actualIdBox);
                    Console.WriteLine("Введите номер паллеты на которую вы будете добавлять коробку");
                    int actualIdPallet = Convert.ToInt32(Console.ReadLine());
                    Pallet ActualPallet = manager.stock.pallets.Find(x => x.Id == actualIdPallet);
                    manager.AddBoxOnPallet(ActualBox, ActualPallet);
                    Console.WriteLine("Выполнено");
                    break;

                case 4:
                    manager.GroupPalletsByExpirationDate();
                    break;

                case 5:
                    manager.GetPalletsWithTheLongestShelfLife();
                    break;

                default:
                    Console.WriteLine("Не получилось, попробуйте ещё раз");
                    break;
            }

        void AutoFeel(Manager manager)
        {
            DateOnly date = new DateOnly(2023, 1, 7);
            DateOnly date1 = new DateOnly(2023, 2, 6);
            DateOnly date2 = new DateOnly(2023, 3, 8);
            DateOnly date3 = new DateOnly(2023, 4, 5);

            Box box = new Box(0, 10, 15, 10, 2, date);
            Box box1 = new Box(1, 10, 19, 10, 3, date);
            Box box2 = new Box(2, 10, 10, 10, 2, date);
            Box box3 = new Box(3, 10, 11, 10, 3, date1);
            Box box4 = new Box(4, 10, 10, 10, 3, date1);
            Box box5 = new Box(5, 12, 10, 12, 2, date1);
            Box box6 = new Box(6, 10, 10, 10, 5, date2);
            Box box7 = new Box(7, 10, 15, 14, 5, date2);
            Box box8 = new Box(8, 10, 10, 10, 3, date2);
            Box box9 = new Box(9, 10, 10, 10, 3, date3);
            Box box10 = new Box(11, 10, 10, 13, 5, date1);
            Box box11 = new Box(12, 1, 10, 10, 3, date3);

            Pallet pallet = new Pallet(1);
            Pallet pallet1 = new Pallet(2);
            Pallet pallet2 = new Pallet(3);
            Pallet pallet3 = new Pallet(4);
            Pallet pallet4 = new Pallet(5);
            Pallet pallet5 = new Pallet(6);

            manager.stock.AddBoxOnStock(box);
            manager.stock.AddBoxOnStock(box1);
            manager.stock.AddBoxOnStock(box2);
            manager.stock.AddBoxOnStock(box3);
            manager.stock.AddBoxOnStock(box4);
            manager.stock.AddBoxOnStock(box5);
            manager.stock.AddBoxOnStock(box6);
            manager.stock.AddBoxOnStock(box7);
            manager.stock.AddBoxOnStock(box8);
            manager.stock.AddBoxOnStock(box9);
            manager.stock.AddBoxOnStock(box10);
            manager.stock.AddBoxOnStock(box11);

            manager.stock.AddPalletOnStock(pallet);
            manager.stock.AddPalletOnStock(pallet1);
            manager.stock.AddPalletOnStock(pallet2);
            manager.stock.AddPalletOnStock(pallet3);
            manager.stock.AddPalletOnStock(pallet4);
            manager.stock.AddPalletOnStock(pallet5);

            manager.AddBoxOnPallet(box, pallet);
            manager.AddBoxOnPallet(box1, pallet2);
            manager.AddBoxOnPallet(box2, pallet);
            manager.AddBoxOnPallet(box3, pallet1);
            manager.AddBoxOnPallet(box4, pallet2);
            manager.AddBoxOnPallet(box5, pallet1);
            manager.AddBoxOnPallet(box6, pallet4);
            manager.AddBoxOnPallet(box6, pallet);
            manager.AddBoxOnPallet(box7, pallet3);
            manager.AddBoxOnPallet(box8, pallet4);
            manager.AddBoxOnPallet(box9, pallet3);
            manager.AddBoxOnPallet(box10, pallet);
            manager.AddBoxOnPallet(box11, pallet5);
        }
    }
}