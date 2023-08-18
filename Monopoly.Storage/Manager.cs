namespace Monopoly.Storage
{
    public class Manager
    {
        public Stock stock;

        public Manager()
        {
            stock = Stock.GetInstance();
        }

        public void AddBoxOnPallet(Box box, Pallet pallet)
        {
            if (CheckingSpaceOnAPallet(pallet, box) == true)
            {
                pallet.boxes.Add(box);
                stock.boxes.Remove(box);
                stock.SaveBoxes();
            }
            else
            {
                Console.WriteLine("Размер данной коробки превышает размер паллеты");
            }
        }

        public void RemoveBoxFromPallet(Box box, Pallet pallet)
        {
            pallet.boxes.Remove(box);
            stock.boxes.Add(box);
            stock.SaveBoxes();
        }

        public void GroupPalletsByExpirationDate()
        {
            var groupPallets = stock.pallets.GroupBy(ed => ed.ExpirationDate);

            foreach (var group in groupPallets)
            {
                var sortedPallets = group.OrderBy(w => w.Weight).ToList();

                Console.WriteLine($"Группа сроком годности {group.Key}");
                foreach (var pallet in sortedPallets)
                {
                    Console.WriteLine($"Паллета №{pallet.Id} и весом {pallet.Weight}");
                }
                Console.WriteLine();
            }
        }

        public void GetPalletsWithTheLongestShelfLife()
        {
            var palletsWithLatestExpirationDate = stock.pallets.OrderByDescending(b => b.boxes.Max(ed => ed.ExpirationDate))
                                          .Take(3)
                                          .OrderBy(v => v.Volume);

            foreach (var pallet in palletsWithLatestExpirationDate)
            {
                Console.WriteLine($"Паллет №{pallet.Id}, объем {pallet.Volume}м^3");
            }
        }

        public bool CheckingSpaceOnAPallet(Pallet pallet, Box box)
        {
            if (pallet.Depth * pallet.Width > box.Depth * box.Width)
            {
                return true;
            }
            else return false;
        }
    }
}
