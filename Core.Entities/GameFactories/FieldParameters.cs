namespace Core.Entities.GameFactories
{
    public class FieldParameters
    {
        public FieldParameters(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}