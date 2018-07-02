#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Linq;
#endregion;

namespace Intech.PrevSystem.Preves.Negocio
{
    /// <summary>
    /// Classe principal da Simulação de Não Participante.
    /// Contém todos os métodos que calculam os resultados da simulação com base nos dados de entrada e valores de tabelas.
    /// </summary>
    public class SimNaoParticipante
    {
        #region Atributos

        public int Idade;
        public decimal IdadeDecimal;
        public string TipoAtivo;
        public int IdadeAposentadoria;
        public int TempoAposentadoria;
        public int TempoSobrevivencia;
        public decimal RemuneracaoInicial;
        public decimal RemuneracaoFinal;
        public decimal TaxaCrescimentoSalarial;
        public decimal TaxaJurosReal;

        public decimal PercentualBasicoParticipante;
        public decimal BeneficioRiscoInvalidezParticipante;
        public decimal BeneficioRiscoPensaoMorteParticipante;
        public decimal SobrevivenciaParticipante;
        public decimal CarregamentoContribuicaoBasicaParticipante;

        public decimal PercentualBasicoPatrocinador;
        public decimal BeneficioRiscoInvalidezPatrocinador;
        public decimal BeneficioRiscoPensaoMortePatrocinador;
        public decimal SobrevivenciaPatrocinador;
        public decimal CarregamentoContribuicaoBasicaPatrocinador;

        public decimal ContribuicaoAdicionalAposentadoria;
        public decimal ContribuicaoAdicionalInvalidez;
        public decimal ContribuicaoAdicionalPensaoMorte;
        public decimal ContribuicaoAdicionalSobrevivencia;
        public decimal CarregamentoContribuicaoAdicional;

        public decimal MontanteAcumuladoAposentadoria;
        public decimal MontanteAcumuladoInvalidez;
        public decimal MontanteAcumuladoPensaoMorte;
        public decimal MontanteAcumuladoSobrevivencia;

        public decimal ValorIndiceRgps;
        public decimal TempoContribuicao;
        public decimal RentabilidadeMensal;
        public int TempoAposentadoriaMeses;

        #endregion

        /// <summary>
        /// Construtor alternativo de SimNaoParticipante que 'setta' os atributtos de acordo com o objeto dinâmico recebido.
        /// </summary>
        /// <param name="dados">Um objeto dinâmico com os dados de entrada do usuário</param>
        public SimNaoParticipante(dynamic dados)
        {
            Idade = dados.idade;
            IdadeDecimal = dados.idadeDecimal;
            TipoAtivo = dados.tipoAtivo;
            IdadeAposentadoria = dados.idadeAposentadoria;
            TempoAposentadoria = dados.tempoAposentadoria;
            TempoSobrevivencia = dados.tempoSobrevivencia;
            RemuneracaoInicial = dados.remuneracaoInicial;
            RemuneracaoFinal = dados.remuneracaoFinal;
            TaxaCrescimentoSalarial = dados.taxaCrescimentoSalarial;
            TaxaJurosReal = dados.taxaJurosReal;

            // Contribuições Participante
            PercentualBasicoParticipante = dados.percentualBasicoParticipante;
            BeneficioRiscoInvalidezParticipante = dados.beneficioRiscoInvalidezParticipante;
            BeneficioRiscoPensaoMorteParticipante = dados.beneficioRiscoPensaoMorteParticipante;
            SobrevivenciaParticipante = dados.sobrevivenciaParticipante;
            CarregamentoContribuicaoBasicaParticipante = dados.carregamentoContribuicaoBasicaParticipante;

            // Contribuições Patrocinador
            PercentualBasicoPatrocinador = dados.percentualBasicoPatrocinador;
            BeneficioRiscoInvalidezPatrocinador = dados.beneficioRiscoInvalidezPatrocinador;
            BeneficioRiscoPensaoMortePatrocinador = dados.beneficioRiscoPensaoMortePatrocinador;
            SobrevivenciaPatrocinador = dados.sobrevivenciaPatrocinador;
            CarregamentoContribuicaoBasicaPatrocinador = dados.carregamentoContribuicaoBasicaPatrocinador;

            // Contribuições Adicionais
            ContribuicaoAdicionalAposentadoria = dados.contribuicaoAdicionalAposentadoria;
            ContribuicaoAdicionalInvalidez = ((decimal)dados.contribuicaoAdicionalInvalidez) / 100;
            ContribuicaoAdicionalPensaoMorte = ((decimal)dados.contribuicaoAdicionalPensaoMorte) / 100;
            ContribuicaoAdicionalSobrevivencia = ((decimal)dados.contribuicaoAdicionalSobrevivencia) / 100;
            CarregamentoContribuicaoAdicional = dados.carregamentoContribuicaoAdicional;

            // Valores muito utilizados
            ValorIndiceRgps = GetIndiceRgps();
            TempoContribuicao = Math.Ceiling((IdadeAposentadoria - IdadeDecimal) * 12);
            RentabilidadeMensal = (decimal) Math.Pow(1 + (Convert.ToDouble(TaxaJurosReal) / 100), (1 / 12.0)) - 1;
            TempoAposentadoriaMeses = TempoAposentadoria * 12;
        }

