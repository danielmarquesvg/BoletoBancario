using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoletoNet;

namespace BoletosImplementados
{
    public class BoletoDados
    {

        bool flagCarne { get; set; }
        int quantidade { get; set; }

        string boletoCodigoDoBanco { get; set; }
        float boletoValor { get; set; }
        string boletoCarteira { get; set; }
        string boletoNossoNumero { get; set; }
        string boletoNumeroDoDocumento { get; set; }

        string dataDeVencimento { get; set; }
        string dataDoDocumento { get; set; }
        string dataDeProcessamento { get; set; }

        string cedenteCpfCNPJ { get; set; }
        string cedenteNome { get; set; }
        string cedenteConta { get; set; }
        string cedenteAgencia { get; set; }
        string cedenteCodigo { get; set; }

        string sacadoCpfCnpj { get; set; }
        string sacadoNome { get; set; }
        string sacadoEndereco { get; set; }
        string sacadoBairro { get; set; }
        string sacadoCidade { get; set; }
        string sacadoCEP { get; set; }
        string sacadoUF { get; set; }

        string instrucao { get; set; }

        public BoletoDados(bool flagCarne, int quantidade, string boletoCodigoDoBanco, float boletoValor,
            string boletoCarteira, string boletoNossoNumero, string boletoNumeroDoDocumento, 
            string dataDeVencimento, string dataDoDocumento, string dataDeProcessamento, string cedenteCpfCNPJ,
            string cedenteNome, string cedenteConta, string cedenteAgencia, string cedenteCodigo,
            string sacadoCpfCnpj, string sacadoNome, string sacadoEndereco, string sacadoBairro,
            string sacadoCidade, string sacadoCEP, string sacadoUF, string instrucao)
        {
            this.flagCarne = flagCarne;
            this.quantidade = quantidade;
            this.boletoCodigoDoBanco = boletoCodigoDoBanco;
            this.boletoValor = boletoValor;
            this.boletoCarteira = boletoCarteira;
            this.boletoNossoNumero = boletoNossoNumero;
            this.boletoNumeroDoDocumento = boletoNumeroDoDocumento;
            this.dataDeVencimento = dataDeVencimento;
            this.dataDoDocumento = dataDoDocumento;
            this.dataDeProcessamento = dataDeProcessamento;
            this.cedenteCpfCNPJ = cedenteCpfCNPJ;
            this.cedenteNome = cedenteNome;
            this.cedenteAgencia = cedenteAgencia;
            this.cedenteConta = cedenteConta;
            this.cedenteCodigo = cedenteCodigo;
            this.sacadoCpfCnpj = sacadoCpfCnpj;
            this.sacadoNome = sacadoNome;
            this.sacadoEndereco = sacadoEndereco;
            this.sacadoBairro = sacadoBairro;
            this.sacadoCidade = sacadoCidade;
            this.sacadoCEP = sacadoCEP;
            this.sacadoUF = sacadoUF;
            this.instrucao = instrucao;
        }

        public BoletoBancario montaBoleto(BoletoDados boletoDados)
        {

            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = short.Parse(boletoDados.boletoCodigoDoBanco);

            Cedente cedente = new Cedente(boletoDados.cedenteCpfCNPJ, boletoDados.cedenteNome,
                boletoDados.cedenteAgencia, boletoDados.cedenteConta);

            Boleto boleto = new Boleto(DateTime.Parse(boletoDados.dataDeVencimento),
                Convert.ToDecimal(boletoDados.boletoValor), boletoDados.boletoCarteira,
                boletoDados.boletoNossoNumero, cedente);

            boleto.NumeroDocumento = boletoDados.boletoNumeroDoDocumento;
            boleto.DataDocumento = DateTime.Parse(boletoDados.dataDoDocumento);
            boleto.DataProcessamento = DateTime.Parse(boletoDados.dataDeProcessamento);

            boleto.Sacado = new Sacado(boletoDados.sacadoCpfCnpj, boletoDados.sacadoNome);
            boleto.Sacado.Endereco.End = boletoDados.sacadoEndereco;
            boleto.Sacado.Endereco.Bairro = boletoDados.sacadoBairro;
            boleto.Sacado.Endereco.Cidade = boletoDados.sacadoCidade;
            boleto.Sacado.Endereco.CEP = boletoDados.sacadoCEP;
            boleto.Sacado.Endereco.UF = boletoDados.sacadoUF;

            boletoBancario.Boleto = boleto;
            boletoBancario.FormatoCarne = boletoDados.flagCarne;

            if (boletoBancario.CodigoBanco == (short)237) //Banco Bradesco
            {
                boletoBancario.MostrarContraApresentacaoNaDataVencimento = false;
                boletoBancario.MostrarCodigoCarteira = false;
                boletoBancario.MostrarComprovanteEntrega = true;
            }
            else
            {
                if(boletoBancario.CodigoBanco == (short)104) //Banco CAIXA
                {
                    EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
                    boleto.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
                    boletoBancario.MostrarComprovanteEntrega = true;
                }
                else
                {
                    if (boletoBancario.CodigoBanco == (short)033) //Banco SANTANDER
                    {
                        //Espécie Documento - [R] Recibo
                        boleto.EspecieDocumento = new EspecieDocumento_Santander("17");

                        boletoBancario.MostrarCodigoCarteira = true;
                        boletoBancario.MostrarComprovanteEntrega = true;
                    }
                    else
                    {
                        //Banco SICOOB
                        boletoBancario.MostrarCodigoCarteira = false;
                        boletoBancario.MostrarComprovanteEntrega = true;
                    }
                }
            }

            boletoBancario.Boleto.Valida();

            return boletoBancario;
        }

    }
}