namespace Monopoly.Storage
{
    public class Pallet : AbstractContainer
    {
        public int Id { get; set; }
        public override double Volume { get => Options.standardVolumePallet + boxes.Sum(box => box.Volume); set => base.Volume = value; }
        public override double Weight { get => Options.standardWeightPallet + boxes.Sum(box => box.Weight); set => base.Volume = value; }
        public List<Box> boxes { get; set; } = new List<Box>();
        public DateOnly ExpirationDate { get; set; }

        public Pallet(int id)
        {
            Id = id;
            Width = Options.standardWidthPallet;
            Height = Options.standardHeightPallet;
            Depth = Options.standardDepthPallet;
            if (boxes.Count > 0)
            {
                ExpirationDate = boxes.Min(box => box.ExpirationDate);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Pallet pallet &&
                   Id == pallet.Id &&
                   Width == pallet.Width &&
                   Height == pallet.Height &&
                   Depth == pallet.Depth &&
                   Weight == pallet.Weight &&
                   boxes.SequenceEqual(boxes) &&
                   Volume == pallet.Volume &&
                   ExpirationDate.Equals(pallet.ExpirationDate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Width, Height, Depth, Weight, boxes, Volume, ExpirationDate);
        }
    }
}
