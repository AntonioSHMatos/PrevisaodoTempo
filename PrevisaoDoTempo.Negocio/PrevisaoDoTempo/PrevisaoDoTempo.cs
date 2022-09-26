
using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempo.Infra.Entity;
using PrevisaoDoTempo.Modelo;

namespace PrevisaoDoTempo.Negocio.PrevisaoDoTempo
{
    public class PrevisaoDoTempoNegocio : IPrevisaoDoTempo
    {

        private readonly AppDbContext _context;

        public PrevisaoDoTempoNegocio(AppDbContext context)
        {
            _context = context;
        }

        public async Task Incluir(Previsao previsao)
        {
            await _context.Previsao.AddAsync(previsao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Previsao>> ObterLista()
        {
            return await _context.Previsao.ToListAsync();
        }
    }
}