        /// <summary>
        /// Método que 'setta' atributos, calcula e retorna um objeto com os valores das contribuições e montantes.
        /// </summary>
        /// <returns>
        /// Objeto dinâmico com os valores das contribuições e montantes acumulados até a data da aposentadoria, 
        /// resultado dos cálculos obtidos pelos valores de entrada nos passos 1 e 2.
        /// </returns>
        public dynamic BuscarValoresContribuicoes()
        {
            // Valores Contribuição Participante
            var contribuicaoInicialAposentadoriaParticipante = CalculaContribuicaoInicialAposentadoriaParticipante();
            var contribuicaoInicialInvalidezParticipante = CalculaContribuicaoInicialInvalidezParticipante();
            var contribuicaoInicialPensaoMorteParticipante = CalculaContribuicaoInicialPensaoMorteParticipante();
            var contribuicaoInicialSobrevivenciaParticipante = CalculaContribuicaoInicialSobrevivenciaParticipante();
            var carregamentoTotalParticipante = CalculaCarregamentoTotalParticipante();

            // Valores Contribuição Patrocinador
            var contribuicaoInicialAposentadoriaPatrocinador = CalculaContribuicaoInicialAposentadoriaPatrocinador();
            var contribuicaoInicialInvalidezPatrocinador = CalculaContribuicaoInicialInvalidezPatrocinador();
            var contribuicaoInicialPensaoMortePatrocinador = CalculaContribuicaoInicialPensaoMortePatrocinador();
            var contribuicaoInicialSobrevivenciaPatrocinador = CalculaContribuicaoInicialSobrevivenciaPatrocinador();
            var carregamentoTotalPatrocinador = CalculaCarregamentoTotalPatrocinador();

            // Valores Contribuição Total
            var contribuicaoInicialTotalAposentadoria = contribuicaoInicialAposentadoriaParticipante + contribuicaoInicialAposentadoriaPatrocinador;
            var contribuicaoInicialTotalInvalidez = contribuicaoInicialInvalidezParticipante + contribuicaoInicialInvalidezPatrocinador;
            var contribuicaoInicialTotalPensaoMorte = contribuicaoInicialPensaoMorteParticipante + contribuicaoInicialPensaoMortePatrocinador;
            var contribuicaoInicialTotalSobrevivencia = contribuicaoInicialSobrevivenciaParticipante + contribuicaoInicialSobrevivenciaPatrocinador;
            var contribuicaoInicialTotalCarregamentoTotal = carregamentoTotalParticipante + carregamentoTotalPatrocinador;
            
            var contribuicaoTotalParticipante = contribuicaoInicialAposentadoriaParticipante + contribuicaoInicialInvalidezParticipante + 
                + contribuicaoInicialPensaoMorteParticipante + contribuicaoInicialSobrevivenciaParticipante + carregamentoTotalParticipante;
            var contribuicaoTotalPatrocinador = contribuicaoInicialAposentadoriaPatrocinador + contribuicaoInicialInvalidezPatrocinador + 
                + contribuicaoInicialPensaoMortePatrocinador + contribuicaoInicialSobrevivenciaPatrocinador + carregamentoTotalPatrocinador;
            var contribuicaoTotal = contribuicaoTotalParticipante + contribuicaoTotalPatrocinador;

            // Valores Montantes Acumulados
            var montanteInvalidez = CalculaMontanteInvalidez(Idade);
            var montantePensaoMorte = CalculaMontantePensaoMorte(Idade);
            var montanteAposentadoria = CalculaMontanteAposentadoria();
            var montanteSobrevivencia = CalculaMontanteSobrevivencia();

            // Valores Benefício Mensal Simulado
            var beneficioMensalAposentadoria = CalculaBeneficioMensalAposentadoria();
            var beneficioMensalInvalidez = CalculaBeneficioMensalInvalidez();
            var beneficioMensalPensaoMorte = CalculaBeneficioMensalPensaoMorte();
            var beneficioMensalSobrevivencia = CalculaBeneficioMensalSobrevivencia();

            var remuneracaoFinalCrescimentoBianual = CalculaRemuneracaoFinalCrescimentoBianual();

            return new
            {
                contribuicaoInicialAposentadoriaParticipante,
                contribuicaoInicialAposentadoriaPatrocinador,
                contribuicaoInicialInvalidezParticipante,
                contribuicaoInicialInvalidezPatrocinador,
                contribuicaoInicialPensaoMorteParticipante,
                contribuicaoInicialPensaoMortePatrocinador,
                contribuicaoInicialSobrevivenciaParticipante,
                contribuicaoInicialSobrevivenciaPatrocinador,
                carregamentoTotalParticipante,
                carregamentoTotalPatrocinador,
                contribuicaoInicialTotalAposentadoria,
                contribuicaoInicialTotalInvalidez,
                contribuicaoInicialTotalPensaoMorte,
                contribuicaoInicialTotalSobrevivencia,
                contribuicaoInicialTotalCarregamentoTotal,
                contribuicaoTotalParticipante,
                contribuicaoTotalPatrocinador,
                contribuicaoTotal,
                montanteAposentadoria,
                montanteInvalidez,
                montantePensaoMorte,
                montanteSobrevivencia,
                beneficioMensalAposentadoria,
                beneficioMensalInvalidez,
                beneficioMensalPensaoMorte,
                beneficioMensalSobrevivencia,
                remuneracaoFinalCrescimentoBianual
            };
        }

