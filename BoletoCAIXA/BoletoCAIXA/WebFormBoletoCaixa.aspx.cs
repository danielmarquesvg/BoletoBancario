using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BoletoNet;

namespace BoletoCAIXA
{
    public partial class WebFormBoleto : System.Web.UI.Page
    {

        string html;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = (short)104;

            DateTime dataDeVencimento = new DateTime(2015, 09, 23);
            DateTime dataDoDocumeto = new DateTime(2015, 09, 23);
            DateTime DataDoProcessamento = new DateTime(2015, 09, 23);

            Cedente c = new Cedente("11.111.111/0001-10", "Nome do Cedente", "1423", "1330", "4");

            c.Codigo = "420147";


            Boleto boleto = new Boleto(dataDeVencimento, 5.00m, "SR", "24000000000000001", c);
            boleto.DataDocumento = dataDoDocumeto;
            boleto.DataProcessamento = DataDoProcessamento;

            boleto.Sacado = new Sacado("111.111.111-11", "Nome do Sacado");
            boleto.Sacado.Endereco.End = "Rua, número, complemento do sacado";
            boleto.Sacado.Endereco.Bairro = "Bairro do sacado";
            boleto.Sacado.Endereco.Cidade = "Cidade do Sacado";
            boleto.Sacado.Endereco.CEP = "58100-000";
            boleto.Sacado.Endereco.UF = "SP";

            //Adiciona as instruções ao boleto
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

            EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
            boleto.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
            boleto.NumeroDocumento = "0000001";
            boleto.DataProcessamento = DateTime.Now;
            boleto.DataDocumento = DateTime.Now;

            boletoBancario.Boleto = boleto; 
            boletoBancario.MostrarComprovanteEntrega = true;
            boletoBancario.FormatoCarne = false;

            boletoBancario.Boleto.Valida();

            html += boletoBancario.MontaHtml();
            

            Panel1.Controls.Add(boletoBancario);

            string linhaDigitavel = "linha digitavel = "+boleto.CodigoBarra.LinhaDigitavel.ToString();
            LabelLinhaDigitavel.Text = linhaDigitavel;

            string codigo = "Codigo de barra = "+boleto.CodigoBarra.Codigo.ToString();
            LabelCodigo.Text = codigo;

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
}