using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BoletoNet;
using System.Text;

namespace BoletoCAIXA
{
    public partial class WebFormCarnet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<List<String>> listaAuxiliar = new List<List<String>>();
            List<String> minhaLista1 = new List<String>();
            List<String> minhaLista2 = new List<String>();
            List<String> minhaLista3 = new List<String>();
            
            //Dados dos boletos
            short codigoDoBanco = 104;

            DateTime dataDoDocumeto        = DateTime.Now;
            String dataDoDocumentoString   = dataDoDocumeto.ToString("dd/MM/YYYY");
            //DateTime dt                    = DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dataDoDocumentoString = Convert.ToDateTime("27/11/2007");

            DateTime dataDeVencimento     = DateTime.Now.AddDays(5);
            String dataDoVencimentoString = dataDoDocumeto.ToString("dd-MM-YYYY");

            DateTime dataDoProcessamento     = DateTime.Now;
            String dataDoProcessamentoString = dataDoDocumeto.ToString("dd-MM-YYYY");

            String cnpjDoCedente = "11.111.111/0001-10";
            String nomeDoCedente = "Nome do Cedente";
            String agenciaDoCedente = "1111";
            String contaDoCedente = "1111";
            String digitoDaConta = "4";
            String codigoDoCedente = "123456";

            decimal valorDoCarne = 5;
            String valorDoCarneString = Convert.ToString(valorDoCarne);

            String carteira = "SR";
            String codigoDoBancoNossoNumero = "24";
            String complementoNossoNumero = "000000000000001";
            String nossoNumero = codigoDoBancoNossoNumero + complementoNossoNumero;

            String cpfDoSacado = "111.111.111-11";
            String nomeDoSacado = "Nome do Sacado";

            String ruaDoSacado = "Rua do sacado";
            String bairroDoSacado = "Bairro do Sacado";
            String cidadeDoSacado = "Cidade do Sacado";
            String cepDoSacado = "58100-000";
            String estadoDoSacado = "PB";

            String numeroDocumento = "0000001";

            int numeroDeParcelas = 2;
            String numeroDeParcelasString = Convert.ToString(numeroDeParcelas);


            //Cria os dados do carne 1 
            minhaLista1.Add(dataDoDocumentoString);
            minhaLista1.Add(dataDoVencimentoString);
            minhaLista1.Add(dataDoProcessamentoString);
            minhaLista1.Add(cnpjDoCedente);
            minhaLista1.Add(nomeDoCedente);
            minhaLista1.Add(agenciaDoCedente);
            minhaLista1.Add(contaDoCedente);
            minhaLista1.Add(digitoDaConta);
            minhaLista1.Add(valorDoCarneString);
            minhaLista1.Add(carteira);
            minhaLista1.Add(nossoNumero);
            minhaLista1.Add(cpfDoSacado);
            minhaLista1.Add(nomeDoSacado);
            minhaLista1.Add(ruaDoSacado);
            minhaLista1.Add(bairroDoSacado);
            minhaLista1.Add(cidadeDoSacado);
            minhaLista1.Add(cepDoSacado);
            minhaLista1.Add(estadoDoSacado);
            minhaLista1.Add(numeroDocumento);

            //Cria os dados do carne 2
            minhaLista2.Add(dataDoDocumentoString);
            minhaLista2.Add(dataDoVencimentoString);
            minhaLista2.Add(dataDoProcessamentoString);
            minhaLista2.Add(cnpjDoCedente);
            minhaLista2.Add(nomeDoCedente);
            minhaLista2.Add(agenciaDoCedente);
            minhaLista2.Add(contaDoCedente);
            minhaLista2.Add(digitoDaConta);
            minhaLista2.Add(valorDoCarneString);
            minhaLista2.Add(carteira);
            minhaLista2.Add(nossoNumero);
            minhaLista2.Add(cpfDoSacado);
            minhaLista2.Add(nomeDoSacado);
            minhaLista2.Add(ruaDoSacado);
            minhaLista2.Add(bairroDoSacado);
            minhaLista2.Add(cidadeDoSacado);
            minhaLista2.Add(cepDoSacado);
            minhaLista2.Add(estadoDoSacado);
            minhaLista2.Add(numeroDocumento);

