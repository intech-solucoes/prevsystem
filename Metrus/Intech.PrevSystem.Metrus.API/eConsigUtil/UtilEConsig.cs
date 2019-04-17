using eConsig;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Intech.PrevSystem.Metrus.API.eConsigUtil
{
    public class UtilEConsig
    {
        #region Constantes

        private const string cliente = "METRUS";
        private const string convenio = "METRUS-METROSP";
        private const string codigoVerba = "97R";
        private const string codigoServico = "007";
        private const string keyNameUsuarioEConsig = "UsuarioEConsig";
        private const string keyNameSenhaEConsig = "SenhaEConsig";

        #endregion

        #region Propriedades

        private string Usuario => AppSettings.Get().EConsig.Usuario;
        private string Senha => AppSettings.Get().EConsig.Senha;

        #endregion

        public async Task<DadosEConsig> ObtemMargemConsignavelAsync(string matricula, string cpf)
        {
            matricula = matricula.TrimStart('0');
            cpf = cpf.AplicarMascara(Mascaras.CPF);

            return await ObtemValorMargemConsignavelComReforma(matricula, cpf);
        }

        public async void ReservarMargemConsignavel(string matricula, string cpf, decimal valorParcela, int carencia, int prazo)
        {
            matricula = matricula.TrimStart('0');
            cpf = cpf.AplicarMascara(Mascaras.CPF);

            try
            {
                var eConsigClient = new HostaHostPortTypeClient();

                var resultadoDaChamada = await eConsigClient.reservarMargemAsync(new reservarMargemRequest(
                    cliente, convenio, Usuario, Senha, matricula, cpf, string.Empty,
                    string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    DateTime.Now, Convert.ToDouble(valorParcela), null, 0, codigoVerba, string.Empty,
                    carencia, 0, string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty));

                if (!resultadoDaChamada.sucesso)
                {
                    if (!string.IsNullOrEmpty(resultadoDaChamada.mensagem))
                        throw new Exception($"Erro eConsig:{resultadoDaChamada.codRetorno} {resultadoDaChamada.mensagem}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro eConsig:{ex.Message}");
            }
        }

        public async void CancelarConsignacao(string matricula, string cpf, long adeNumero, string motivoCancelamento)
        {
            try
            {
                var eConsigClient = new HostaHostPortTypeClient();
                var resultadoDaChamada = await eConsigClient.cancelarConsignacaoAsync(new cancelarConsignacaoRequest(
                    cliente, convenio, Usuario, Senha, adeNumero, string.Empty, string.Empty, motivoCancelamento));

                if (!resultadoDaChamada.sucesso)
                {
                    if (!string.IsNullOrEmpty(resultadoDaChamada.mensagem))
                        throw new Exception($"Erro eConsig:{resultadoDaChamada.codRetorno} {resultadoDaChamada.mensagem}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro eConsig:{ex.Message}");
            }
        }

        public async void CancelarReserva(string matricula, string cpf, long adeNumero, string motivoCancelamento)
        {
            try
            {
                var eConsigClient = new HostaHostPortTypeClient();
                var resultadoDaChamada = await eConsigClient.cancelarReservaAsync(new cancelarReservaRequest(cliente, convenio, Usuario, Senha, null, string.Empty, string.Empty, motivoCancelamento));

                if (!resultadoDaChamada.sucesso)
                {
                    if (!string.IsNullOrEmpty(resultadoDaChamada.mensagem))
                        throw new Exception($"Erro eConsig:{resultadoDaChamada.codRetorno} {resultadoDaChamada.mensagem}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro eConsig:{ex.Message}");
            }
        }        

        #region MetodosPrivados

        private async Task<decimal> ObtemValorMargemConsignavelSemReforma(string matricula, string cpf)
        {
            try
            {
                var eConsigClient = new HostaHostPortTypeClient();

                var resultadoDaChamada = await eConsigClient.consultarMargemAsync(new consultarMargemRequest(
                    cliente, convenio, Usuario, Senha, matricula, cpf, string.Empty, string.Empty, 
                    1,//valor é fixo para sempre retornar o total disponivel sem reforma.,
                    string.Empty, string.Empty, string.Empty, codigoVerba, codigoServico, false));

                if (resultadoDaChamada.sucesso)
                    return Convert.ToDecimal(resultadoDaChamada.infoMargem[0].valorMargem);
                else
                {
                    if (!string.IsNullOrEmpty(resultadoDaChamada.mensagem))
                        throw new Exception($"Erro eConsig:{resultadoDaChamada.codRetorno} {resultadoDaChamada.mensagem}");
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro eConsig:{ex.Message}");
            }
        }

        private async Task<DadosEConsig> ObtemValorMargemConsignavelComReforma(string matricula, string cpf)
        {
            var retorno = new DadosEConsig();

            var valorMargemLivre = await ObtemValorMargemConsignavelSemReforma(matricula, cpf);

            try
            {
                eConsig.SituacaoContrato situacaoDoContrato = new eConsig.SituacaoContrato();
                eConsig.SituacaoServidor situacaoDoServidor = new eConsig.SituacaoServidor();

                var eConsigClient = new HostaHostPortTypeClient();
                var resultadoDaChamada = await eConsigClient.detalharConsultaConsignacaoAsync(new detalharConsultaConsignacaoRequest(
                    cliente, convenio, Usuario, Senha, null, string.Empty, 
                    matricula, cpf, string.Empty, string.Empty, string.Empty, 
                    codigoServico, codigoVerba, false, false, false, false, null, null, null, null, null, string.Empty, situacaoDoContrato, null));

                if (resultadoDaChamada.sucesso)
                {
                    ///Verificar se o resumo é deferido.
                    var resumo = resultadoDaChamada.resumos.FirstOrDefault(x => x.statusCodigo == "4");

                    if (resumo == null)
                    {
                            
                        ///Verificar se o boleto é deferido.
                        if (resultadoDaChamada.boleto != null && resultadoDaChamada.boleto.statusCodigo == "4")
                        {
                            retorno = new DadosEConsig()
                            {
                                AdeNumero = resultadoDaChamada.boleto.adeNumero,
                                ValorMargemLivreAntiga = Convert.ToDecimal(resultadoDaChamada.boleto.valorParcela),
                                ValorMargemLivre = Convert.ToDecimal(resultadoDaChamada.boleto.valorParcela),
                            };
                        }
                    }
                    else
                    {
                        retorno = new DadosEConsig()
                        {
                            AdeNumero = resumo.adeNumero,
                            ValorMargemLivreAntiga = Convert.ToDecimal(resumo.valorParcela),
                            ValorMargemLivre = Convert.ToDecimal(resumo.valorParcela),
                        };
                    }
                }
                else if(resultadoDaChamada.codRetorno != "294")
                {
                    if (!string.IsNullOrEmpty(resultadoDaChamada.mensagem))
                        throw new Exception($"Erro eConsig:{resultadoDaChamada.codRetorno} {resultadoDaChamada.mensagem}");
                }

                if (valorMargemLivre > 0)
                {
                    retorno.ValorMargemLivre += valorMargemLivre;
                }
                    
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro eConsig:{ex.Message} ");
            }
        }

        #endregion
    }
}