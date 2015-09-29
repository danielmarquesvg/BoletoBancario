<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDados.aspx.cs" Inherits="BoletoCAIXA.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
   
    <title></title>
</head>

<script src="js/bootstrap.js"></script>
<script src="js/bootstrap.min.js"></script>

<body>

    <div class="container">
    
        <div class="bs-docs-section">
            <div class="page-header">
                <h1 id="tiles">Caixa Econômica Federal - Boleto sem registro</h1>
            </div>
        </div>

        <form  role="form" name="formDados" method="post" action="WebFormBoleto.aspx">
                        	

            <div class="bs-docs-section">
    		    <div class="page-header">
      			    <h3 id="tiles">Boleto</h3>
    			</div>
			</div>

            <div class="input-group">

                <span class="input-group-addon">Valor do Boleto</span>
                <input type="text" class="form-control" name="boletoValor" id="boletoValor">

                <span class="input-group-addon">Vencimento do Boleto</span>
                <input type="text" class="form-control" name="boletoVencimento" id="boletoVencimento">

             </div>

            <div class="input-group">

                <span class="input-group-addon">Número do Documento</span>
                <input type="text" class="form-control" name="boletoNumeroDoDocumento" id="boletoNumeroDoDocumento">

                <span class="input-group-addon">Carteira</span>
                <input type="text" class="form-control" name="boletoCarteira" id="boletoCarteira">

             </div>

            <div class="input-group">

                <span class="input-group-addon">Código do Banco</span>
                <input type="text" class="form-control" name="boletoCodigoDoBanco" id="boletoCodigoDoBanco">

                <span class="input-group-addon">Data do Documento</span>
                <input type="text" class="form-control" name="boletoDataDoDocumento" id="boletoDataDoDocumento">

                <span class="input-group-addon">Data de Processamento</span>
                <input type="text" class="form-control" name="boletoDataDeProcessamento" id="boletoDataDeProcessamento">

             </div>

                            <div class="bs-docs-section">
    							<div class="page-header">
      								<h3 id="tiles">Sacado</h3>
    							</div>
							</div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">Nome do Sacado</span>
                                <input type="text" class="form-control" placeholder="Nome completo do sacado" name="sacadoNome" id="sacadoNome" autofocus>
                            </div>
                    
                            <div class="input-group">
                                <span class="input-group-addon">CPF / CNPJ</span>
                                <input type="text" class="form-control" placeholder="000.000.000-00" name="sacadoCPFCNPJ" id="sacadoCPFCNPJ">
                            </div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">Endereço do Sacado</span>
                                <input type="text" class="form-control" placeholder="Rua" name="sacadoEnderecoRua" id="sacadoEnderecoRua">
                            </div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">Número</span>
                              	<input type="text" class="form-control" name="sacadoEnderecoNumero" id="sacadoEnderecoNumero">
                                
                                <span class="input-group-addon">Complemento</span>
                              	<input type="text" class="form-control" name="sacadoEnderecoComplemento" id="sacadoEnderecoComplemento">
                            </div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">Bairro</span>
                              	<input type="text" class="form-control" name="sacadoEnderecoBairro" id="sacadoEnderecoBairro">
                            </div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">Estado</span>
                              	<input type="text" class="form-control" name="sacadoEstadoUF" id = "sacadoEstadoUF">
                                
                                <span class="input-group-addon">Cidade</span>
                                <input type="text" class="form-control" name="sacadoCidade" id = "sacadoCidade">
                            </div>
                            
                            <div class="input-group">
                                <span class="input-group-addon">CEP</span>
                                <input type="text" class="form-control" name="sacadoCEP" id = "sacadoCEP">
                            </div>
                            
                            
                            <br>
                            
                            <div class="bs-docs-section">
                                <div class="page-header">
                                    <h3 id="tiles">Cedente</h3>
                                    <!-- codigo, nossoNumeroBoleto, CPF CNPJ, nome, agencia, conta, digitoConta -->
                                </div>
                            </div>
                            
                             <div class="input-group">
                                <span class="input-group-addon">Códido do Cedente</span>
                                <input type="date" class="form-control" placeholder="Tem que ter 6 dígitos" name="cedenteCodigo" id="cedenteCodigo">
                                
                                <span class="input-group-addon">Nosso número do Boleto</span>
                                <input type="date" class="form-control" placeholder="Tem que ter 10, 14 ou 17 posições" name="CedenteNossoNumeroBoleto" id="cedenteNossoNumeroBoleto">
                                 
                             </div>
                             
							<div class="input-group">
                            	
                                <span class="input-group-addon">CPF / CNPJ</span>
                                <input type="text" class="form-control" placeholder="000.000.000-00" name="CedenteCPFCNPJ" id="cedenteCPFCNPJ">
                                
                                <span class="input-group-addon">Nome do Cedente</span>
                                <input type="text" class="form-control" name="cedenteNome" id="cedenteNome">
                            </div> 
                            
                            <div class="input-group">
                            	
                                <span class="input-group-addon">Agência do Cedente</span>
                                <input type="text" class="form-control" name="cedenteAgencia" id="cedenteAgencia">

                                <span class="input-group-addon">Conta do Cedente</span>
                                <input type="text" class="form-control" name="cedenteConta" id="cedenteConta">

                                <span class="input-group-addon">Dígito do Cedente</span>
                                <input type="text" class="form-control" name="cedenteDigito" id="cedenteDigito">
                                
                            </div>


                            <br>
                            <br>
                            <button type="submit" class="btn btn-primary" value="submit" onclick="enviarFormulario">Gerar Boleto</button>
                            <br>
                        </form>

    </div>
    <br>    
</body>
</html>
