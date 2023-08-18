namespace Monopoly.Storage
{
    public class Box : AbstractContainer
    {
        public int Id { get; set; }
        public DateOnly ExpirationDate { get; private set; }


        public Box(int id, double width, double height, double depth, double weight)
        {
            Id = id;
            ExpirationDate = DateOnly.FromDateTime(DateTime.Today).AddDays(Options.defaultExpirationDate);
            Volume = width * height * depth;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
        }

        //Для генерации разных дней создания
        public Box(int id, double width, double height, double depth, double weightBox, DateOnly _dateOfManufacture)
        {
            Id = id;
            Volume = width * height * depth;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weightBox;
            ExpirationDate = _dateOfManufacture.AddDays(Options.defaultExpirationDate);

        }

        public override bool Equals(object? obj)
        {
            return obj is Box box &&
                   Id == box.Id &&
                   Width == box.Width &&
                   Height == box.Height &&
                   Depth == box.Depth &&
                   Weight == box.Weight &&
                   Volume == box.Volume &&
                   ExpirationDate.Equals(box.ExpirationDate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Width, Height, Depth, Weight, Volume, ExpirationDate);
        }
    }
}
