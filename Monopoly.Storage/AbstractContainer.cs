namespace Monopoly.Storage
{
    public abstract class AbstractContainer
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public virtual double Weight { get; set; }
        public virtual double Volume { get; set; }
    }
}