            //Cria os dados do carne 2
            minhaLista3.Add(dataDoDocumentoString);
            minhaLista3.Add(dataDoVencimentoString);
            minhaLista3.Add(dataDoProcessamentoString);
            minhaLista3.Add(cnpjDoCedente);
            minhaLista3.Add(nomeDoCedente);
            minhaLista3.Add(agenciaDoCedente);
            minhaLista3.Add(contaDoCedente);
            minhaLista3.Add(digitoDaConta);
            minhaLista3.Add(valorDoCarneString);
            minhaLista3.Add(carteira);
            minhaLista3.Add(nossoNumero);
            minhaLista3.Add(cpfDoSacado);
            minhaLista3.Add(nomeDoSacado);
            minhaLista3.Add(ruaDoSacado);
            minhaLista3.Add(bairroDoSacado);
            minhaLista3.Add(cidadeDoSacado);
            minhaLista3.Add(cepDoSacado);
            minhaLista3.Add(estadoDoSacado);
            minhaLista3.Add(numeroDocumento);

            //Adiciona as listas com os dados na lista principal
            listaAuxiliar.Add(minhaLista1);
            listaAuxiliar.Add(minhaLista2);
            listaAuxiliar.Add(minhaLista3);
            

            for(int i=0; i<listaAuxiliar.Count; i++)
            {
                //Cria boleto
                BoletoBancario boletoBancario = new BoletoBancario();
                boletoBancario.CodigoBanco = codigoDoBanco;
            
                //TODO: Iniciar a criacao dos carnes a partir dos dados da lista auxiliar
                Cedente c = new Cedente(cnpjDoCedente, nomeDoCedente, agenciaDoCedente, contaDoCedente,digitoDaConta);

                c.Codigo = codigoDoCedente;

                Boleto boleto = new Boleto(dataDeVencimento, valorDoCarne, carteira, nossoNumero, c);
                boleto.DataDocumento = dataDoDocumeto;
                boleto.DataProcessamento = dataDoProcessamento;

                boleto.Sacado = new Sacado(cpfDoSacado, nomeDoSacado);
                boleto.Sacado.Endereco.End = ruaDoSacado;
                boleto.Sacado.Endereco.Bairro = bairroDoSacado;
                boleto.Sacado.Endereco.Cidade = cidadeDoSacado;
                boleto.Sacado.Endereco.CEP = cepDoSacado;
                boleto.Sacado.Endereco.UF = estadoDoSacado;

                //Adiciona as instruções ao boleto
                /*
                #region Instruções
                        Instrucao_Caixa item;
                        //ImportanciaporDiaDesconto
                        item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.Multa, Convert.ToDecimal(0.40));
                        boleto.Instrucoes.Add(item);
                        item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.JurosdeMora, Convert.ToDecimal(0.01));
                        boleto.Instrucoes.Add(item);
                        item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.NaoReceberAposNDias, 90);
                        boleto.Instrucoes.Add(item);
                        #endregion Instruções
                */
            
                EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
                boleto.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
                
                boleto.NumeroDocumento = numeroDocumento;
                boleto.DataProcessamento = dataDoProcessamento;
                boleto.DataDocumento = dataDoDocumeto;
                boletoBancario.Boleto = boleto; 
                boletoBancario.MostrarComprovanteEntrega = true;
                boletoBancario.FormatoCarne = true;
                
                string montaHTML = boletoBancario.MontaHtml();

                boletoBancario.Boleto.Valida();
                Panel2.Controls.Add(boletoBancario);
                
            }//fim do for (i)
        }
            //Literal1.Text = htmlBoleto;
            
            /*
            //Requisições do Formulário

            string sacadoNome = Request.Form["sacadoNome"];
            string sacadoCPFCNPJ = Request.Form["sacadoCPFCNPJ"];
            string sacadoEnderecoRua = Request.Form["sacadoEnderecoRua"];
            string sacadoEnderecoNumero = Request.Form["sacadoEnderecoNumero"];
            string sacadoEnderecoComplemento = Request.Form["sacadoEnderecoComplemento"];
            string sacadoEnderecoBairro = Request.Form["sacadoEnderecoBairro"];
            string sacadoEstadoUF = Request.Form["sacadoEstadoUF"];
            string sacadoCidade = Request.Form["sacadoCidade"];
            string sacadoCEP = Request.Form["sacadoCEP"];

            string cedenteNome = Request.Form["cedenteNome"];
            string cedenteCodigo = Request.Form["cedenteCodigo"];
            string cedenteNossoNumeroBoleto = Request.Form["cedenteNossoNumeroBoleto"];
            string cedenteCPFCNPJ = Request.Form["cedenteCPFCNPJ"];
            string cedenteAgencia = Request.Form["cedenteAgencia"];
            string cedenteConta = Request.Form["cedenteConta"];
            string cedenteDigito = Request.Form["cedenteDigito"];

            string boletoValor = Request.Form["boletoValor"];
            string boletoVencimento = Request.Form["boletoVencimento"];
            string boletoNumeroDoDocumento = Request.Form["boletoNumeroDoDocumento"];
            string boletoCarteira = Request.Form["boletoCarteira"];
            string boletoDataDoDocumento = Request.Form["boletoDataDoDocumento"];
            string boletoDataDeProcessamento = Request.Form["boletoDataDeProcessamento"];
            string boletoCodigoDoBanco = Request.Form["boletoCodigoDoBanco"];
            

            //Instanciação e inicialização do objeto Cedente
            Cedente cedente = new Cedente(cedenteCPFCNPJ, cedenteNome, cedenteAgencia, cedenteConta, cedenteDigito);
            cedente.Codigo = cedenteCodigo;
            
            //Instanciação e inicialização do objeto Boleto
            Boleto boleto = new Boleto(Convert.ToDateTime(boletoVencimento), Convert.ToDecimal(boletoValor), boletoCarteira, cedenteNossoNumeroBoleto, cedente);
            boleto.NumeroDocumento = boletoNumeroDoDocumento;
            boleto.DataDocumento = (Convert.ToDateTime(boletoDataDoDocumento));
            boleto.DataProcessamento = (Convert.ToDateTime(boletoDataDeProcessamento));
            boleto.LocalPagamento = "PREFERENCIALMENTE NAS CASAS LOTÉRICAS ATÉ O VALOR LIMITE";
            
            
            //Instanciação e Inicialização do objeto Sacado
            Sacado sacado = new Sacado(sacadoCPFCNPJ, sacadoNome);
            boleto.Sacado = sacado;
            boleto.Sacado.Endereco.End = sacadoEnderecoRua + ", " + sacadoEnderecoNumero+", "+sacadoEnderecoComplemento;
            boleto.Sacado.Endereco.Bairro = sacadoEnderecoBairro;
            boleto.Sacado.Endereco.Cidade = sacadoCidade;
            boleto.Sacado.Endereco.CEP = sacadoCEP;
            boleto.Sacado.Endereco.UF = sacadoEstadoUF;
            

            Instrucao_Caixa instrucaoCaixa = new Instrucao_Caixa();
            instrucaoCaixa.Descricao = "ATE O VENCIMENTO PAGAVEL NAS CASAS LOTERICAS," +
                "CORRESPONDENTES CAIXA AQUI OU NA REDE BANCARIA." +
                "NAO RECEBER APOS O VENCIMENTO";
            boleto.Instrucoes.Add(instrucaoCaixa);
            EspecieDocumento_Caixa especieDocumentoCaixa = new EspecieDocumento_Caixa(" ");
            boleto.EspecieDocumento = especieDocumentoCaixa;
            

            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = short.Parse(boletoCodigoDoBanco);

            boletoBancario.GeraImagemCodigoBarras(boleto);

            boletoBancario.Boleto = boleto;
            boletoBancario.MostrarCodigoCarteira = true;
            boletoBancario.Boleto.Valida();
            //string barrinhas = boleto.CodigoBarra.Codigo.ToString();
            //boletoBancario.GeraImagemCodigoBarras(boleto);
            boletoBancario.MostrarComprovanteEntrega = true;
            Panel1.Controls.Add(boletoBancario);
            */
    }
}
