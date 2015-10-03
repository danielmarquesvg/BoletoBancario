using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BoletoNet;

namespace BoletoCAIXA
{
    public partial class WebFormBoletoSicoob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

             int quantidadeDeParcelas = 4;
            bool flagCarne = true;

            if (flagCarne == false)
            {

                /*
                *  Datas do boleto
                */
                DateTime dataDeVencimento = new DateTime(2015, 09, 30);
                DateTime dataDoDocumeto = new DateTime(2015, 09, 24);
                DateTime DataDoProcessamento = new DateTime(2015, 09, 24);

                /*
                *  Construtor do boleto bancaário
                *  Código do Banco Sicoob = 756
                */
                BoletoBancario boletoBancario = new BoletoBancario();
                boletoBancario.CodigoBanco = (short)756;

                /*
                *  Construtor do Cedente 
                *  CNPJ, Nome do Cedente, Agencia do cedente, Conta do cedente, Digito da conta do cedente
                */
                Cedente cedente = new Cedente("00.000.000/0000-00", "Nome do cedente", "3154", "3333");
                cedente.Codigo = "193593";
                cedente.DigitoCedente = 7;
                //cedente.Carteira = "4361";

                /*
                 *  Construtor do boleto
                 *  Data de vencimento, Valor do Boleto, Carteira, Nosso Numero, Cedente
                 */
                Boleto boleto = new Boleto(dataDeVencimento, 5.02m, "1", "12345678900234567", cedente);
                boleto.NumeroDocumento = "2745";
                boleto.DataProcessamento = DataDoProcessamento;
                boleto.DataDocumento = dataDoDocumeto;

                boleto.Sacado = new Sacado("000.000.000-00", "Nome do Sacado ");
                boleto.Sacado.Endereco.End = "Endereço do sacado";
                boleto.Sacado.Endereco.Bairro = "Bairro do sacado";
                boleto.Sacado.Endereco.Cidade = "Cidade do Sacado";
                boleto.Sacado.Endereco.CEP = "00000000";
                boleto.Sacado.Endereco.UF = "UF";

                Instrucao_Sicoob instruçãoSicoob = new Instrucao_Sicoob();
                instruçãoSicoob.Descricao += " após " + instruçãoSicoob.QuantidadeDias.ToString() + " dias corridos do vencimento.";
                boleto.Instrucoes.Add(instruçãoSicoob); //"Não Receber após o vencimento");

                Instrucao i = new Instrucao(237);
                i.Descricao = "Nova Instrução";
                boleto.Instrucoes.Add(i);

                boletoBancario.Boleto = boleto;
                boletoBancario.MostrarCodigoCarteira = false;
                boletoBancario.MostrarComprovanteEntrega = true;
                boletoBancario.FormatoCarne = false;
                boletoBancario.Boleto.Valida();

                Panel1.Controls.Add(boletoBancario);

            } else {

                BoletoBancario[] arrayDeBoletos = new BoletoBancario[quantidadeDeParcelas];
                DateTime dataDeVencimento = new DateTime(2015, 09, 30);

                for (int j = 0; j < arrayDeBoletos.Length; j++)
                {

                    DateTime dataDoDocumeto = new DateTime(2015, 09, 24);
                    DateTime DataDoProcessamento = new DateTime(2015, 09, 24);

                    /*
                    *  Construtor do boleto bancaário
                    *  Código do Banco Sicoob = 756
                    */
                    BoletoBancario boletoBancario = new BoletoBancario();
                    boletoBancario.CodigoBanco = (short)756;

                    /*
                    *  Construtor do Cedente 
                    *  CNPJ, Nome do Cedente, Agencia do cedente, Conta do cedente, Digito da conta do cedente
                    */
                    Cedente cedente = new Cedente("00.000.000/0000-00", "Nome do cedente", "3154", "3333");
                    cedente.Codigo = "193593";
                    cedente.DigitoCedente = 7;
                    //cedente.Carteira = "4361";

                    /*
                     *  Construtor do boleto
                     *  Data de vencimento, Valor do Boleto, Carteira, Nosso Numero, Cedente
                     */
                    Boleto boleto = new Boleto(dataDeVencimento, 5.02m, "1", "12345678900234567", cedente);
                    boleto.NumeroDocumento = "2745";
                    boleto.DataProcessamento = DataDoProcessamento;
                    boleto.DataDocumento = dataDoDocumeto;

                    boleto.Sacado = new Sacado("000.000.000-00", "Nome do Sacado ");
                    boleto.Sacado.Endereco.End = "Endereço do sacado";
                    boleto.Sacado.Endereco.Bairro = "Bairro do sacado";
                    boleto.Sacado.Endereco.Cidade = "Cidade do Sacado";
                    boleto.Sacado.Endereco.CEP = "00000000";
                    boleto.Sacado.Endereco.UF = "UF";

                    Instrucao_Sicoob instruçãoSicoob = new Instrucao_Sicoob();
                    instruçãoSicoob.Descricao += " após " + instruçãoSicoob.QuantidadeDias.ToString() + " dias corridos do vencimento.";
                    boleto.Instrucoes.Add(instruçãoSicoob); //"Não Receber após o vencimento");

                    Instrucao i = new Instrucao(237);
                    i.Descricao = "Nova Instrução";
                    boleto.Instrucoes.Add(i);

                    boletoBancario.Boleto = boleto;
                    boletoBancario.MostrarCodigoCarteira = false;
                    boletoBancario.MostrarComprovanteEntrega = true;
                    boletoBancario.FormatoCarne = true;
                    boletoBancario.Boleto.Valida();

                    arrayDeBoletos[j] = boletoBancario;
                    dataDeVencimento = dataDeVencimento.AddMonths(1);

                }

                for (int k = 0; k < arrayDeBoletos.Length; k++)
                {
                    Panel1.Controls.Add(arrayDeBoletos[k]);
                }

            }
        }
    }
}