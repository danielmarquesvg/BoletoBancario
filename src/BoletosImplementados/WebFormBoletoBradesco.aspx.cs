using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BoletoNet;

namespace BoletoCAIXA
{
    public partial class WebFormBoletoBradesco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            *  Datas do boleto
            */
            DateTime dataDeVencimento = new DateTime(2015, 09, 30);
            DateTime dataDoDocumeto = new DateTime(2015, 09, 24);
            DateTime DataDoProcessamento = new DateTime(2015, 09, 24);

            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = (short)237;

            Cedente cedente = new Cedente("00.000.000/0000-00", "Empresa Teste", "2413", "1232916"); ;
            cedente.Codigo = "13000";

            //Carteiras 
            Boleto boleto = new Boleto(dataDeVencimento, 5.01m, "06", "12970171092", cedente);
            boleto.NumeroDocumento = "970171092";
            boleto.DataDocumento = dataDoDocumeto;
            boleto.DataProcessamento = DataDoProcessamento;

            boleto.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            boleto.Sacado.Endereco.End = "Endereço do seu Cliente ";
            boleto.Sacado.Endereco.Bairro = "Bairro";
            boleto.Sacado.Endereco.Cidade = "Cidade";
            boleto.Sacado.Endereco.CEP = "00000000";
            boleto.Sacado.Endereco.UF = "UF";

            Instrucao_Bradesco item = new Instrucao_Bradesco(9, 5);
            item.Descricao += " após " + item.QuantidadeDias.ToString() + " dias corridos do vencimento.";
            boleto.Instrucoes.Add(item); //"Não Receber após o vencimento");

            Instrucao i = new Instrucao(237);
            i.Descricao = "Nova Instrução";
            boleto.Instrucoes.Add(i);

            /* 
             * A data de vencimento não é usada
             * Usado para mostrar no lugar da data de vencimento o termo "Contra Apresentação";
             * Usado na carteira 06
             */
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = true;

            boletoBancario.Boleto = boleto;
            boletoBancario.MostrarContraApresentacaoNaDataVencimento = false;
            boletoBancario.MostrarCodigoCarteira = false;
            boletoBancario.MostrarComprovanteEntrega = true;

            

            boletoBancario.FormatoCarne = false;
            boletoBancario.Boleto.Valida();

            Panel1.Controls.Add(boletoBancario);

            /*
            string linhaDigitavel = "linha digitavel = " + boleto.CodigoBarra.LinhaDigitavel.ToString();
            LabelLinhaDigitavel.Text = linhaDigitavel;

            string codigo = "Codigo de barra = " + boleto.CodigoBarra.Codigo.ToString();
            LabelCodigo.Text = codigo;
            */
        }
    }
}