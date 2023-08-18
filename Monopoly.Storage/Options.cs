namespace Monopoly.Storage
{
    public static class Options
    {
        public static double maxWidthBox = 20;
        public static double maxHeightBox = 50;
        public static double maxDepthBox = 30;
        public static double maxWeightBox = 100;
        public static int defaultExpirationDate = 100;
        public static double standardWidthPallet = 120;
        public static double standardHeightPallet = 200;
        public static double standardDepthPallet = 80;
        public static double standardWeightPallet = 30;
        public static double standardVolumePallet = standardDepthPallet * standardHeightPallet * standardWidthPallet;
    }
}
