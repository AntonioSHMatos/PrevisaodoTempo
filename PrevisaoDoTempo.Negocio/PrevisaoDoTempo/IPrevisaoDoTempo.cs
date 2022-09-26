using PrevisaoDoTempo.Modelo;

namespace PrevisaoDoTempo.Negocio.PrevisaoDoTempo
{
    public interface IPrevisaoDoTempo
    {
        Task Incluir(Previsao previsao);
        Task<List<Previsao>> ObterLista();

    }
}
