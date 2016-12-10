// --------------------------------------------------------------------
// Project : SPAIN
// Dec 2016
// Códigos postales, Provincias, Localidades, Comunidades autónomas, Indexación sonora por METAPHONE
// Class      : SPAIN                 (Localidades)
// Class Name : [Business.Spain]
// Author : Juan Carlos Ruiz López, juancarlosruizlopez@hotmail.com
// --------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Spain
    {
        
        public static bool AnalizarCualquierLocalidad (string Nombre, out string Provincia, out string Comunidad)
        {
            // Dado un nombre, determina si es algo que esté en España.
            // Localidad, Pueblo, Ciudad, Nombre de Provincia, Isla...
            // Si puede devuelove su provincia y comunidad
            // SI no lo encuentra devuelve FALSE

            string UTexto = Nombre.Trim().ToUpper().Replace(" ", "");

                Provincia = "?";
                Comunidad = "?";


            if (EsProvinciaSpain(UTexto))
            {
                Provincia = Nombre.Trim();
                Comunidad = ComunidadAutonoma(UTexto);
                return true;
            }

            // Es Capital (con nombre que no coincide con la provincia)
            string ProvCapital = "";
            if (EsCapitalSpain(UTexto, out ProvCapital))
            {
                Provincia = ProvCapital;
                Comunidad = ComunidadAutonoma(UTexto);
                return true;
            }


            string ProvIsla = "";
            if (EsIslaSpain(UTexto,out ProvIsla))
            {
                Provincia = ProvIsla;
                Comunidad = ComunidadAutonoma(UTexto);
                return true;
            }


            // Es Localidad de 
            string ProvLocalidad = "";
            if (EsPuebloConocidoSpain(UTexto, out ProvLocalidad))
            {
                Provincia = ProvLocalidad;
                Comunidad = ComunidadAutonoma(UTexto);
                return true;
            }

            // Nada conocido
            return false;
        }
        // -----------------------------------------------------------------------


        public static bool EsIslaSpain(string Texto, out string Provincia)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            Provincia = "Baleares";

            if (UTexto == "MALLORCA") return true;
            if (UTexto == "MENORCA") return true;
            if (UTexto == "IBIZA") return true;
            if (UTexto == "FORMENTERA") return true;


            Provincia = "Las Palmas"; 
            if (UTexto == "GRANCANARIA") return true;
            if (UTexto == "FUERTEVENTURA") return true;
            if (UTexto == "LANZAROTE") return true;

            Provincia = "Santa Cruz de Tenerife";
            if (UTexto == "TENERIFE") return true;
            if (UTexto == "GOMERA") return true;
            if (UTexto == "LAPALMA") return true;
            if (UTexto == "HIERRO") return true;


            // Ceuta y Melilla aquí


            Provincia = "";
            return false;

        }



        // ---------------------------------------------------------------------------------
        public static bool EsCapitalSpain(string Texto, out string Provincia)
        {

            // CAPITALES que no se llaman igual que la provincia

            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            Provincia = "";


            if (UTexto == "VITORIA") { Provincia = "Álava"; return true; }
            if (UTexto == "BILBO") { Provincia = "Vizcaya"; return true; }
            if (UTexto == "BILBAO") { Provincia = "Vizcaya"; return true; }
            if (UTexto == "SANSEBASTIÁN") { Provincia = "Guipúzcoa"; return true; }
            if (UTexto == "SANSEBASTIAN") { Provincia = "Guipúzcoa"; return true; }
            if (UTexto == "DONOSTIA") { Provincia = "Guipúzcoa"; return true; }
            if (UTexto == "LOGROÑO") { Provincia = "La Rioja"; return true; }
            if (UTexto == "PAMPLONA") { Provincia = "Navarra"; return true; }
            if (UTexto == "SANTANDER") { Provincia = "Santander"; return true; }
            if (UTexto == "OVIEDO") { Provincia = "Oviedo"; return true; }

            if (UTexto == "PALMA") { Provincia = "Baleares"; return true; }
            if (UTexto == "PALMADEMALLORCA") { Provincia = "Baleares"; return true; }




            if (EsPuebloConocidoSpain(UTexto, out Provincia)) return true;
             

            return false;
        }


        // -------------------------------- Pueblos frecuentes (no capitales de provincia)
        public static bool EsPuebloConocidoSpain(string Texto, out string Provincia)
        {

            // https://es.wikipedia.org/wiki/Anexo:Municipios_de_Espa%C3%B1a_por_poblaci%C3%B3n

            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");
            Provincia = "?";

 

            if (UTexto == "MOSTOLES") { Provincia = "Madrid"; return true; }
            if (UTexto == "MÓSTOLES") { Provincia = "Madrid"; return true; }
            if (UTexto == "TRESCANTOS") { Provincia = "Madrid"; return true; }
            if (UTexto == "POZUELO")    { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCALÁ") { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCALA") { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCALÁDEHENARES") { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCALADEHENARES") { Provincia = "Madrid"; return true; }
            if (UTexto == "FUENLABRADA") { Provincia = "Madrid"; return true; }
            if (UTexto == "LEGANES") { Provincia = "Madrid"; return true; }
            if (UTexto == "LEGANÉS") { Provincia = "Madrid"; return true; }
            if (UTexto == "GETAFE")     { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCORCON") { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCORCÓN") { Provincia = "Madrid"; return true; }
            if (UTexto == "PARLA") { Provincia = "Madrid"; return true; }
            if (UTexto == "LASROZAS")   { Provincia = "Madrid"; return true; }
            if (UTexto == "ALCOBENDAS") { Provincia = "Madrid"; return true; }
            if (UTexto == "GALAPAGAR") { Provincia = "Madrid"; return true; }

            if (UTexto == "HOSPITALET") { Provincia = "Barcelona"; return true; }
            if (UTexto == "BADALONA")   { Provincia = "Barcelona"; return true; }
            if (UTexto == "TARRASA") { Provincia = "Barcelona"; return true; }
            if (UTexto == "TERRASSA") { Provincia = "Barcelona"; return true; }
            if (UTexto == "SABADELL")   { Provincia = "Barcelona"; return true; }
            if (UTexto == "CORNELLA") { Provincia = "Barcelona"; return true; }
            if (UTexto == "SANTCUGAT")  { Provincia = "Barcelona"; return true; }
            if (UTexto == "MATARÓ") { Provincia = "Barcelona"; return true; }

            if (UTexto == "REUS")    { Provincia = "Tarragona"; return true; };
            if (UTexto == "VALLS")   { Provincia = "Tarragona"; return true; };
            if (UTexto == "TORTOSA") { Provincia = "Tarragona"; return true; };
            if (UTexto == "VIC")     { Provincia = "Barcelona"; return true; };
            if (UTexto == "OLOT")    { Provincia = "Girona"; return true; };

            if (UTexto == "ELCHE") { Provincia = "Alicante"; return true; };
            if (UTexto == "CARTAGENA") { Provincia = "Murcia"; return true; };
            if (UTexto == "JEREZ") { Provincia = "Cádiz"; return true; }
            if (UTexto == "JEREZDELAFRONTERA") { Provincia = "Cádiz"; return true; }
            if (UTexto == "DOSHERMANAS") { Provincia = "Sevilla"; return true; }
            if (UTexto == "RONDA") { Provincia = "Málaga"; return true; }
            if (UTexto == "MARBELLA") { Provincia = "Málaga"; return true; }
            if (UTexto == "ALGECIRAS") { Provincia = "Cádiz"; return true; }

            if (UTexto == "VIGO") { Provincia = "Pontevedra"; return true; }
            if (UTexto == "GIJON") { Provincia = "Asturias"; return true; }
            if (UTexto == "GIJÓN") { Provincia = "Asturias"; return true; }
            if (UTexto == "SANTIAGO") { Provincia = "La Coruña"; return true; }
            if (UTexto == "SANTIAGODECOMPOSTELA") { Provincia = "La Coruña"; return true; }


            if (UTexto == "CIUTADELLA")  { Provincia = "Baleares"; return true; };


            if (UTexto == "BARACALDO") { Provincia = "Vizcaya"; return true; }
            if (UTexto == "IRUN") { Provincia = "Guipúzcoa"; return true; }
            if (UTexto == "IRÚN") { Provincia = "Guipúzcoa"; return true; }
            if (UTexto == "TUDELA")  { Provincia = "Navarra"; return true; }
            if (UTexto == "TAFALLA") { Provincia = "Navarra"; return true; }
            if (UTexto == "ESTELLA") { Provincia = "Navarra"; return true; }
            if (UTexto == "OLITE")   { Provincia = "Navarra"; return true; }

            return false;

        }



        public static bool EsProvinciaCat(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "BARCELONA") return true;
            if (UTexto == "LERIDA") return true;
            if (UTexto == "LLEIDA") return true;
            if (UTexto == "TARRAGONA") return true;
            if (UTexto == "GERONA") return true;
            if (UTexto == "GIRONA") return true;

            return false;



        }
        public static bool EsProvinciaAragon(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "ZARAGOZA") return true;
            if (UTexto == "HUESCA") return true;
            if (UTexto == "TERUEL") return true;

            return false;

        }
        public static bool EsProvinciaExtremadura(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "CACERES") return true;
            if (UTexto == "CÁCERES") return true;
            if (UTexto == "BADAJOZ") return true;

            return false;

        }

        public static bool EsProvinciaCastillaYLeon (string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "VALLADOLID") return true;
            if (UTexto == "BURGOS") return true;
            if (UTexto == "SALAMANCA") return true;
            if (UTexto == "LEON") return true;
            if (UTexto == "LEÓN") return true;
            if (UTexto == "PALENCIA") return true;
            if (UTexto == "ZAMORA") return true;
            if (UTexto == "AVILA") return true;
            if (UTexto == "ÁVILA") return true;
            if (UTexto == "SEGOVIA") return true;
            if (UTexto == "SORIA") return true;

            return false;
        }
        public static bool EsProvinciaCastillaLaMancha (string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "TOLEDO") return true;
            if (UTexto == "CUENCA") return true;
            if (UTexto == "GUADALAJARA") return true;
            if (UTexto == "ALBACETE") return true;
            if (UTexto == "CIUDADREAL") return true;

            return false;


        }

        public static bool EsProvinciaCanarias(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "SANTACRUZDETENERIFE") return true;
            if (UTexto == "LASPALMAS") return true;

            return false;


        }


        public static bool EsProvinciaBaleares(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "BALEARES") return true;

            if (UTexto == "PALMA") return true;
            if (UTexto == "MALLORCA") return true;
            if (UTexto == "MENORCA") return true;
            if (UTexto == "IBIZA") return true;
            if (UTexto == "FORMENTERA") return true;

            return false;



        }

        public static bool EsProvinciaLevante(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "VALENCIA") return true;
            if (UTexto == "CASTELLON") return true;
            if (UTexto == "CASTELLÓN") return true;
            if (UTexto == "ALICANTE") return true;

            return false;



        }
        public static bool EsProvinciaAndalucia(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "SEVILLA") return true;
            if (UTexto == "HUELVA") return true;
            if (UTexto == "ALMERIA") return true;
            if (UTexto == "CORDOBA") return true;
            if (UTexto == "JAEN") return true;
            if (UTexto == "GRANADA") return true;
            if (UTexto == "MALAGA") return true;
            if (UTexto == "CADIZ") return true;

            if (UTexto == "ALMERÍA") return true;
            if (UTexto == "CÓRDOBA") return true;
            if (UTexto == "JAÉN") return true;
            if (UTexto == "MÁLAGA") return true;
            if (UTexto == "CÁDIZ") return true;


            return false;



        }
        public static bool EsProvinciaGalicia(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "LACORUÑA") return true;
            if (UTexto == "ACORUÑA") return true;
            if (UTexto == "CORUÑA") return true;

            if (UTexto == "LUGO") return true;

            if (UTexto == "ORENSE") return true;
            if (UTexto == "PONTEVEDRA") return true;
            if (UTexto == "OURENSE") return true;

            return false;

        }




        public static bool EsProvinciaEuzkadi(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "ÁLAVA") return true;
            if (UTexto == "ALAVA") return true;
            if (UTexto == "ARABA") return true;
            if (UTexto == "GUIPUZCOA") return true;
            if (UTexto == "GUIPÚZCOA") return true;
            if (UTexto == "GIPUZKOA") return true;
            if (UTexto == "VIZCAYA") return true;
            if (UTexto == "BIZKAIA") return true;

            return false;



        }

        public static string ComunidadAutonoma(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            // Pasarle una provincia y/o localidad

            if (UTexto == "MADRID")    return "Madrid";
            if (UTexto == "OVIEDO")    return "Asturias";
            if (UTexto == "SANTANDER") return "Cantabria";
            if (UTexto == "MURCIA")    return "Murcia";

            if (EsProvinciaCat(Texto)) return "Catalunya";
            if (EsProvinciaAragon(Texto)) return "Aragón";
            if (EsProvinciaBaleares(Texto)) return "Baleares";
            if (EsProvinciaLevante(Texto)) return "Comunidad Valenciana";
            if (EsProvinciaAndalucia(Texto)) return "Andalucía";
            if (EsProvinciaGalicia(Texto)) return "Galicia";
            if (EsProvinciaEuzkadi(Texto)) return "Euzkadi";
            if (EsProvinciaExtremadura(Texto)) return "Extremadura";
            if (EsProvinciaCastillaYLeon(Texto)) return "Castilla-León";
            if (EsProvinciaCastillaLaMancha(Texto)) return "Castilla-La Mancha";
            if (EsProvinciaCanarias(Texto)) return "Canarias";

            return "TBD";

        }


        public static bool EsProvinciaSpain(string Texto)
        {
            string UTexto = Texto.Trim().ToUpper().Replace(" ", "");

            if (UTexto == "ÁLAVA") return true;
            if (UTexto == "ALAVA") return true;
            if (UTexto == "ALBACETE") return true;
            if (UTexto == "ALICANTE") return true;
            if (UTexto == "ALMERIA") return true;
            if (UTexto == "ALMERÍA") return true;
            if (UTexto == "AVILA") return true;
            if (UTexto == "BADAJOZ") return true;
            if (UTexto == "BALEARES") return true;
            if (UTexto == "BARCELONA") return true;
            if (UTexto == "BURGOS") return true;
            if (UTexto == "CACERES") return true;
            if (UTexto == "CADIZ") return true;
            if (UTexto == "CASTELLON") return true;
            if (UTexto == "CIUDADREAL") return true;
            if (UTexto == "CORDOBA") return true;
            if (UTexto == "CÓRDOBA") return true;
            if (UTexto == "CORUÑA") return true;
            if (UTexto == "LACORUÑA") return true;
            if (UTexto == "ACORUÑA") return true;
            if (UTexto == "CUENCA") return true;
            if (UTexto == "GERONA") return true;
            if (UTexto == "GIRONA") return true;
            if (UTexto == "GRANADA") return true;
            if (UTexto == "GUADALAJARA") return true;
            if (UTexto == "GUIPUZCOA") return true;
            if (UTexto == "GUIPÚZCOA") return true;
            if (UTexto == "HUELVA") return true;
            if (UTexto == "HUESCA") return true;
            if (UTexto == "JAEN") return true;
            if (UTexto == "JAÉN") return true;
            if (UTexto == "LEON") return true;
            if (UTexto == "LEÓN") return true;
            if (UTexto == "LERIDA") return true;
            if (UTexto == "LLEIDA") return true;
            if (UTexto == "LARIOJA") return true;
            if (UTexto == "RIOJA") return true;
            if (UTexto == "LUGO") return true;
            if (UTexto == "MADRID") return true;
            if (UTexto == "MALAGA") return true;
            if (UTexto == "MÁLAGA") return true;
            if (UTexto == "MURCIA") return true;
            if (UTexto == "NAVARRA") return true;
            if (UTexto == "ORENSE") return true;
            if (UTexto == "OURENSE") return true;
            if (UTexto == "ASTURIAS") return true;
            if (UTexto == "PALENCIA") return true;
            if (UTexto == "LASPALMAS") return true;
            if (UTexto == "PONTEVEDRA") return true;
            if (UTexto == "SALAMANCA") return true;
            if (UTexto == "SANTACRUZDETENERIFE") return true;
            if (UTexto == "CANTABRIA") return true;
            if (UTexto == "SEGOVIA") return true;
            if (UTexto == "SEVILLA") return true;
            if (UTexto == "SORIA") return true;
            if (UTexto == "TARRAGONA") return true;
            if (UTexto == "TERUEL") return true;
            if (UTexto == "TOLEDO") return true;
            if (UTexto == "VALENCIA") return true;
            if (UTexto == "VALLADOLID") return true;
            if (UTexto == "VIZCAYA") return true;
            if (UTexto == "BIZKAIA") return true;
            if (UTexto == "ZAMORA") return true;
            if (UTexto == "ZARAGOZA") return true;
            if (UTexto == "CEUTA") return true;
            if (UTexto == "MELILLA") return true;

            /// TBD
            /// 

            return false;

        }

    }

   
}   // Namespace