        #region Métodos Busca Indices Fatores de Risco

        /// <summary>
        /// Método que busca o valor do último índice Rgps na tabela de índice.
        /// </summary>
        /// <returns>
        /// Decimal 'valorIndiceRgps' que representa o valor do último índice Rgps na tabela de índice.
        /// </returns>
        private decimal GetIndiceRgps()
        {
            var indiceRgps = new IndiceValoresProxy().BuscarPorCodigo("RGPS");

            var valorIndiceRgps = indiceRgps
                .OrderByDescending(x => x.DT_IND)
                .FirstOrDefault()
                .VALOR_IND;

            // Para o cálculo de ativos Facultativos ou Participante CDT, o índice RGPS deve ser 0.
            if (TipoAtivo != "normal")
                valorIndiceRgps = 0;

            return valorIndiceRgps;
        }

        /// <summary>
        /// Método que busca e retorna o Fator de Risco de Invalidez na tabela WEB_FATOR_RISCO
        /// </summary>
        /// <param name="idade">
        /// Idade em anos completos do usuário, utilizado para buscar o Fator de Risco de Invalidez que varia de acordo com a idade.
        /// </param>
        /// <returns>
        /// Fator de risco de invalidez.
        /// </returns>
        private decimal GetFatorRiscoInvalidez(int idade)
        {
            var fatorRiscoInvalidez = new FatorRiscoProxy().BuscarPorFundacaoPlano("01", "0001", idade);
            return fatorRiscoInvalidez.VAL_FATOR_INVALIDEZ;
        }

        /// <summary>
        /// Método que busca e retorna o Fator de Risco de Pensão por Morte na tabela WEB_FATOR_RISCO
        /// </summary>
        /// <param name="idade">
        /// Idade em anos completos do usuário, utilizado para buscar o Fator de Risco de Pensão por Morte que varia de acordo com a idade.
        /// </param>
        /// <returns>
        /// Fator de risco de pensão por morte.
        /// </returns>
        private decimal GetFatorRiscoPensaoMorte(int idade)
        {
            var fatorRiscoPensaoMorte = new FatorRiscoProxy().BuscarPorFundacaoPlano("01", "0001", idade);
            return fatorRiscoPensaoMorte.VAL_FATOR_MORTE;
        }

        #endregion

