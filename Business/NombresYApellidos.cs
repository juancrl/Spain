using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Nombres
    {

        public static string CorregirNombre (string Nom)
        {

            // Corregir errores, normalizar

            Nom = Nom.Replace("  ", " ");
            Nom = Nom.Replace("  ", " ");

            // OJO, si es al final de línea también

            Nom = Nom.Replace("Jose ", "José ");
            Nom = Nom.Replace("Maria ", "María ");     // No en CAT :-)
            Nom = Nom.Replace("Garcia ", "García ");
            Nom = Nom.Replace("Jesus ", "Jesús ");
            Nom = Nom.Replace("Andres ", "Andrés ");
            return Nom;

        }


        internal static bool EsNombreCompuestoConocido(string nom, bool AceptarMalosAcentos = false)
        {
            // TBD MAYUSCULAS
            // TBD Pass CULTURE or ANY

            if (nom.StartsWith("Juan Carlos")) return true;
            if (nom.StartsWith("José María")) return true;
            if (nom.StartsWith("José Luis")) return true;
            if (nom.StartsWith("Juan José")) return true;
            if (nom.StartsWith("José Manuel")) return true;
            if (nom.StartsWith("Juan Manuel")) return true;
            if (nom.StartsWith("José Antonio")) return true;
            if (nom.StartsWith("José Carlos")) return true;
            if (nom.StartsWith("Jesús María")) return true;
            if (nom.StartsWith("José Alberto")) return true;
            if (nom.StartsWith("Luis Alberto")) return true;
            if (nom.StartsWith("Alberto José")) return true;
            if (nom.StartsWith("José Ramón")) return true;
            if (nom.StartsWith("Juan Ramón")) return true;
            if (nom.StartsWith("Juan José")) return true;
            if (nom.StartsWith("Miguel Angel")) return true;
            if (nom.StartsWith("José Angel")) return true;
            if (nom.StartsWith("Juan Miguel")) return true;
            if (nom.StartsWith("José Miguel")) return true;
            if (nom.StartsWith("José Pablo")) return true;
            if (nom.StartsWith("Juan Pablo")) return true;
            if (nom.StartsWith("Juan Pedro")) return true;
            if (nom.StartsWith("Francisco Javier")) return true;
            if (nom.StartsWith("Francisco Jesús")) return true;
            if (nom.StartsWith("Francisco José")) return true;
            if (nom.StartsWith("Juan Francisco")) return true;
            if (nom.StartsWith("José Francisco")) return true;
            if (nom.StartsWith("Jesús Francisco")) return true;
            if (nom.StartsWith("Miguel Ángel")) return true;
            if (nom.StartsWith("Luis Miguel")) return true;
            if (nom.StartsWith("Carlos Manuel")) return true;
            if (nom.StartsWith("Juan Antonio")) return true;
            if (nom.StartsWith("José Vicente")) return true;
            if (nom.StartsWith("Juan Ignacio")) return true;
            if (nom.StartsWith("José Ignacio")) return true;
            if (nom.StartsWith("José Javier")) return true;
            if (nom.StartsWith("José Mª")) return true;
            if (nom.StartsWith("Juan Bautista")) return true;

            if (nom.StartsWith("Andrés Ignacio")) return true;
            if (nom.StartsWith("Pablo David")) return true;
            if (nom.StartsWith("José Mª")) return true;
            if (nom.StartsWith("Gustavo José")) return true;
            if (nom.StartsWith("Juan Leandro")) return true;
            if (nom.StartsWith("Jaime José")) return true;
            if (nom.StartsWith("José Enrique")) return true;


            // Malas acentuaciones pero quizás CAT/CAST
            if (nom.StartsWith("Jose Maria")) return true;
            if (nom.StartsWith("José Maria")) return true;
            if (nom.StartsWith("Jose María")) return true;
            if (nom.StartsWith("Juan Jose")) return true;


            // CAT
            if (nom.StartsWith("Josep Maria")) return true;
            if (nom.StartsWith("Josep Miquel")) return true;
            if (nom.StartsWith("Rosa Maria")) return true;    
            if (nom.StartsWith("Joan Ramon")) return true;
            if (nom.StartsWith("Joan Carles")) return true;
            if (nom.StartsWith("Josep Lluis")) return true;
            if (nom.StartsWith("Joan Albert")) return true;
            if (nom.StartsWith("Joan Mª")) return true;
            if (nom.StartsWith("Josep Ramon")) return true;
            if (nom.StartsWith("Joan Enric")) return true;



            if (nom.StartsWith("Ana María")) return true;
            if (nom.StartsWith("Ana Mª")) return true;
            if (nom.StartsWith("María Jesús")) return true;
            if (nom.StartsWith("María Luisa")) return true;
            if (nom.StartsWith("María José")) return true;
            if (nom.StartsWith("María Victoria")) return true;
            if (nom.StartsWith("María Teresa")) return true;
            if (nom.StartsWith("María Elena")) return true;
            if (nom.StartsWith("María Antonia")) return true;
            if (nom.StartsWith("Mª Jesús")) return true;
            if (nom.StartsWith("Mª Luisa")) return true;
            if (nom.StartsWith("Mª José")) return true;
            if (nom.StartsWith("Mª Victoria")) return true;
            if (nom.StartsWith("Mª Teresa")) return true;
            if (nom.StartsWith("Mari Carmen")) return true;
            if (nom.StartsWith("Rosa María")) return true;
            if (nom.StartsWith("María Rosa")) return true;
            if (nom.StartsWith("Mª Rosa")) return true;


            if (AceptarMalosAcentos)
            {
                if (nom.ToUpper().StartsWith("JOSE MARIA")) return true;
            }


            return false;

         

        }
        public static bool SepararNombreYApellido(string NombreCompleto, 
                                                  out string NombrePosible, 
                                                  out string ApellidoPosible,
                                                  out string Incidencia)
        {

            NombrePosible = string.Empty;
            ApellidoPosible = string.Empty;
            Incidencia = "";

            if (string.IsNullOrWhiteSpace(NombreCompleto))
            {
                Incidencia = "Sin nombre";
                return false;
            }

            string Nom = NombreCompleto.Trim();

            Nom = CorregirNombre(Nom);
            
            string NomU = Nom.ToUpper();

            string[] Partes = Nom.Split(' ');
            int NumPartes = Partes.Length;

            if (EsNombreCompuestoConocido(Nom))
            {
                NombrePosible = Partes[0] + " " + Partes[1];    
                if (NumPartes > 2)
                {
                    string BuildApellido = "";
                    for (int NumParte = 2; NumParte < NumPartes; NumParte ++)
                    {
                        BuildApellido += Partes[NumParte] + " ";

                    }
                    ApellidoPosible = BuildApellido.Trim();
                }
               
                return true;
            }

            if (NumPartes == 1)
            {
                NombrePosible = "";
                ApellidoPosible = Partes[0];
                Incidencia = "Sólo apellido";
                return false;
            }

            if (NumPartes == 2)
            {
                NombrePosible = Partes[0];
                ApellidoPosible = Partes[1];
                return true;
            }

            if ((NumPartes == 3) && (Partes[1] == "de"))
            {   // Pepe de Miguel
                NombrePosible = Partes[0];
                ApellidoPosible = Partes[1] + " " + Partes[2];
                return true;
            }
            

            if (Nom.Contains("DE LA"))
            {
                string[] seps = new string[] { "de la", "DE LA" };
                string[] trozos2 = Nom.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                NombrePosible = trozos2[0];
                ApellidoPosible = "DE LA " + trozos2[1];
                return true;


            }
            if (Nom.Contains("de la"))
            {
                string[] seps = new string[] { "de la", "DE LA" };
                string[] trozos2 = Nom.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                NombrePosible = trozos2[0];
                ApellidoPosible = "de la " + trozos2[1];
                return true;


            }

            if (NumPartes == 4)
            {
                // Y no es compuesto -ya mirado arriba -
                NombrePosible = Partes[0] + " " + Partes[1];
                ApellidoPosible = Partes[2] + " " + Partes[3];
                return true;


            }

            // 3 palabras if (nom.StartsWith("mariá del Carmen")) return true;



            // TBD MAS
            NombrePosible = "????" + Nom;
            ApellidoPosible = "???: " + Nom;
            Incidencia = "Falta mejor troceado";
            return false;


}


   

        public static bool PosibleNombreIncorrecto (string nombre)
        {
            // Si el nombre tiene cosas raras (incluidos espacios) quejarse
            // Si es nombre compuesto conocido entonces no.
            // Mínimo 3 letras.

            if (string.IsNullOrEmpty(nombre)) return true;    // Incorrecto


            if (nombre.Length < 3) return true;      // JON

            if (!nombre.Contains(" ")) return false;   // Correcto sin espacios


            if (nombre.Contains("@")) return false;   // EMAIL
            if (nombre.Contains("Ã±")) return false;   // Ñ

            if (nombre.EndsWith(".")) return false;   // . final

            if (EsNombreCompuestoConocido(nombre)) return false;

            // Improve
            if (nombre.Contains("0")) return false;
            if (nombre.Contains("1")) return false;
            if (nombre.Contains("2")) return false;
            if (nombre.Contains("3")) return false;
            if (nombre.Contains("4")) return false;
            if (nombre.Contains("5")) return false;
            if (nombre.Contains("6")) return false;
            if (nombre.Contains("7")) return false;
            if (nombre.Contains("8")) return false;
            if (nombre.Contains("9")) return false;

            return true;




        }


    }   // Class
}   // Namespace
