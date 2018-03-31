using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public class Funcoes
    {
        public static bool ValidarSenha(string senha)
        {
            //Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@#+-=*$%]{8,8}$"); 
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[^+*=<>""':;\\]{8,8}$");
            //Regex regex = new Regex(@"((?=.*\d)(?=.*[a-zA-Z])(?=.*[@#$%])[a-zA-Z0-9@$$%]{8,8})");
            //Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            Match match = regex.Match(senha);

            return match.Success;
        }

        public static bool ValidaMD5(string senha)
        {
            Regex isMD5 = new Regex(@"^([a-fA-F0-9]){32}$");
            return isMD5.IsMatch(senha);
        }

        public static bool ValidaBase64(string senha)
        {
            Regex regex = new Regex(@"/^[a-zA-Z0-9\/\r\n+]*={0,2}$/");
            Match match = regex.Match(senha);

            return match.Success;
        }

        public static string ConverteBase64ToString(string dado)
        {
            if (dado == null)
            {
                return null;
            }
            else if (dado == "")
            {
                return "";
            }
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(dado));
        }

        public static int UltimoDiaMes(DateTime data)
        {
            return DateTime.DaysInMonth(data.Year, data.Month);
        }

        public static bool ValidaCPF(string value)
        {
            if (value == null)
                return false;

            string valor = value.ToString().Replace(".", ""); valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            //bool igual = true;

            //for (int i = 1; i < 11 && igual; i++)
            //    if (valor[i] != valor[0])
            //        igual = false;

            //if (igual || valor == "12345678909")
            //    return false; 
            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false; soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;
            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (
                         resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna o Id do estado.
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        #region Código do estado
        /*public static dynamic RetornaCodigoEstado(string uf)
        {
            if ((uf == null) || (uf == "") || (uf == "0"))
            {
                return 0;
            }

            string ufId = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Global.ServidorAPIDominio + "api/ListarEstadoFiltrado?uf=" + uf);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                ufId = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            dynamic retorno = JsonConvert.DeserializeObject(ufId);

            return retorno;
        }*/
        #endregion

        /// <summary>
        /// Retorna o Id da cidade.
        /// </summary>
        /// <param name="uf"></param>
        /// <param name="cidade"></param>
        /// <returns></returns>
        #region Código da cidade
        /*public static dynamic RetornaCodigoCidade(int? uf, string cidade)
        {
            if ((uf == null) || (cidade == null))
            {
                return 0;
            }
            else if ((uf == 0) || (cidade == "") || (cidade == "0"))
            {
                return 0;
            }
            string cidadeId = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Global.ServidorAPIDominio + "api/ListarCidadeFiltrado?estado=" + uf + "&cidade=" + cidade);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                cidadeId = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            dynamic retorno = JsonConvert.DeserializeObject(cidadeId);

            return retorno;
        }*/
        #endregion

        #region Nome do estado e nome da cidade
        /*public static dynamic RetornaEstadoCidade(int uf, int cidade)
        {
            dynamic retorno;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Global.ServidorAPIDominio + "api/ListarCidadeEstado?estado=" + uf + "&cidade=" + cidade);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                retorno = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            retorno = JsonConvert.DeserializeObject(retorno);

            return retorno;
        }*/
        #endregion

        /// <summary>
        /// Verifica se o email informado é válido.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidarEmail(string email)
        {

            Regex regExpEmail = new Regex("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$");
            Match match = regExpEmail.Match(email);

            return match.Success;
        }

        /// <summary>
        /// Validador de Cns http://geradorapp.com/api
        /// Login criado por Mário Vilela 
        ///  token de acesso: ca07f42e69bc273b39409a048d92b676
        ///  Endereço de e-mail:mario_vilela@lifesys.com.br
        ///  Senha:nefroweb
        /// </summary>
        /// <param name="cns">cns</param>
        /// <returns>bool</returns>
        public static bool ValidarCns(string cns)
        {
            dynamic retorno = new System.Dynamic.ExpandoObject();
            string url = "http://geradorapp.com/api/v1/cns/validate/" + cns + "?token=" + "ca07f42e69bc273b39409a048d92b676";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            retorno = (JsonConvert.DeserializeObject<dynamic>(readStream.ReadToEnd()));
            if (retorno != null)
            {
                return (retorno.data.message == "CNS Válido");
            }
            return false;
        }

        public static dynamic ObterInicioFimSemanaNoAno(DateTime data)
        {
            int numeroMenor = 0,
                numeroMaior = 6;

            List<dynamic> retorno = new List<dynamic>();
            DateTime dataInicio = data.AddDays(numeroMenor - data.DayOfWeek.GetHashCode());
            DateTime dataFim = data.AddDays(numeroMaior - data.DayOfWeek.GetHashCode());

            retorno.Add(dataInicio);
            retorno.Add(dataFim);

            return retorno;
        }

        /// <summary>
        /// Método que remove acentos.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        /*
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
        */
        /*public static byte[] ReadFile(string caminhoArquivo)
        {
            string arquivoDescompactado = string.Empty;
            byte[] stream = null;

            if (Path.GetExtension(caminhoArquivo).Equals(".gz"))
                arquivoDescompactado = LifesysCompression.Decompress(new FileInfo(caminhoArquivo));
            else
                arquivoDescompactado = caminhoArquivo;

            stream = System.IO.File.ReadAllBytes(arquivoDescompactado);

            return stream;
        }*/

        public static string RetornaDiaSemanaByData(DateTime data)
        {
            /*
             0 - Domingo
             1 - Segunda
             2 - Terça
             3 - Quarta
             4 - Quinta 
             5 - Sexta
             6 - Sabado
            */

            if (data.DayOfWeek == DayOfWeek.Monday)
                return "1";
            else if (data.DayOfWeek == DayOfWeek.Tuesday)
                return "2";
            else if (data.DayOfWeek == DayOfWeek.Wednesday)
                return "3";
            else if (data.DayOfWeek == DayOfWeek.Thursday)
                return "4";
            else if (data.DayOfWeek == DayOfWeek.Friday)
                return "5";
            else if (data.DayOfWeek == DayOfWeek.Saturday)
                return "6";
            else if (data.DayOfWeek == DayOfWeek.Sunday)
                return "0";
            else
                return string.Empty;
        }

        public static DayOfWeek RetornaDiaSemanaByDia(string dia)
        {
            /*
            0 - Domingo
            1 - Segunda
            2 - Terça
            3 - Quarta
            4 - Quinta 
            5 - Sexta
            6 - Sabado
            */

            if (dia.Equals("1"))
                return DayOfWeek.Monday;
            else if (dia.Equals("2"))
                return DayOfWeek.Tuesday;
            else if (dia.Equals("3"))
                return DayOfWeek.Wednesday;
            else if (dia.Equals("4"))
                return DayOfWeek.Thursday;
            else if (dia.Equals("5"))
                return DayOfWeek.Friday;
            else if (dia.Equals("6"))
                return DayOfWeek.Saturday;
            else if (dia.Equals("0"))
                return DayOfWeek.Sunday;
            else
                throw new Exception("Valor não aceito!");
        }
        public static string OnlyNumber(string s)
        {
            string sTexto = "";
            foreach (char c in s.ToArray())
                if ((int)c >= 48 && (int)c <= 57)
                    sTexto += c.ToString();
            return sTexto;
        }

        public static string MontarNumeroCartaoComMascara(string numeroCartao)
        {
            string numeroCartaoAux = string.Empty;
            for (int i = 0; i < numeroCartao.Length; i++)
            {
                if (i >= 4 && i <= 11)
                    numeroCartaoAux += "X";
                else
                    numeroCartaoAux += numeroCartao[i];
            }

            return numeroCartaoAux;
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string FormatTelefone(String telefone)
        {
            string retorno = String.Empty;
            string valorTelefone;
            int lenght = telefone.Length;

            if (lenght == 8)
            {
                valorTelefone = telefone.Substring(0, 0);
                valorTelefone += "(";
                valorTelefone += " ";
                valorTelefone += ")";
                valorTelefone += " ";
                valorTelefone += telefone.Substring(0, 4);
                valorTelefone += "-";
                valorTelefone += telefone.Substring(4, 4);
                telefone = valorTelefone;
                retorno = telefone;
            }
            if (lenght == 10)
            {
                valorTelefone = telefone.Substring(0, 0);
                valorTelefone += "(";
                valorTelefone += telefone.Substring(0, 2);
                valorTelefone += ")";
                valorTelefone += " ";
                valorTelefone += telefone.Substring(2, 4);
                valorTelefone += "-";
                valorTelefone += telefone.Substring(6, 4);
                telefone = valorTelefone;
                retorno = telefone;
            }
            if (lenght == 11)
            {
                valorTelefone = telefone.Substring(0, 0);
                valorTelefone += "(";
                valorTelefone += telefone.Substring(0, 2);
                valorTelefone += ")";
                valorTelefone += " ";
                valorTelefone += telefone.Substring(2, 5);
                valorTelefone += "-";
                valorTelefone += telefone.Substring(7, 4);
                telefone = valorTelefone;
                retorno = telefone;
            }
            return retorno;
        }

        /// <summary>
        /// Método responsável por converter uma string para CamelCase
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string CamelCase(string texto)
        {
            string retorno = Regex.Replace(texto.ToLower(), @"\b[a-z]", delegate (Match m)
            {
                return m.Value.ToUpper();
            });

            retorno = Regex.Replace(retorno, @"(\s(de|da|do|e)|\'[st])\b", m => m.Value.ToLower(), RegexOptions.IgnoreCase);

            return retorno;
        }

        /// <summary>
        /// Método responsável por validar se uma string possui apenas letras.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool OnlyLetters(string s)
        {
            return Regex.IsMatch(s, @"^[a-zA-Zà-üÀ-Ü'\s]+$");
        }
    }

}
