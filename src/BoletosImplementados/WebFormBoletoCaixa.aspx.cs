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

        protected void Page_Load(object sender, EventArgs e)
        {
            
            int quantidadeDeParcelas = 4;
            bool flagCarne = true;

            if (flagCarne == false)
            {

                BoletoBancario boletoBancario = new BoletoBancario();
                boletoBancario.CodigoBanco = (short)104;

                DateTime dataDeVencimento = new DateTime(2015, 09, 30);
                DateTime dataDoDocumeto = new DateTime(2015, 09, 29);
                DateTime DataDoProcessamento = new DateTime(2015, 09, 29);

                Cedente c = new Cedente("17.405.814/0001-09", "Instituto Suporte Educacional Treinamento Especializado", "0773", "997", "9");

                c.Codigo = "377306";


                Boleto boleto = new Boleto(dataDeVencimento, 5.01m, "SR", "24000000000000002", c);
                boleto.DataDocumento = dataDoDocumeto;
                boleto.DataProcessamento = DataDoProcessamento;

                boleto.Sacado = new Sacado("111.111.111-11", "José");
                boleto.Sacado.Endereco.End = "Rua Floriano Peixoto, S/N";
                boleto.Sacado.Endereco.Bairro = "Centro";
                boleto.Sacado.Endereco.Cidade = "Campina Grande";
                boleto.Sacado.Endereco.CEP = "58100-000";
                boleto.Sacado.Endereco.UF = "PB";

                /*
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
                */

                EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
                boleto.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
                boleto.NumeroDocumento = "0000002";
                boleto.DataProcessamento = DateTime.Now;
                boleto.DataDocumento = DateTime.Now;

                boletoBancario.Boleto = boleto;
                boletoBancario.MostrarComprovanteEntrega = true;
                boletoBancario.FormatoCarne = false;

                boletoBancario.Boleto.Valida();

                Panel1.Controls.Add(boletoBancario);

            }
            else
            {

                BoletoBancario[] arrayDeBoletos = new BoletoBancario[quantidadeDeParcelas];
                DateTime dataDeVencimento = new DateTime(2015, 09, 30);

                for (int j = 0; j < arrayDeBoletos.Length; j++)
                {

                    BoletoBancario boletoBancario = new BoletoBancario();
                    boletoBancario.CodigoBanco = (short)104;

                    DateTime dataDoDocumeto = new DateTime(2015, 09, 29);
                    DateTime DataDoProcessamento = new DateTime(2015, 09, 29);

                    Cedente c = new Cedente("17.405.814/0001-09", "Instituto Suporte Educacional Treinamento Especializado", "0773", "997", "9");

                    c.Codigo = "377306";


                    Boleto boleto = new Boleto(dataDeVencimento, 5.01m, "SR", "24000000000000002", c);
                    boleto.DataDocumento = dataDoDocumeto;
                    boleto.DataProcessamento = DataDoProcessamento;

                    boleto.Sacado = new Sacado("111.111.111-11", "José");
                    boleto.Sacado.Endereco.End = "Rua Floriano Peixoto, S/N";
                    boleto.Sacado.Endereco.Bairro = "Centro";
                    boleto.Sacado.Endereco.Cidade = "Campina Grande";
                    boleto.Sacado.Endereco.CEP = "58100-000";
                    boleto.Sacado.Endereco.UF = "PB";

                    /*
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
                    */

                    EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
                    boleto.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
                    boleto.NumeroDocumento = "0000002";
                    boleto.DataProcessamento = DateTime.Now;
                    boleto.DataDocumento = DateTime.Now;

                    boletoBancario.Boleto = boleto;
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