using System;
using System.Collections.Generic;

namespace Cotacoes.Model
{
    public static class CotacaoService
    {
        public static Cotacao ObterUltima(int codigoMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterUltima(codigoMoeda);
        }

        public static Cotacao ObterUltima(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterUltima(siglaMoeda);
        }

        public static void Adicionar(IEnumerable<Cotacao> listaDeCotacoes)
        {
            CotacaoRepository.Adicionar(listaDeCotacoes);
        }

        public static DateTime ObterDataUltumaCotacao()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.DataUltumaCotacao();
        }

        public static IEnumerable<Cotacao> ListarUltimasCotacoes()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ListarUltimas();
        }

        public static IEnumerable<Cotacao> ListarCotacoes()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.Listar();
        }

        public static double ObterTaxaCompra(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterTaxaCompra(siglaMoeda);

        }

        public static double ObterTaxaVenda(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterTaxaVenda(siglaMoeda);
        }

        public static double ObterParidadeCompra(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterParidadeCompra(siglaMoeda);
        }

        public static double ObterParidadeVenda(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterParidadeVenda(siglaMoeda);
        }
    }
}