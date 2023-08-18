using System.Text.Json;

namespace Monopoly.Storage
{
    public class Stock
    {
        public string pathToSaveAndLoadBoxes;
        public string pathToSaveAndLoadPallets;
        public List<Box> boxes { get; set; }
        public List<Pallet> pallets { get; set; }

        public static Stock _context;

        private Stock()
        {
            boxes = new List<Box>();
            pallets = new List<Pallet>();
            pathToSaveAndLoadBoxes = @"../Boxes.txt";
            pathToSaveAndLoadPallets = @"../Pallets.txt";
        }

        public static Stock GetInstance()
        {
            if (_context == null)
            {
                _context = new Stock();
            }
            return _context;
        }

        public void SaveBoxes()
        {
            using (StreamWriter sw = new StreamWriter(pathToSaveAndLoadBoxes))
            {
                string jsn = JsonSerializer.Serialize(boxes);
                sw.WriteLine(jsn);
            }
        }

        public void SavePallets()
        {
            using (StreamWriter sw = new StreamWriter(pathToSaveAndLoadPallets))
            {
                string jsn = JsonSerializer.Serialize(pallets);
                sw.WriteLine(jsn);
            }
        }

        public void LoadBoxes()
        {
            if (File.Exists(pathToSaveAndLoadBoxes))
            {
                using (StreamReader sr = new StreamReader(pathToSaveAndLoadBoxes))
                {
                    string jsn = sr.ReadLine()!;
                    boxes = JsonSerializer.Deserialize<List<Box>>(jsn)!;
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }

        public void LoadPallets()
        {
            if (File.Exists(pathToSaveAndLoadPallets))
            {
                using (StreamReader sr = new StreamReader(pathToSaveAndLoadPallets))
                {
                    string jsn = sr.ReadLine()!;
                    pallets = JsonSerializer.Deserialize<List<Pallet>>(jsn)!;
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }

        public void AddBoxOnStock(Box box)
        {
            boxes.Add(box);
            SaveBoxes();
        }

        public void AddPalletOnStock(Pallet pallet)
        {
            pallets.Add(pallet);
            SavePallets();
        }

        public void ShowStockBalance()
        {
            foreach (Box box in boxes)
            {
                Console.WriteLine($@"{box.Id}");
            }

            foreach (Pallet pallet in pallets)
            {
                Console.WriteLine($@"Паллета с номером {pallet.Id} содержит следующий груз:");
                foreach (Box box in pallet.boxes)
                {
                    Console.Write($@"Id {box.Id}, ");
                }
                Console.WriteLine();
            }

        }
    }
}
