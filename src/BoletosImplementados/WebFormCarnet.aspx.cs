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
            List<BoletoBancario> listaAuxiliar = new List<BoletoBancario>();
            
            //Dados dos boletos
            short codigoDoBanco = 104;

            //Configura as datas do boleto
            DateTime dataDoDocumeto        = DateTime.Now;
            String dataDoDocumentoString   = dataDoDocumeto.ToString("dd/MM/YYYY");
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

            //###################################################
            //################ - Cria boleto 1 - ################
            //###################################################
            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = codigoDoBanco;
            
            //Cria cedente
            Cedente c = new Cedente(cnpjDoCedente, nomeDoCedente, agenciaDoCedente, contaDoCedente, digitoDaConta);
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

            EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
            boleto.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));

            boleto.NumeroDocumento = numeroDocumento;
            boleto.DataProcessamento = dataDoProcessamento;
            boleto.DataDocumento = dataDoDocumeto;

            boletoBancario.Boleto = boleto;
            boletoBancario.MostrarComprovanteEntrega = true;
            boletoBancario.FormatoCarne = true;
            
            boletoBancario.Boleto.Valida();

            //###################################################
            //################ - Cria boleto 2 - ################
            //###################################################
            BoletoBancario boletoBancario2 = new BoletoBancario();
            boletoBancario2.CodigoBanco = codigoDoBanco;

            //Cria cedente
            Boleto boleto2 = new Boleto(dataDeVencimento, valorDoCarne, carteira, nossoNumero, c);
            boleto2.DataDocumento = dataDoDocumeto;
            boleto2.DataProcessamento = dataDoProcessamento;

            boleto2.Sacado = new Sacado(cpfDoSacado, nomeDoSacado);
            boleto2.Sacado.Endereco.End = ruaDoSacado;
            boleto2.Sacado.Endereco.Bairro = bairroDoSacado;
            boleto2.Sacado.Endereco.Cidade = cidadeDoSacado;
            boleto2.Sacado.Endereco.CEP = cepDoSacado;
            boleto2.Sacado.Endereco.UF = estadoDoSacado;

            boleto2.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));

            boleto2.NumeroDocumento = numeroDocumento;
            boleto2.DataProcessamento = dataDoProcessamento;
            boleto2.DataDocumento = dataDoDocumeto;

            boletoBancario2.Boleto = boleto2;
            boletoBancario2.MostrarComprovanteEntrega = true;
            boletoBancario2.FormatoCarne = true;

            boletoBancario2.Boleto.Valida();

            //###################################################
            //################ - Cria boleto 3 - ################
            //###################################################
            BoletoBancario boletoBancario3 = new BoletoBancario();
            boletoBancario3.CodigoBanco = codigoDoBanco;

            //Cria cedente
            Boleto boleto3 = new Boleto(dataDeVencimento, valorDoCarne, carteira, nossoNumero, c);
            boleto3.DataDocumento = dataDoDocumeto;
            boleto3.DataProcessamento = dataDoProcessamento;

            boleto3.Sacado = new Sacado(cpfDoSacado, nomeDoSacado);
            boleto3.Sacado.Endereco.End = ruaDoSacado;
            boleto3.Sacado.Endereco.Bairro = bairroDoSacado;
            boleto3.Sacado.Endereco.Cidade = cidadeDoSacado;
            boleto3.Sacado.Endereco.CEP = cepDoSacado;
            boleto3.Sacado.Endereco.UF = estadoDoSacado;

            boleto3.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));

            boleto3.NumeroDocumento = numeroDocumento;
            boleto3.DataProcessamento = dataDoProcessamento;
            boleto3.DataDocumento = dataDoDocumeto;

            boletoBancario3.Boleto = boleto3;
            boletoBancario3.MostrarComprovanteEntrega = true;
            boletoBancario3.FormatoCarne = true;

            boletoBancario3.Boleto.Valida();

            //###################################################
            //###### - Adiciona Boletos na ListaAuxiliar - ######
            //###################################################
            listaAuxiliar.Add(boletoBancario);
            listaAuxiliar.Add(boletoBancario2);
            listaAuxiliar.Add(boletoBancario3);

            for (int i=0; i < listaAuxiliar.Count; i++)
            {
                Panel1.Controls.Add(listaAuxiliar[i]);
                
            }
            
            Label1.Text = listaAuxiliar.Count.ToString();
            

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
