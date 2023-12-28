// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("cr957e4+dlRw327UkJpTUDletbcWpCcEFisgLwygbqDRKycnJyMmJTkOC5DWYGpCVev3sHZ1g1iHfwIzTjveJwmWY7DCaic3PtqjWcNrooO1w6i+SUEyxITHjEu0IjWL7JsBJ2K1tIbo+8t4TMeEShA5Epx8leTMKlzxR1Jct1AP183A47H9lar2qgVAS/AdehVbiU0RdjGCBCqon86cJaWfkkpZl0zsTWzNY2SGqQnaBIb5TBmUzT4CDkBcfdZFU3y4cEtcigukJykmFqQnLCSkJycmlpEUqqMYmNjyBDTChRM6izJSqrsjebQX9dxicut3XdzWd8mBRLM8T/SSD90jB08fYWRYI8EKgATKEIm5rWTL8Y99FSI54x56KOLg5yQlJyYn");
        private static int[] order = new int[] { 9,9,7,10,12,12,8,7,10,10,10,12,13,13,14 };
        private static int key = 38;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
