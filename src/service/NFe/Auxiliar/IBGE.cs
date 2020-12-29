using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFe.Auxiliar
{
    public class IBGE
    {
        public static string RetornaSiglaUF(string cUF)
        {
            int codigoUF = 0;
            if (int.TryParse(cUF, out codigoUF))
            {
                //Retorna sigla
                return RetornaSiglaUF(codigoUF);
            }

            //Caso não possa converter, retorna vazio
            return string.Empty;
        }

        public static string RetornaSiglaUF(int cUF)
        {
            string strSigla = string.Empty;

            switch (cUF)
            {
                case 11:
                    strSigla = "RO";
                    break;

                case 12:
                    strSigla = "AC";
                    break;

                case 13:
                    strSigla = "AM";
                    break;

                case 14:
                    strSigla = "RR";
                    break;

                case 15:
                    strSigla = "PA";
                    break;

                case 16:
                    strSigla = "AP";
                    break;

                case 17:
                    strSigla = "TO";
                    break;

                case 21:
                    strSigla = "MA";
                    break;

                case 22:
                    strSigla = "PI";
                    break;

                case 23:
                    strSigla = "CE";
                    break;

                case 24:
                    strSigla = "RN";
                    break;

                case 25:
                    strSigla = "PB";
                    break;

                case 26:
                    strSigla = "PE";
                    break;

                case 27:
                    strSigla = "AL";
                    break;

                case 28:
                    strSigla = "SE";
                    break;

                case 29:
                    strSigla = "BA";
                    break;

                case 31:
                    strSigla = "MG";
                    break;

                case 32:
                    strSigla = "ES";
                    break;

                case 33:
                    strSigla = "RJ";
                    break;

                case 35:
                    strSigla = "SP";
                    break;

                case 41:
                    strSigla = "PR";
                    break;

                case 42:
                    strSigla = "SC";
                    break;

                case 43:
                    strSigla = "RS";
                    break;

                case 50:
                    strSigla = "MS";
                    break;

                case 51:
                    strSigla = "MT";
                    break;

                case 52:
                    strSigla = "GO";
                    break;

                case 53:
                    strSigla = "DF";
                    break;

                case 99:
                    strSigla = "EX";
                    break;

                default:
                    break;
            }

            return strSigla;
        }

        public static string RetornaCodigoUF(string siglaUF)
        {
            string strCodigo = string.Empty;

            switch (siglaUF)
            {
                case "RO":
                    strCodigo = "11";
                    break;

                case "AC":
                    strCodigo = "12";
                    break;

                case "AM":
                    strCodigo = "13";
                    break;

                case "RR":
                    strCodigo = "14";
                    break;

                case "PA":
                    strCodigo = "15";
                    break;

                case "AP":
                    strCodigo = "16";
                    break;

                case "TO":
                    strCodigo = "17";
                    break;

                case "MA":
                    strCodigo = "21";
                    break;

                case "PI":
                    strCodigo = "22";
                    break;

                case "CE":
                    strCodigo = "23";
                    break;

                case "RN":
                    strCodigo = "24";
                    break;

                case "PB":
                    strCodigo = "25";
                    break;

                case "PE":
                    strCodigo = "26";
                    break;

                case "AL":
                    strCodigo = "27";
                    break;

                case "SE":
                    strCodigo = "28";
                    break;

                case "BA":
                    strCodigo = "29";
                    break;

                case "MG":
                    strCodigo = "31";
                    break;

                case "ES":
                    strCodigo = "32";
                    break;

                case "RJ":
                    strCodigo = "33";
                    break;

                case "SP":
                    strCodigo = "35";
                    break;

                case "PR":
                    strCodigo = "41";
                    break;

                case "SC":
                    strCodigo = "42";
                    break;

                case "RS":
                    strCodigo = "43";
                    break;

                case "MS":
                    strCodigo = "50";
                    break;

                case "MT":
                    strCodigo = "51";
                    break;

                case "GO":
                    strCodigo = "52";
                    break;

                case "DF":
                    strCodigo = "53";
                    break;

                case "EX":
                    strCodigo = "99";
                    break;

                default:
                    break;
            }

            return strCodigo;
        }

        public static string RetornaNomeUF(string siglaUF)
        {
            string nome = string.Empty;

            switch (siglaUF)
            {
                case "AC":
                    nome = "Acre";
                    break;

                case "AL":
                    nome = "Alagoas";
                    break;

                case "AP":
                    nome = "Amapá";
                    break;

                case "AM":
                    nome = "Amazonas";
                    break;

                case "BA":
                    nome = "Bahia";
                    break;

                case "CE":
                    nome = "Ceará";
                    break;

                case "DF":
                    nome = "Distrito Federal";
                    break;

                case "ES":
                    nome = "Espírito Santo";
                    break;

                case "GO":
                    nome = "Goiás";
                    break;

                case "MA":
                    nome = "Maranhão";
                    break;

                case "MT":
                    nome = "Mato Grosso";
                    break;

                case "MS":
                    nome = "Mato Grosso do Sul";
                    break;

                case "MG":
                    nome = "Minas Gerais";
                    break;

                case "PA":
                    nome = "Pará";
                    break;

                case "PB":
                    nome = "Paraíba";
                    break;

                case "PR":
                    nome = "Paraná";
                    break;

                case "PE":
                    nome = "Pernambuco";
                    break;

                case "PI":
                    nome = "Piauí";
                    break;

                case "RJ":
                    nome = "Rio de Janeiro";
                    break;

                case "RN":
                    nome = "Rio Grande do Norte";
                    break;

                case "RS":
                    nome = "Rio Grande do Sul";
                    break;

                case "RO":
                    nome = "Rondônia";
                    break;

                case "RR":
                    nome = "Roraima";
                    break;

                case "SC":
                    nome = "Santa Catarina";
                    break;

                case "SP":
                    nome = "São Paulo";
                    break;

                case "SE":
                    nome = "Sergipe";
                    break;

                case "TO":
                    nome = "Tocantins";
                    break;

                case "EX":
                    nome = "Exterior";
                    break;

                default:
                    break;
            }

            return nome;
        }
    }
}