        #region Métodos Cálculos de Contribuições

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial da Aposentadoria (Participante).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial da Aposentadoria (Participante).
        /// </returns>
        private decimal CalculaContribuicaoInicialAposentadoriaParticipante()
        {
            decimal percentualAposentadoria = (PercentualBasicoParticipante - BeneficioRiscoInvalidezParticipante - BeneficioRiscoPensaoMorteParticipante - 
                 SobrevivenciaParticipante - CarregamentoContribuicaoBasicaParticipante) + (ContribuicaoAdicionalAposentadoria * Convert.ToDecimal(0.94));

            decimal contribuicaoInicialAposentadoriaParticipante = (RemuneracaoInicial - ValorIndiceRgps) * (percentualAposentadoria / 100);
            return contribuicaoInicialAposentadoriaParticipante;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial da Aposentadoria (Patrocinador).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial da Aposentadoria (Patrocinador).
        /// </returns>
        private decimal CalculaContribuicaoInicialAposentadoriaPatrocinador()
        {
            decimal percentualAposentadoria = (PercentualBasicoPatrocinador - BeneficioRiscoInvalidezPatrocinador - BeneficioRiscoPensaoMortePatrocinador - 
                SobrevivenciaPatrocinador - CarregamentoContribuicaoBasicaPatrocinador);

            decimal contribuicaoInicialAposentadoriaPatrocinador = (RemuneracaoInicial - ValorIndiceRgps) * (percentualAposentadoria / 100);
            return contribuicaoInicialAposentadoriaPatrocinador;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial do Benefício de risco por Invalidez (Participante).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial do Benefício de risco por Invalidez (Participante).
        /// </returns>
        private decimal CalculaContribuicaoInicialInvalidezParticipante()
        {
            decimal contribuicaoInicialInvalidezParticipante = (RemuneracaoInicial - ValorIndiceRgps) * ((BeneficioRiscoInvalidezParticipante / 100) + 
                 (ContribuicaoAdicionalInvalidez * Convert.ToDecimal(0.94)));
            return contribuicaoInicialInvalidezParticipante;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial do Benefício de risco por Invalidez (Patrocinador).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial do Benefício de risco por Invalidez (Patrocinador).
        /// </returns>
        private decimal CalculaContribuicaoInicialInvalidezPatrocinador()
        {
            decimal contribuicaoInicialInvalidezPatrocinador = (RemuneracaoInicial - ValorIndiceRgps) * (BeneficioRiscoInvalidezPatrocinador / 100);
            return contribuicaoInicialInvalidezPatrocinador;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial do Benefício de risco Pensao por Morte (Participante).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial do Benefício de risco Pensao por Morte (Participante).
        /// </returns>
        private decimal CalculaContribuicaoInicialPensaoMorteParticipante()
        {
            decimal contribuicaoInicialPensaoMorteParticipante = (RemuneracaoInicial - ValorIndiceRgps) * ((BeneficioRiscoPensaoMorteParticipante / 100) + 
                 ContribuicaoAdicionalPensaoMorte * Convert.ToDecimal(0.94));
            return contribuicaoInicialPensaoMorteParticipante;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial do Benefício de risco Pensao por Morte (Patrocinador).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial do Benefício de risco Pensao por Morte (Patrocinador).
        /// </returns>
        private decimal CalculaContribuicaoInicialPensaoMortePatrocinador()
        {
            decimal contribuicaoInicialPensaoMortePatrocinador = (RemuneracaoInicial - ValorIndiceRgps) * (BeneficioRiscoPensaoMortePatrocinador / 100);
            return contribuicaoInicialPensaoMortePatrocinador;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial da Sobrevivência (Participante).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial da Sobrevivência (Participante).
        /// </returns>
        private decimal CalculaContribuicaoInicialSobrevivenciaParticipante()
        {
            decimal contribuicaoInicialSobrevivenciaParticipante = (RemuneracaoInicial - ValorIndiceRgps) * ((SobrevivenciaParticipante / 100) + 
                 (ContribuicaoAdicionalSobrevivencia * Convert.ToDecimal(0.94)));
            return contribuicaoInicialSobrevivenciaParticipante;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial da Sobrevivência (Patrocinador). 
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial da Sobrevivência (Patrocinador).
        /// </returns>
        private decimal CalculaContribuicaoInicialSobrevivenciaPatrocinador()
        {
            decimal contribuicaoInicialSobrevivenciaPatrocinador = (RemuneracaoInicial - ValorIndiceRgps) * (SobrevivenciaPatrocinador / 100);
            return contribuicaoInicialSobrevivenciaPatrocinador;
        }
        
        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial do Carregamento Total (Participante).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial do Carregamento Total (Participante).
        /// </returns>
        private decimal CalculaCarregamentoTotalParticipante()
        {
            decimal carregamentoTotalParticipante = (RemuneracaoInicial - ValorIndiceRgps) * (CarregamentoContribuicaoBasicaParticipante / 100) + 
                 (RemuneracaoInicial - ValorIndiceRgps) * (CarregamentoContribuicaoAdicional / 100);
            return carregamentoTotalParticipante;
        }

        /// <summary>
        /// Método que calcula o valor da Contribuição Inicial do Carregamento Total (Patrocinador).
        /// </summary>
        /// <returns>
        /// Decimal que representa o valor da Contribuição Inicial do Carregamento Total (Patrocinador).
        /// </returns>
        private decimal CalculaCarregamentoTotalPatrocinador()
        {
            decimal carregamentoTotalPatrocinador = (RemuneracaoInicial - ValorIndiceRgps) * (CarregamentoContribuicaoBasicaPatrocinador / 100);
            return carregamentoTotalPatrocinador;
        }

        #endregion

        #region Métodos Cálculos de Montantes

        /// <summary>
        /// Método que calcula o valor do Montante acumulado pela aposentadoria. Basicamente, esse valor é obtido a partir do incremento do valor atualizado.
        /// </summary>
        /// <returns>
        /// O valor do montante acumulado da aposentadoria.
        /// </returns>
        private decimal CalculaMontanteAposentadoria()
        {
            decimal salario = RemuneracaoInicial;
            decimal baseComplementar = 0;

            // percentualParticipante e percentualPatrocinador: Percentuais de contribuição do participante e patrocinador.
            decimal percentualParticipante = ((PercentualBasicoParticipante + (ContribuicaoAdicionalAposentadoria * Convert.ToDecimal(0.94))) - BeneficioRiscoInvalidezParticipante - 
                BeneficioRiscoPensaoMorteParticipante - SobrevivenciaParticipante - CarregamentoContribuicaoBasicaParticipante) / 100;

            decimal percentualPatrocinador = (PercentualBasicoPatrocinador - BeneficioRiscoInvalidezParticipante - BeneficioRiscoPensaoMortePatrocinador -
                SobrevivenciaPatrocinador - CarregamentoContribuicaoBasicaPatrocinador) / 100;

            decimal contribuicaoParticipante = 0;
            decimal contribuicaoPatrocinador = 0;

            decimal taxaMes = 0;

            decimal atualizado = 0;
            decimal acumulado = 0;

            // Loop que percorre o tempo de contribuição, em meses. Nesse trecho são setados os valores das contribuições mensais e por fim, o montante acumulado.
            for (var t = 1; t <= TempoContribuicao; t++)
            {
                // Caso tenha passado 2 anos, o salário tem um aumento com base na taxa de crescimento salarial.
                var periodo2Anos = (t % 24) - 1 == 0;
                if (periodo2Anos && t != 1)
                {
                    salario = salario * (1 + (TaxaCrescimentoSalarial / 100));
                }

                baseComplementar = salario - ValorIndiceRgps;

                contribuicaoParticipante = baseComplementar * percentualParticipante;
                // Condicional para ativos normais pois ativos facultativos e participante CDT não tem contribuição do Patrocinador.
                if(TipoAtivo == "normal")
                {
                    contribuicaoPatrocinador = baseComplementar * percentualPatrocinador;
                }

                taxaMes = Convert.ToDecimal(Math.Pow((1 + Convert.ToDouble(RentabilidadeMensal)), Convert.ToDouble(TempoContribuicao - t)));

                // Condicional valor Atualizado (Participante + Patrocinador)
                if (t % 12 == 0)
                    atualizado = ((contribuicaoParticipante + contribuicaoPatrocinador) * 2) * taxaMes;
                else
                    atualizado = (contribuicaoParticipante + contribuicaoPatrocinador) * taxaMes;

                acumulado += atualizado;    // Valor acumulado (gera montante)

            }

            return acumulado;
        }

        /// <summary>
        /// Método que calcula o valor do Montante acumulado de sobrevivência. Basicamente, esse valor é obtido a partir do incremento do valor atualizado.
        /// </summary>
        /// <returns>
        /// Valor do montanto acumulado de sobrevivencia
        /// </returns>
        private decimal CalculaMontanteSobrevivencia()
        {
            decimal salario = RemuneracaoInicial;
            decimal baseComplementar = 0;

            decimal contribuicaoTotalSobrevivencia = (SobrevivenciaParticipante / 100) + (ContribuicaoAdicionalSobrevivencia * Convert.ToDecimal(0.94));

            decimal contribuicaoSobrevivenciaParticipante = 0;
            decimal contribuicaoSobrevivenciaPatrocinador = 0;

            decimal taxaMes = 0;

            decimal atualizado = 0;
            decimal acumulado = 0;

            // Loop que percorre o tempo de contribuição, em meses. Nesse trecho são setados os valores das contribuições mensais e por fim, o montante acumulado.
            for (var t = 1; t <= TempoContribuicao; t++)
            {
                // Caso tenha passado 2 anos, o salário tem um aumento com base na taxa de crescimento salarial.
                var periodo2Anos = (t % 24) - 1 == 0;
                if (periodo2Anos && t != 1)
                {
                    salario = salario * (1 + TaxaCrescimentoSalarial / 100);
                }

                baseComplementar = salario - ValorIndiceRgps;

                contribuicaoSobrevivenciaParticipante = baseComplementar * contribuicaoTotalSobrevivencia;
                // Condicional para ativos normais pois ativos facultativos e participante CDT não tem contribuição do Patrocinador.
                if(TipoAtivo == "normal")
                {
                    contribuicaoSobrevivenciaPatrocinador = baseComplementar * (SobrevivenciaPatrocinador / 100);
                }

                taxaMes = Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 + RentabilidadeMensal), Convert.ToDouble(TempoContribuicao - t)));

                if (t % 12 == 0)
                    atualizado = ((contribuicaoSobrevivenciaParticipante + contribuicaoSobrevivenciaPatrocinador) * 2) * taxaMes;
                else
                    atualizado = (contribuicaoSobrevivenciaParticipante + contribuicaoSobrevivenciaPatrocinador) * taxaMes;

                acumulado += atualizado;

            }

            acumulado = acumulado * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(RentabilidadeMensal), Convert.ToDouble(TempoAposentadoriaMeses)));

            return acumulado;
        }

        /// <summary>
        /// Método que calcula o Montante acumulado pela Invalidez, a partir do benefício de invalidez do participante, invalidez adicional e 
        /// Fator de risco de invalidez (de acordo com a idade).
        /// </summary>
        /// <param name="idade"> Idade do participante, em anos completos.</param>
        /// <returns>
        /// Valor do montante acumulado pela invalidez.
        /// </returns>
        private decimal CalculaMontanteInvalidez(int idade)
        {
            var montanteInvalidez = (((RemuneracaoInicial - GetIndiceRgps()) * ((BeneficioRiscoInvalidezParticipante / 100) + 
                (ContribuicaoAdicionalInvalidez * Convert.ToDecimal(0.94)))) + ((RemuneracaoInicial - GetIndiceRgps())) * 
                (BeneficioRiscoInvalidezParticipante / 100)) / GetFatorRiscoInvalidez(Idade);

            if(TipoAtivo != "normal")
            {
                montanteInvalidez = ((RemuneracaoInicial - GetIndiceRgps()) * ((BeneficioRiscoInvalidezParticipante / 100) +
                (ContribuicaoAdicionalInvalidez * Convert.ToDecimal(0.94)))) / GetFatorRiscoInvalidez(Idade);
            }

            return montanteInvalidez;
        }

        /// <summary>
        /// Método que calcula o Montante acumulado pela Pensão por Morte, a partir do benefício de pensão por morte do participante, 
        /// pensão por morte adicional e Fator de risco de pensão por morte (de acordo com a idade).
        /// </summary>
        /// <param name="idade"> Idade do participante, em anos completos.</param>
        /// <returns>
        /// Valor do montante acumulado pela pensão por morte.
        /// </returns>
        private decimal CalculaMontantePensaoMorte(int idade)
        {
            var montantePensaoMorte = (((RemuneracaoInicial - GetIndiceRgps()) * ((BeneficioRiscoPensaoMorteParticipante / 100) + 
                (ContribuicaoAdicionalPensaoMorte * Convert.ToDecimal(0.94)))) + (RemuneracaoInicial - GetIndiceRgps()) * 
                (BeneficioRiscoPensaoMorteParticipante / 100)) / GetFatorRiscoPensaoMorte(Idade);
            
            if(TipoAtivo != "normal")
            {
                montantePensaoMorte = ((RemuneracaoInicial - GetIndiceRgps()) * ((BeneficioRiscoPensaoMorteParticipante / 100) +
                (ContribuicaoAdicionalPensaoMorte * Convert.ToDecimal(0.94)))) / GetFatorRiscoPensaoMorte(Idade);
            }

            return montantePensaoMorte;
        }

        #endregion

        #region Métodos Cálculos de Benefício Mensal Simulado

        /// <summary>
        /// Método que calcula o valor do Benefício Mensal Simulado da Aposentadoria.
        /// </summary>
        /// <returns>
        /// Benefício Mensal Simulado da Aposentadoria
        /// </returns>
        private decimal CalculaBeneficioMensalAposentadoria()
        {
            decimal beneficioMensalAposentadoria = CalculaMontanteAposentadoria() / ((1 - Convert.ToDecimal
                (Math.Pow((1 + Convert.ToDouble(RentabilidadeMensal)), (Convert.ToDouble(TempoAposentadoriaMeses) * -1)))) / RentabilidadeMensal);
            return beneficioMensalAposentadoria;
        }

        /// <summary>
        /// Método que calcula o valor do Benefício Mensal Simulado do Benefício de risco por Invalidez.
        /// </summary>
        /// <returns>
        /// Benefício Mensal Simulado do Benefício de risco por Invalidez.
        /// </returns>
        private decimal CalculaBeneficioMensalInvalidez()
        {
            decimal beneficioMensalInvalidez = CalculaMontanteInvalidez(Idade) / ((1 - Convert.ToDecimal
                (Math.Pow((1 + Convert.ToDouble(RentabilidadeMensal)), (Convert.ToDouble(TempoAposentadoriaMeses) * -1)))) / RentabilidadeMensal);
            return beneficioMensalInvalidez;

        }

        /// <summary>
        /// Método que calcula o valor do Benefício Mensal Simulado do Benefício de risco por Pensão por morte.
        /// </summary>
        /// <returns>
        /// Benefício Mensal Simulado do Benefício de risco por Pensão por morte.
        /// </returns>
        private decimal CalculaBeneficioMensalPensaoMorte()
        {
            decimal beneficioMensalPensaoMorte = CalculaMontantePensaoMorte(Idade) / ((1 - Convert.ToDecimal
                (Math.Pow((1 + Convert.ToDouble(RentabilidadeMensal)), (Convert.ToDouble(TempoAposentadoriaMeses) * -1)))) / RentabilidadeMensal);
            return beneficioMensalPensaoMorte;
        }

        /// <summary>
        /// Método que calcula o valor do Benefício Mensal Simulado da Sobrevivência.
        /// </summary>
        /// <returns>
        /// Benefício Mensal Simulado do Benefício da Sobrevivência
        /// </returns>
        private decimal CalculaBeneficioMensalSobrevivencia()
        {
            if (TempoSobrevivencia == 0)
                return 0;

            decimal tempoMeses = TempoSobrevivencia * 12;

            decimal beneficioMensalSobrevivencia = CalculaMontanteSobrevivencia() / ((1 - Convert.ToDecimal(Math.Pow((1 + Convert.ToDouble(RentabilidadeMensal)), (Convert.ToDouble(tempoMeses) * -1)))) / RentabilidadeMensal);
            return beneficioMensalSobrevivencia;
        }

        /// <summary>
        /// Método que calcula a remuneração final estipulada pelo crescimento bianual, a partir da taxa de crescimento salarial a cada dois anos, remuneração inicial, idade de aposentadoria e idade.
        /// </summary>
        /// <returns>
        /// Valor da remuneração final estipulada pelo crescimento bianual.
        /// </returns>
        private decimal CalculaRemuneracaoFinalCrescimentoBianual()
        {
            decimal remuneracaoFinal =  RemuneracaoInicial * (decimal) Math.Pow(1 + Convert.ToDouble(TaxaCrescimentoSalarial / 100), 
                Convert.ToDouble((IdadeAposentadoria - IdadeDecimal - 2) / 2));

            return remuneracaoFinal;
        }

        #endregion

    }
}
