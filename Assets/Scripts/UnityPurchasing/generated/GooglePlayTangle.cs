// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("g6ZFMZLIdYtS8ZNBbuI1VcNgD1j3x93v1RWK2AlVTSpZxRLwoo94mD69s7yMPr22vj69vbwl7Xx7Vic3muZNWzpSLNs8kT2fL7gurjWLhCfRjhIINUEoMABFi7DBWFDubupdIxcjAhgHXxeVq8MWSnEXC58/TsI+jD69noyxurWWOvQ6S7G9vb25vL/MoD5ui3LlTsOl/JPJPe5TzWaaDrybAyjl4oyd516AoZegq6xK0MmxVpRO/L9/qdndx2zsoqxY53ZPIVZVWvKiwNdIgd1PBb1Z2QDRk2w7cJUAlMDeI+0smqhQtM1LViLK5v6oymIbKhHb+8qhKHo20L3HjrrD7I6XhQWI9iGACx8NNqVpJPaFRZb4ysGuFw7Rj9AcF76/vby9");
        private static int[] order = new int[] { 10,11,11,7,7,7,10,10,10,11,12,13,12,13,14 };
        private static int key = 188;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
