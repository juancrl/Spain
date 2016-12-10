// --------------------------------------------------------------------
// Project : SPAIN
// Dec 2016
// Códigos postales, Provincias, Localidades, Comunidades autónomas, Indexación sonora por METAPHONE
// Class      : ZIP                 (Códigos Postales)
// Class Name : [Business.ZIP]
// Author : Juan Carlos Ruiz López, juancarlosruizlopez@hotmail.com
// --------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   
    public class ZIP
    {

        public static string ExtractZipFromExcelFormat(string ZipInExcel)
        {

            // =TEXT(8034,"00000")

            string CincoBlancos = new string(' ', 5);
            if (string.IsNullOrWhiteSpace(ZipInExcel)) return CincoBlancos;

            string UText = ZipInExcel.Trim().ToUpper();

            if (ZipInExcel.StartsWith("=TEXT("))
            {
                string[] Trozos1 = ZipInExcel.Split('(');
                string[] Trozos2 = Trozos1[1].Split(',');
                string TrozoNumero = Trozos2[0];
                return NormalizarZip(TrozoNumero);
            }

            return ZipInExcel.Trim();

        }


        public static string ConvertZipToExcelFormat (string Zip)
        { 
  /*
            if ($Zip - eq "28xxx") { return $Zip }
            if ($Zip - match "[A..Z]") { return $Zip }
            if ($Zip - eq  ".....") { return $Zip }
            if ($Zip - match " ") { return $Zip }    # TBD ver si REPLACE y 5 dígitos y el número es 1..50
  */
            string CincoBlancos = new string(' ', 5);
            if (string.IsNullOrWhiteSpace(Zip)) return CincoBlancos;

            //    if ([string]::IsNullOrWhiteSpace($zip)) { return "    " }

            int ZipNumber = System.Convert.ToInt32(Zip);

            return "=TEXT(" + ZipNumber.ToString() + @",""00000"")";

         }

        public static string NormalizarZip(string ZipCode)
        {
            // Sacar un ZIP STRING de 5 dígitos o ZEROS

            // Si no puede, ERROR, devuelve EMPTY


            string CincoBlancos = new string(' ', 5);

            if (string.IsNullOrWhiteSpace(ZipCode)) return CincoBlancos;

            ZipCode = ZipCode.Trim();

            if (ZipCode == "0") return CincoBlancos;

            // Si contiene más de 5 caracteres, o caracteres no numéricos -> ERROR
            if (ZipCode.Length > 5) return string.Empty;

            bool ConvertError = false;
            int ZipAsNum = 0;
            try
            {
                ZipAsNum = System.Convert.ToInt32(ZipCode);
            }
            catch { ConvertError = true; };

            if (ConvertError) return string.Empty;

            string result = string.Format("{0:d5}", ZipAsNum);
            return result;

        }


        public static string ZipToProvincia (string ZipCode, bool returnMatricula=false)
        {

            if (string.IsNullOrEmpty(ZipCode)) return "";


            // Espera un ZIP de 5 dígitos normalizado
            if (ZipCode.Trim().Length < 2) return "";



           ZipCode = ZipCode.Substring(0, 2);

           switch (ZipCode )
           {
             case "01": { return "Álava" ; } ; //    # VI - Vitoria
             case "02": { return "Albacete" ; } ; // # AB 
             case "03": { return "Alicante" ; } ; // # A 
             case "04": { return "Almería" ; } ; // #AL 
             case "05": { return "Ávila" ; } ; // #AV 
             case "06": { return "Badajoz" ; } ; // #BA 
             case "07": { return "Baleares" ; } ; // #(Palma de Mallorca) PM / IB 
             case "08": { return "Barcelona" ; } ; // #B 
             case "09": { return "Burgos" ; } ; // #BU 
             case "10": { return "Cáceres" ; } ; // #CC 
             case "11": { return "Cádiz" ; } ; // #CA 
             case "12": { return "Castellón" ; } ; // #CS 
             case "13": { return "Ciudad Real" ; } ; // #CR 
             case "14": { return "Córdoba" ; } ; // #CO 
             case "15": { return "Coruña" ; } ; // #C 
             case "16": { return "Cuenca" ; } ; // #CU 
             case "17": { return "Gerona" ; } ; // #GE / GI 
             case "18": { return "Granada" ; } ; // #GR 
             case "19": { return "Guadalajara" ; } ; // #GU 
             case "20": { return "Guipúzcoa" ; } ; // #(San Sebastián) SS 
             case "21": { return "Huelva" ; } ; // #H 
             case "22": { return "Huesca" ; } ; // #HU 
             case "23": { return "Jaén" ; } ; // #J 
             case "24": { return "León" ; } ; // #LE 
             case "25": { return "Lérida" ; } ; // # L 
             case "26": { return "La Rioja" ; } ; // #(Logroño) LO 
             case "27": { return "Lugo" ; } ; // #LU 
             case "28": { return "Madrid" ; } ; // #M 
             case "29": { return "Málaga" ; } ; // #MA 
             case "30": { return "Murcia" ; } ; // #MU 
             case "31": { return "Navarra" ; } ; // #(Pamplona) NA 
             case "32": { return "Orense" ; } ; // #OR / OU 
             case "33": { return "Asturias" ; } ; // #(Oviedo) O 
             case "34": { return "Palencia" ; } ; // #P 
             case "35": { return "Las Palmas" ; } ; // #GC 
             case "36": { return "Pontevedra" ; } ; // #PO 
             case "37": { return "Salamanca" ; } ; // #SA 
             case "38": { return "Santa Cruz de Tenerife" ; } ; // #TF 
             case "39": { return "Cantabria" ; } ; // #(Santander) S 
             case "40": { return "Segovia" ; } ; // #SG 
             case "41": { return "Sevilla" ; } ; // #SE 
             case "42": { return "Soria" ; } ; // #SO 
             case "43": { return "Tarragona" ; } ; // #T 
             case "44": { return "Teruel" ; } ; // #TE 
             case "45": { return "Toledo" ; } ; // #TO 
             case "46": { return "Valencia" ; } ; // #V 
             case "47": { return "Valladolid" ; } ; // #VA 
             case "48": { return "Vizcaya" ; } ; // #(Bilbao) BI 
             case "49": { return "Zamora" ; } ; // #ZA 
             case "50": { return "Zaragoza" ; } ; // #Z 
             case "51": { return "Ceuta" ; } ; // # CE 
             case "52": { return "Melilla" ; } ; // #ML 


                case "00": { return "?"; }; // 
                case "99": { return "?"; }; // 

            };


            // 00 y 99

            return "[" + ZipCode +"]" ;  // Ni idea = Devuelve EMPTY

} 


     

    }   // Class
}   // Namespace
