import React from 'react';

export default class Validacao extends React.Component {
    constructor(props) {
        super(props);
        this.calculaIdade = this.calculaIdade.bind(this);
        this.verificaQuantidadeDiasMes = this.verificaQuantidadeDiasMes.bind(this);
    }

    calculaIdade() {
        var diaAtual = new Date().getDate();
        var mesAtual = new Date().getMonth();
        mesAtual++;    // getMonth() retorna o mês atual entre 0 e 11. Com o incremento o valor fica entre 1 e 12.
        var anoAtual = new Date().getFullYear();
        var diaNascimento = 28;
        var mesNascimento = 1;
        var anoNascimento = 1953;

        var anosIdade = anoAtual - anoNascimento;
        var mesesIdade = 0;
        var diasIdade = 0;
        var mesesCorridosAno = mesAtual - 1;
        var ultimoDiaMes = this.verificaQuantidadeDiasMes(mesAtual, anoAtual);    // Variável que armazena a quantidade de dias do mês atual.

        // Condicional caso 1: antes do mês de aniversário.
        if(mesAtual < mesNascimento) {
            anosIdade--;
            // Caso 1.1: antes do dia do aniversário.
            if(diaAtual < diaNascimento) {
                mesesIdade = mesesCorridosAno + (12 - mesNascimento);
                diasIdade = (ultimoDiaMes - diaNascimento + diaAtual);
            // Caso 1.2: dia do aniversário (onde faltam meses exatos para o aniversário).
            } else if(diaAtual === diaNascimento) {
                mesesIdade = (12 - mesNascimento) + mesesCorridosAno + 1;
                diasIdade = 0;
            } else if(diaAtual > diaNascimento) {
                mesesIdade = mesesCorridosAno + (12 - mesNascimento) + 1;
                diasIdade = diaAtual - diaNascimento;
            } else {
            }

        // Caso 2: mês de aniversário.
        } else if(mesAtual === mesNascimento) {
            // Caso 2.1: antes do dia de aniversário.
            if(diaAtual < diaNascimento) {
                anosIdade--;
                mesesIdade = 11;
                diasIdade = (ultimoDiaMes - diaNascimento + diaAtual) + 1;
            // Caso 2.2: dia do aniversário ou superior, onde os dias de idade são diaAtual menos o diaNascimento ou zero (caso seja o data do aniversário).
            } else {
                mesesIdade = 0;
                diasIdade = diaAtual - diaNascimento;
            }

        // Caso 3: passado o mês de aniverário.
        } else if(mesAtual > mesNascimento) {
            // Caso 3.1: antes do dia do aniversário.
            if(diaAtual < diaNascimento) {
                mesesIdade = mesesCorridosAno - mesNascimento;
                diasIdade = (ultimoDiaMes - diaNascimento + diaAtual) + 1;
            // Caso 3.2: dia do aniversário.
            } else if(diaAtual === diaNascimento) {
                mesesIdade = mesesCorridosAno - mesNascimento + 1;
                diasIdade = diaAtual - diaNascimento;
            // Caso 3.3: passado o dia de aniversário.
            } else if(diaAtual > diaNascimento) {
                mesesIdade = mesesCorridosAno - mesNascimento;
                diasIdade = diaAtual - diaNascimento;
            }
        } else {
        }

        return(anosIdade + "a " + mesesIdade + "m " + diasIdade + "d");
    }

    verificaQuantidadeDiasMes(mes, ano) {
        var ultimoDiaMes = 0;
        switch (mes) {
            case 1: {
                return(ultimoDiaMes = 31);
                break;
            }
            case 2: {
                // Verifica se o ano é bissexto.
                if(ano % 4 === 0 & (ano % 400 === 0 | ano % 100 !== 0)) {
                    return(ultimoDiaMes = 29);
                } else {
                    return(ultimoDiaMes = 28)
                }
            }
            case 3: {
                return(ultimoDiaMes = 31);
                break;
            }
            case 4: {
                return(ultimoDiaMes = 30);
                break;
            }
            case 5: {
                return(ultimoDiaMes = 31);
                break;
            }
            case 6: {
                return(ultimoDiaMes = 30);
                break;
            }
            case 7: {
                return(ultimoDiaMes = 31);
                break;
            }
            case 8: {
                return(ultimoDiaMes = 31);
                break;
            }
            case 9: {
                return(ultimoDiaMes = 30);
            }
            case 10: {
                return(ultimoDiaMes = 31);
                break;
            }
            case 11: {
                return(ultimoDiaMes = 30);
                break;
            }
            case 12: {
                return(ultimoDiaMes = 31);
                break;
            }
            default: {
                return(ultimoDiaMes = 30);
                break;
            }
        }
    }

    validaCampos() {

    }

    render() {
        return (
            <div>
                {this.calculaIdade()}
            </div>
        );
    }
}
