using System;
using System.Collections.Generic;

namespace RévisionLib
{
    public static class Strings
    {
        public static bool Découper(string s,
            out string début, out char centre, out string fin)
        {
            bool estPair = s.Length % 2 == 0;
            début = String.IsNullOrEmpty(s) ? "" :
                s.Substring(0, s.Length / 2);
            fin = estPair ?
                s.Substring(s.Length / 2, s.Length / 2) :
                s.Substring(s.Length / 2 + 1, s.Length / 2);
            centre = estPair ? '\0' :
                    Convert.ToChar(s.Substring(s.Length / 2, 1));
            return !estPair && !String.IsNullOrEmpty(s);
        }
        public static bool PremierChiffre(this string message,
            out int indice)
        {
            throw new NotImplementedException();
        }
        public static bool PremierChiffre(this string message,
            out int indice, int indiceDépart)
        {
            throw new NotImplementedException();
        }
        public static bool PremierNonChiffre(this string message,
            out int indice, int indiceDépart = 0)
        {
            throw new NotImplementedException();
        }
        public static bool LocaliserNombre(this string message,
            out int indiceDébut, out int indiceFin, int indiceDépart = 0)
        {
            throw new NotImplementedException();
        }
        public static bool SommeChiffres(this int nombre)
        {
            throw new NotImplementedException();
        }
        public static bool EncoderLettre(this char c)
        {
            throw new NotImplementedException();
        }
        public static bool EncoderLettre(this char c,
            int décalage)
        {
            throw new NotImplementedException();
        }
        public static bool EncoderMessage(this string message,
            int décalage = 1)
        {
            throw new NotImplementedException();
        }
        public static bool ExtraireNombre(this string message,
            out int nombre, ref int indiceDépart)
        {
            throw new NotImplementedException();
        }
        public static bool ExtraireNombres(this string message,
            List<int> nombres)
        {
            throw new NotImplementedException();
        }

    }
}
