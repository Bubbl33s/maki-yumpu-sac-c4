using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using MakiYumpuSAC.Models;

namespace MakiYumpuSAC.Resources
{
    public class Utilities
    {
        public static string EncryptKey(string key)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(key));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }

        public static SelectList HebrasOptions()
        {
            var hebras = new List<string>
            {
                "1/5",
                "2/16",
                "2/28",
                "2/32",
                "3/10"
            };

            return new SelectList(hebras);
        }

        public static SelectList CountriesOptions()
        {
            var paises = new List<string>()
            {
                "Afganistán", "Albania", "Alemania", "Andorra", "Angola", "Antigua y Barbuda",
                "Arabia Saudita", "Argelia", "Argentina", "Armenia", "Australia", "Austria",
                "Azerbaiyán", "Bahamas", "Bangladés", "Barbados", "Baréin", "Bélgica", "Belice",
                "Benín", "Bielorrusia", "Birmania", "Bolivia", "Bosnia y Herzegovina", "Botsuana",
                "Brasil", "Brunéi", "Bulgaria", "Burkina Faso", "Burundi", "Bután", "Cabo Verde",
                "Camboya", "Camerún", "Canadá", "Catar", "Chad", "Chile", "China", "Chipre",
                "Ciudad del Vaticano", "Colombia", "Comoras", "Corea del Norte", "Corea del Sur",
                "Costa de Marfil", "Costa Rica", "Croacia", "Cuba", "Dinamarca", "Dominica",
                "Ecuador", "Egipto", "El Salvador", "Emiratos Árabes Unidos", "Eritrea", "Eslovaquia",
                "Eslovenia", "España", "Estados Unidos", "Estonia", "Etiopía", "Filipinas", "Finlandia",
                "Fiyi", "Francia", "Gabón", "Gambia", "Georgia", "Ghana", "Granada", "Grecia",
                "Guatemala", "Guyana", "Guinea", "Guinea ecuatorial", "Guinea-Bisáu", "Haití",
               "Honduras", "Hungría", "India", "Indonesia", "Irak", "Irán", "Irlanda", "Islandia",
                "Islas Marshall", "Islas Salomón", "Israel", "Italia", "Jamaica", "Japón", "Jordania",
                "Kazajistán", "Kenia", "Kirguistán", "Kiribati", "Kuwait", "Laos", "Lesoto", "Letonia",
                "Líbano", "Liberia", "Libia", "Liechtenstein", "Lituania", "Luxemburgo", "Madagascar",
                "Malasia",  "Malaui", "Maldivas", "Malí", "Malta", "Marruecos", "Mauricio", "Mauritania",
                "México", "Micronesia", "Moldavia", "Mónaco", "Mongolia", "Montenegro", "Mozambique",
                "Namibia", "Nauru", "Nepal", "Nicaragua", "Níger", "Nigeria", "Noruega", "Nueva Zelanda",
                "Omán", "Países Bajos", "Pakistán", "Palaos", "Palestina", "Panamá", "Papúa Nueva Guinea",
                "Paraguay", "Perú", "Polonia", "Portugal", "Reino Unido", "República Centroafricana",
                "República Checa", "República de Macedonia", "República del Congo", "República Democrática del Congo",
                "República Dominicana", "República Sudafricana",  "Ruanda", "Rumanía", "Rusia",
                "Samoa", "San Cristóbal y Nieves", "San Marino", "San Vicente y las Granadinas",
                "Santa Lucía", "Santo Tomé y Príncipe", "Senegal", "Serbia", "Seychelles", "Sierra Leona",
                "Singapur", "Siria", "Somalia", "Sri Lanka", "Suazilandia", "Sudán", "Sudán del Sur",
                "Suecia", "Suiza", "Surinam", "Tailandia", "Tanzania", "Tayikistán", "Timor Oriental",
                "Togo", "Tonga", "Trinidad y Tobago", "Túnez", "Turkmenistán", "Turquía", "Tuvalu",
                "Ucrania", "Uganda", "Uruguay", "Uzbekistán", "Vanuatu", "Venezuela", "Vietnam",
                "Yemen", "Yibuti", "Zambia", "Zimbabue"
            };

            /*
            var paises = new List<string>()
            {
                "Afghanistan", "Albania", "Algeria", "Andorra", "Angola",
                "Antigua & Deps", "Argentina", "Armenia", "Australia", "Austria",
                "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados",
                "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia",
                "Bosnia Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria",
                "Burkina", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde",
                "Central African Rep", "Chad", "Chile", "China", "Colombia", "Comoros",
                "Congo", "Congo (Democratic Rep)", "Costa Rica", "Croatia", "Cuba",
                "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica",
                "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador",
                "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland",
                "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece",
                "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti",
                "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq",
                "Ireland {Republic}", "Israel", "Italy", "Ivory Coast", "Jamaica",
                "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea North",
                "Korea South", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia",
                "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania",
                "Luxembourg", "Macedonia", "Madagascar", "Malawi", "Malaysia",
                "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania",
                "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia",
                "Montenegro", "Morocco", "Mozambique", "Myanmar, {Burma}", "Namibia",
                "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger",
                "Nigeria", "Norway", "Oman", "Pakistan", "Palau", "Panama",
                "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland",
                "Portugal", "Qatar", "Romania", "Russian Federation", "Rwanda",
                "St Kitts & Nevis", "St Lucia", "Saint Vincent & the Grenadines",
                "Samoa", "San Marino", "Sao Tome & Principe", "Saudi Arabia", "Senegal",
                "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia",
                "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan",
                "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden",
                "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand",
                "Togo", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkey",
                "Turkmenistan","Tuvalu", "Uganda", "Ukraine", "United Arab Emirates",
                "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu",
                "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe"
            };
            */

            return new SelectList(paises);
        }

        public static SelectList EstadoPedidos()
        {
            var estados = new List<string>()
            {
                "Por revisar",
                "Pre-aceptado",
                "En revisión",
                "Aceptado",
                "En proceso",
                "Finalizado"
            };

            return new SelectList(estados);
        }

        public static SelectList EstadoPedidosFiltrados()
        {
            var estados = new List<string>()
            {
                "Todos",
                "Pre-aceptado",
                "En revisión",
                "Aceptado",
                "En proceso",
                // TODO: Quitar los finalizados y hacer otra vista
                "Finalizado"
            };

            return new SelectList(estados);
        }

        public static bool UniqueValidation(DbUpdateException ex, string indexName)
        {
            var sqlException = ex.InnerException as SqlException;
            return sqlException != null &&
                sqlException.Number == 2601 &&
                sqlException.Message.Contains(indexName);
        }

        public static void ModelValidations(ModelStateDictionary modelState, ViewDataDictionary viewData)
        {
            foreach (var key in modelState.Keys)
            {
                var error = modelState[key].Errors.FirstOrDefault();
                if (error == null) continue;
                viewData["ErrorMessage"] = $"{key} {error.ErrorMessage}";
                return;
            }
        }
    }
}
