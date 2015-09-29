using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BoletoNet;

namespace BoletoCAIXA
{
    public partial class WebFormBoletoSantander : System.Web.UI.Page
    {

        string html;

        protected void Page_Load(object sender, EventArgs e)
        {

            /*
             *  Datas do boleto
             */ 
            DateTime dataDeVencimento = new DateTime(2015, 09, 30);
            DateTime dataDoDocumeto = new DateTime(2015, 09, 24);
            DateTime DataDoProcessamento = new DateTime(2015, 09, 24);

            /*
             *  Construtor do boleto bancaário
             *  Código do Banco Santander = 033
             */ 
            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = (short)033;

            /*
             *  Construtor do Cedente 
             *  CNPJ, Nome do Cedente, Agencia do cedente, Conta do cedente
             */
            Cedente cedente = new Cedente("00.000.000/0000-00", "Nome do cedente", "2269", "130000946");
            cedente.Codigo = "1795082";

            /*
             *  Construtor do boleto
             *  Data de vencimento, Valor do Boleto, Carteira, Nosso Numero, Cedente
             */ 
            Boleto boleto = new Boleto(dataDeVencimento, 5.01m, "102", "566612457800", cedente);
            boleto.DataDocumento = dataDoDocumeto;
            boleto.DataProcessamento = DataDoProcessamento;

            #region Adiciona Instruções somente no Cedente
            IInstrucao instrucao = new Instrucao(33);
            instrucao.Descricao = "Não esqueça de fazer uma doação ao projeto - Cedente";
            cedente.Instrucoes.Add(instrucao);
            #endregion

            //NOSSO NÚMERO
            //############################################################################################################################
            //Número adotado e controlado pelo Cliente, para identificar o título de cobrança.
            //Informação utilizada pelos Bancos para referenciar a identificação do documento objeto de cobrança.
            //Poderá conter número da duplicata, no caso de cobrança de duplicatas, número de apólice, no caso de cobrança de seguros, etc.
            //Esse campo é devolvido no arquivo retorno.
            boleto.NumeroDocumento = "0282033";

            boleto.Sacado = new Sacado("000.000.000-00", "Nome do Sacado");
            boleto.Sacado.Endereco.End = "Rua do Sacado, número da residência, complemento";
            boleto.Sacado.Endereco.Bairro = "Bairro do sacado";
            boleto.Sacado.Endereco.Cidade = "Cidade do sacado";
            boleto.Sacado.Endereco.CEP = "58100-000";
            boleto.Sacado.Endereco.UF = "RJ";

            #region Adiciona Instruções somente no Sacado
            IInstrucao instrucaoSacado = new Instrucao(33);
            instrucaoSacado.Descricao = "Instrução do sacado";
            boleto.Sacado.Instrucoes.Add(instrucaoSacado);
            #endregion

            #region Adiciona Instruções comuns - Cedente e Sacado
            IInstrucao instrucaoComum = new Instrucao(33);
            instrucaoComum.Descricao = "Instrução Comum - Cedente/Sacado";
            boleto.Instrucoes.Add(instrucaoComum);
            #endregion


            //Espécie Documento - [R] Recibo
            boleto.EspecieDocumento = new EspecieDocumento_Santander("17");

            boletoBancario.Boleto = boleto;
            boletoBancario.MostrarCodigoCarteira = true;
            boletoBancario.MostrarComprovanteEntrega = true;
            boletoBancario.Boleto.Valida();

            Panel1.Controls.Add(boletoBancario);

            /*
            string linhaDigitavel = "linha digitavel = " + boleto.CodigoBarra.LinhaDigitavel.ToString();
            LabelLinhaDigitavel.Text = linhaDigitavel;

            string codigo = "Codigo de barra = " + boleto.CodigoBarra.Codigo.ToString();
            LabelCodigo.Text = codigo;

            //boletoBancario.MostrarComprovanteEntrega = (Request.Url.Query == "?show");
            */
        }
    }
}