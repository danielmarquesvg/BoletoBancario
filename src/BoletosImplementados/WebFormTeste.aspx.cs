using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoletosImplementados
{
    public partial class WebFormTeste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            bool flagCarne = false;
            int quantidade = 1;

            string boletoCodigoDoBanco = "104";
            float boletoValor = 666;
            string boletoCarteira = "SR";
            string boletoNossoNumero = "24000000000000002";
            string boletoNumeroDoDocumento = "0000002";

            string dataDeVencimento = "30/10/2015";
            string dataDoDocumento = "05/10/2015";
            string dataDeProcessamento = "05/10/2015";

            string cedenteCpfCNPJ = "17.405.814/0001-09";
            string cedenteNome = "Daniel";
            string cedenteConta = "1234";
            string cedenteAgencia = "12345";
            string cedenteCodigo = "377306";

            string sacadoCpfCnpj = "123.123.123-00";
            string sacadoNome = "Nome do sacado";
            string sacadoEndereco = "rua do sacado";
            string sacadoBairro = "Catolé";
            string sacadoCidade = "Campina Grande";
            string sacadoCEP = "58100-000";
            string sacadoUF = "PB";

            string instrucao = "";

            BoletoDados boletoDados = new BoletoDados(flagCarne, quantidade, boletoCodigoDoBanco, boletoValor,
                boletoCarteira, boletoNossoNumero, boletoNumeroDoDocumento, dataDeVencimento, dataDoDocumento,
                dataDeProcessamento, cedenteCpfCNPJ, cedenteNome, cedenteConta, cedenteAgencia, cedenteCodigo,
                sacadoCpfCnpj, sacadoNome, sacadoEndereco, sacadoBairro, sacadoCidade, sacadoCEP, sacadoUF,
                instrucao);

            
            Panel1.Controls.Add(boletoDados.montaBoleto(boletoDados));

        }
    }
}