using System;
using System.Collections.Generic;
using System.Linq;

namespace RévisionLib
{
    public static class Strings
    {
        public static bool Découper(string s,
            out string début, out char centre, out string fin)
        {
            bool estPair = s.Length % 2 == 0;
            début = String.IsNullOrEmpty(s) ? "" : s.Substring(0, s.Length / 2);
            fin = estPair ? s.Substring(s.Length / 2, s.Length / 2) : s.Substring((s.Length / 2) + 1, s.Length / 2);
            centre = estPair ? '\0' : Convert.ToChar(s.Substring(s.Length / 2, 1));
            return !estPair && !String.IsNullOrEmpty(s);
        }

        public static bool PremierChiffre(this string message,
            out int indice, int indiceDépart = 0)
        {
            List<char>? list = message
                .ToCharArray()
                .ToList();
            bool estIndiceValide = indiceDépart < message.Length && indiceDépart >= 0;

            indice = estIndiceValide
                ? list.Select((c, index) => new { c, index })
                    .FirstOrDefault(a => char.IsDigit(a.c) && a.index >= indiceDépart)?.index ?? -1
                : -1;

            return estIndiceValide && indice != -1;
        }

        public static bool PremierNonChiffre(this string message,
            out int indice, int indiceDépart = 0)
        {
            List<char>? list = message
                .ToCharArray()
                .ToList();
            bool estIndiceValide = indiceDépart < message.Length && indiceDépart >= 0;

            indice = estIndiceValide
                ? list.Select((c, index) => new { c, index })
                    .FirstOrDefault(a => !char.IsDigit(a.c) && a.index >= indiceDépart)?.index ?? -1
                : -1;

            return estIndiceValide && indice != -1;
        }

        public static bool LocaliserNombre(this string message,
            out int indiceDébut, out int indiceFin, int indiceDépart = 0)
        {
            bool premierChiffre = PremierChiffre(message, out int indice, indiceDépart);
            bool premiereLettreIndice = PremierNonChiffre(message, out indiceFin, indice);

            indiceDébut = premierChiffre ? indice : -1;
            indiceFin = premierChiffre ? premierChiffre && !premiereLettreIndice ? message.Length : indiceFin : -1;

            return premierChiffre;
        }

        public static bool SommeChiffres(this int nombre) => throw new NotImplementedException();

        public static bool EncoderLettre(this char c) => throw new NotImplementedException();

        public static bool EncoderLettre(this char c,
            int décalage) =>
            throw new NotImplementedException();

        public static bool EncoderMessage(this string message,
            int décalage = 1) =>
            throw new NotImplementedException();

        public static bool ExtraireNombre(this string message,
            out int nombre, ref int indiceDépart)
        {
            var localiser = LocaliserNombre(message, out int indiceDebut, out int indiceFin, indiceDépart);
            bool estIndiceValide = indiceDépart >= 0 && indiceDépart <= message.Length;
            int resultat;
            if (estIndiceValide)
            {
                if (!localiser)
                {
                    indiceDépart = message.Length;
                    nombre = 0;
                }
                else
                {
                    nombre = 0;
                    for (int i = indiceDépart; i < message.Length; i++)
                    {
                        if (int.TryParse(message[indiceDebut..indiceFin], out resultat))
                        {
                            nombre = resultat;
                            indiceDépart = indiceFin;
                        }
                        else
                        {
                            indiceDépart = indiceDebut;
                            return false;
                        }
                    }
                }
            }
            else
            {
                nombre = 0;
            }
            return localiser;
        }

        public static bool ExtraireNombres(this string message,
            List<int> nombres)
        {
            int indice = 0;

            while (ExtraireNombre(message, out int nb, ref indice))
            {
                if (nb == 0)
                {
                    return false;
                }
                nombres.Add(nb);
                indice++;
            }

            return indice != 0 && nombres.Count != 0;
        }
    }
}
